using ShoShoppers.Bll.Models.Base;

namespace ShoShoppers.Bll.Models;

/// <summary>
///     Class which discribes subscriber on notifications in database
/// </summary>
public sealed class SubscriberDto : BaseModel
{
    /// <summary>
    ///     Email of the subscriber
    /// </summary>
    //[EmailAddress]
    public string Mail { get; set; } = string.Empty;
}