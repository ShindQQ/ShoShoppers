using ShoShoppers.Bll.Filters.Base;

namespace ShoShoppers.Bll.Filters;

/// <summary>
///     Class to work with filtration of email
/// </summary>
public sealed class EmailFilter : BaseFilter
{
    /// <summary>
    ///     Email of the subscriber
    /// </summary>
    public string Mail { get; set; } = string.Empty;
}