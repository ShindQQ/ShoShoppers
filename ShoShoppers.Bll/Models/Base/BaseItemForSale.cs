namespace ShoShoppers.Bll.Models.Base;

/// <summary>
///     Class for items for sale
/// </summary>
public abstract class BaseItemForSale : BaseModel
{
    /// <summary>
    ///     The name of the item
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Description of the item
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     Price of the item
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    ///     Image of the item
    /// </summary>
    public string ImageLink { get; set; } = string.Empty;

    /// <summary>
    ///     Color of the item
    /// </summary>
    public string Color { get; set; } = string.Empty;

    /// <summary>
    ///     Color of the image on the item
    /// </summary>
    public string ImageColor { get; set; } = string.Empty;

    /// <summary>
    ///     Ammount of the items
    /// </summary>
    public int ItemAmmount { get; set; }

    /// <summary>
    ///     Needs an item production or not
    /// </summary>
    public bool ItemInProduction { get; set; }
}