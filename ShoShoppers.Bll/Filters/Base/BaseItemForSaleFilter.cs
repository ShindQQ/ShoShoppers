namespace ShoShoppers.Bll.Filters.Base;

/// <summary>
///     Abstract class which will be inherited for future filters
/// </summary>
public abstract class BaseItemForSaleFilter : BaseFilter
{
    /// <summary>
    ///     Name of the item on which the action will be performed
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Description of the item on which the action will be performed
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     Price of the item on which the action will be performed
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    ///     Color of the item on which the action will be performed
    /// </summary>
    public string Color { get; set; } = string.Empty;

    /// <summary>
    ///     Color of the image on the item on which the action will be performed
    /// </summary>
    public string ImageColor { get; set; } = string.Empty;

    /// <summary>
    ///     Ammount of the items on which the action will be performed
    /// </summary>
    public int? ItemAmmount { get; set; }

    /// <summary>
    ///     Needs an item production or not on which the action will be performed
    /// </summary>
    public bool? ItemInProduction { get; set; }
}