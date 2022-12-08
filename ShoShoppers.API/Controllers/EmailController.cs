using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoShoppers.Bll.Filters;
using ShoShoppers.Bll.Models;
using ShoShoppers.Bll.Models.HelperModels;
using ShoShoppers.Bll.Services.Interfaces;
using ShoShoppers.Dal.Entities;
using System.ComponentModel.DataAnnotations;

namespace ShoShoppers.Api.Controllers;

/// <summary>
///     Controller to sign emails on notifications, sending emails, getting emails by id if needed
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
[Produces("application/json")]
public class EmailController : ControllerBase
{
    /// <summary>
    ///     Service for Email logic
    /// </summary>
    private readonly IEMailService _emailService;

    /// <summary>
    ///     Mapping Email entites
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    ///     Constructor for Email controller
    /// </summary>
    /// <param name="emailService">Email service provider</param>
    /// <param name="mapper">Varialble for mapping entities DTO`s</param>
    public EmailController(IEMailService emailService, IMapper mapper)
    {
        _emailService = emailService;
        _mapper = mapper;
    }

    /// <summary>
    ///     Signing email up on notifications
    /// </summary>
    /// <param name="subscriberDTO">Email which will be signed up</param>
    /// <returns>An ActionResult</returns>
    /// <status code="200">Returns that email was succesfully signed up</status>
    /// <status code="201">Returns that email was succesfully added to db</status>
    /// <status code="400">Returns that such email doesn`t match regex</status>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignEmailUpAsync([Required] SubscriberDto subscriberDTO)
    {
        var emailCreated = await _emailService.AddAsync(_mapper.Map<Email>(subscriberDTO));

        return CreatedAtRoute("GetEmail", new { emailCreated.Id, emailCreated.Mail }, emailCreated);
    }

    /// <summary>
    ///     Senging notifications to all signed up emails
    /// </summary>
    /// <param name="emailHelper">Class which contains email subject and body</param>
    /// <returns>An ActionResult</returns>
    /// <status code="200">Emails were succesfully sent</status>
    [HttpPost("SendEmails")]
    public async Task<IActionResult> SendEmailsAsync(EmailHelper emailHelper)
    {
        await _emailService.SendEmailsAsync(emailHelper);

        return Ok();
    }

    /// <summary>
    ///     Receiving list of all subscribed emails
    /// </summary>
    /// <param name="range">Selected pagination Email Pin entity</param>
    /// <param name="filter">Selected filter for Email entity</param>
    /// <param name="sort">Selected sorting for Email entity</param>
    /// <returns>List of SubscriberDto`s</returns>
    /// <status code="200">List received</status>
    /// <status code="400">List is empty</status>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetSubcribedEmailsAsync(string? range = null, string? filter = null,
        string? sort = null)
    {
        var paginationHelper = await _emailService.GetAsync(range, filter, sort);

        if (paginationHelper.Entities == null) return BadRequest();

        Response.Headers.Add("Access-Control-Expose-Headers", "Content-Range");
        Response.Headers.Add("Content-Range",
            $"{typeof(Email).Name.ToLower()} {paginationHelper.From}-{paginationHelper.To}/{paginationHelper.Count}");

        return Ok(paginationHelper.Entities);
    }

    /// <summary>
    ///     Receiving subsrciber`s email by it`s id
    /// </summary>
    /// <param name="id">Id of the subscriber</param>
    /// <returns>Subscriber`s email</returns>
    /// <status code="200">Email received</status>
    /// <status code="404">Email not found</status>
    [HttpGet("{id}", Name = "GetEmail")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSubcribedEmailAsync([Required] long id)
    {
        var emailFromRepo = await _emailService.FindAsync(new EmailFilter { Id = id });

        if (emailFromRepo == null) return NotFound();

        return Ok(emailFromRepo);
    }

    /// <summary>
    ///     Unsubscribe subsribed email
    /// </summary>
    /// <param name="id">Email which will be unsubsribed</param>
    /// <returns>An ActionResult</returns>
    /// <status code="200">Email unsubscribed</status>
    /// <status code="404">Email not found</status>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UnsubscribeEmailAsync([Required] long id)
    {
        var emailForDelete = new Email { Id = id };

        await _emailService.DeleteAsync(emailForDelete);

        return Ok(emailForDelete);
    }
}