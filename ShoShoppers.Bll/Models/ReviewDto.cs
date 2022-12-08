using ShoShoppers.Bll.Models.Base;

namespace ShoShoppers.Bll.Models;

/// <summary>
///     Class which describes review in the database
/// </summary>
public sealed class ReviewDto : BaseModel
{
    /// <summary>
    ///     Image of the review
    /// </summary>
    public string ImageLink { get; set; } = string.Empty;
}