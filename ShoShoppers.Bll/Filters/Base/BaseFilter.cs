namespace ShoShoppers.Bll.Filters.Base;

/// <summary>
///     Abstract class which will be inherited for future filters
/// </summary>
public abstract class BaseFilter
{
    /// <summary>
    ///     The id of the filter class
    /// </summary>
    public long? Id { get; set; }
}