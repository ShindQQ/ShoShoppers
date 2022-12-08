using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using Newtonsoft.Json;
using ShoShoppers.Bll.Filters;
using ShoShoppers.Bll.Models.Error;
using ShoShoppers.Bll.Models.HelperModels;
using ShoShoppers.Bll.Options;
using ShoShoppers.Bll.Services.Interfaces;
using ShoShoppers.Dal.Contexts;
using ShoShoppers.Dal.Entities;
using System.Net;
using System.Text.RegularExpressions;

namespace ShoShoppers.Bll.Services;

/// <summary>
///     Class which decribes all methods to work with Email Services
/// </summary>
public sealed class EMailService : BaseService<Email, EmailFilter>, IEMailService
{
    /// <summary>
    ///     Class which represents email host, username and password
    /// </summary>
    private readonly EmailInformationOptions _options;

    /// <summary>
    ///     Constructor for Email Service
    /// </summary>
    /// <param name="context">Database context</param>
    public EMailService(ShoShoppersContext context, IOptions<EmailInformationOptions> options) : base(context)
    {
        _options = options.Value;
    }

    /// <summary>
    ///     Sending notifications on signed up emails
    /// </summary>
    /// <param name="emailHelper">The class with subject and body of the email</param>
    /// <param name="emailsToSendOn">The list of emails to send email on</param>
    /// <returns>Task</returns>
    public async Task SendEmailsAsync(EmailHelper emailHelper, List<string>? emailsToSendOn = null)
    {
        var emailMessage = new MimeMessage();
        var bodyBuilder = new BodyBuilder();
        var emailUserName = _options.EmailUserName;
        var emailPassword = _options.EmailPassword;
        var emailHost = _options.EmailHost;

        emailMessage.From.Add(new MailboxAddress("ShoShoppers", emailUserName));
        dynamic emails = emailsToSendOn == null ? await Context.Emails.ToListAsync() : emailsToSendOn;

        using var client = new SmtpClient();
        await client.ConnectAsync(emailHost, 587, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(emailUserName, emailPassword);

        foreach (var email in emails)
        {
            emailMessage.To.Add(new MailboxAddress("To", emails is List<Email> ? email.Mail : email));
            emailMessage.Subject = emailHelper.Subject;
            bodyBuilder.HtmlBody = emailHelper.HtmlBody;
            emailMessage.Body = bodyBuilder.ToMessageBody();
        }

        await client.SendAsync(emailMessage);
        await client.DisconnectAsync(true);
    }

    /// <summary>
    ///     Signing email up on notifications
    /// </summary>
    /// <param name="email">Email which will be signed up</param>
    /// <returns>Returns true if email is signed up, false if email was already signed up</returns>
    public override async ValueTask<Email> AddAsync(Email email)
    {
        string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        Match match = Regex.Match(email.Mail.Trim(), pattern, RegexOptions.IgnoreCase);

        if (match.Success)
        {
            var checkIfEmailAlreadyExists = await IsExistAsync(new EmailFilter { Mail = email.Mail });
            if (checkIfEmailAlreadyExists) return email;

            return await base.AddAsync(email);
        }

        throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Email doesn`t match regex.");
    }

    /// <summary>
    ///     Getting Email entities from database by selecting filter
    /// </summary>
    /// <param name="range">Selected pagination for Email entity</param>
    /// <param name="filter">Selected filter for Email entity</param>
    /// <param name="sort">Selected sorting for Email entity</param>
    /// <returns>Pagination Helper of Email entity</returns>
    public override async ValueTask<PaginationHelper<Email>> GetAsync(string? range = null, string? filter = null,
        string? sort = null)
    {
        var query = Context.Emails.AsQueryable();

        EmailFilter? filterVal = null;

        if (!string.IsNullOrEmpty(filter)) filterVal = JsonConvert.DeserializeObject<EmailFilter>(filter);

        if (filterVal != null)
            query = query.Where(f => !filterVal.Id.HasValue || f.Id == filterVal.Id)
                .Where(f => string.IsNullOrEmpty(filterVal.Mail) ||
                            f.Mail.ToLower().Contains(filterVal.Mail.ToLower()));

        query = SetSorting(query, sort);

        return await SetPaginationAsync(query, query.Count(), range);
    }

    /// <summary>
    ///     Checking existing of the Email entitiy from database by selecting filter
    /// </summary>
    /// <param name="filter">EmailFilter for Email entity</param>
    /// <returns>True if entity exist, false if no</returns>
    public override async Task<bool> IsExistAsync(EmailFilter filter)
    {
        return await Context.Emails.AnyAsync(f => (!filter.Id.HasValue || f.Id == filter.Id)
                                                   && (string.IsNullOrEmpty(filter.Mail) ||
                                                       f.Mail.ToLower().Contains(filter.Mail.ToLower())));
    }

    /// <summary>
    ///     Finding of the Email entitiy from database by selecting filter
    /// </summary>
    /// <param name="filter">EmailFilter for Email entity</param>
    /// <returns>Found Email</returns>
    public override async Task<Email?> FindAsync(EmailFilter filter)
    {
        var query = Context.Emails.AsQueryable();

        if (filter != null)
            query = query.Where(f => !filter.Id.HasValue || f.Id == filter.Id)
                .Where(f => string.IsNullOrEmpty(filter.Mail) || f.Mail.ToLower().Contains(filter.Mail.ToLower()));

        return await query.FirstOrDefaultAsync();
    }
}