using ShoShoppers.Bll.Filters;
using ShoShoppers.Bll.Models.HelperModels;
using ShoShoppers.Dal.Entities;

namespace ShoShoppers.Bll.Services.Interfaces;

/// <summary>
///     Interface which decribes all methods to work with Email Services
/// </summary>
public interface IEMailService : IBaseService<Email, EmailFilter>
{
    /// <summary>
    ///     Sending notifications on signed up emails
    /// </summary>
    /// <param name="emailHelper">The class with subject and body of the email</param>
    /// <param name="emailsToSendOn">The list of emails to send email on</param>
    /// <returns>Task</returns>
    Task SendEmailsAsync(EmailHelper emailHelper, List<string>? emailsToSendOn = null);
}