using System.ComponentModel.DataAnnotations;

namespace ShoShoppers.Bll.Models.HelperModels;

/// <summary>
///     Class which contains email subject and body
/// </summary>
public sealed class EmailHelper
{
    /// <summary>
    ///     Subject of the email
    /// </summary>
    [Required]
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    ///     Body of the email
    /// </summary>
    [Required]
    public string HtmlBody { get; set; } = string.Empty;
}