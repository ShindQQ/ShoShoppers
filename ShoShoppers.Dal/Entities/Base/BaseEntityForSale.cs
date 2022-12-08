using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoShoppers.Dal.Entities.Base;

/// <summary>
///     Base entity class for sale
/// </summary>
[Table("BaseEntityForSale")]
public abstract class BaseEntityForSale : BaseEntity
{
    /// <summary>
    ///     Name of the current pin
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Description of the current pin
    /// </summary>
    [Required]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     Price of the current pin
    /// </summary>
    [Required]
    public decimal Price { get; set; }

    /// <summary>
    ///     ImageLink of the current pin
    /// </summary>
    [Required]
    public string ImageLink { get; set; } = string.Empty;

    /// <summary>
    ///     Color of the item
    /// </summary>
    [Required]
    public string Color { get; set; } = string.Empty;

    /// <summary>
    ///     Color of the image on the item
    /// </summary>
    [Required]
    public string ImageColor { get; set; } = string.Empty;

    /// <summary>
    ///     Ammount of the items
    /// </summary>
    [Required]
    public int ItemAmmount { get; set; }

    /// <summary>
    ///     Needs an item production or not
    /// </summary>
    [Required]
    public bool ItemInProduction { get; set; }
}