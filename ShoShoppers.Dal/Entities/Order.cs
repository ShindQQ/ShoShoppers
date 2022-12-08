using ShoShoppers.Dal.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoShoppers.Dal.Entities;

/// <summary>
///     Class which describes Orders table
/// </summary>
[Table("Orders")]
public sealed class Order : BaseEntity
{
    /// <summary>
    ///     Date when order was done
    /// </summary>
    [Required]
    public DateTime DateOfOrder { get; set; } = DateTime.UtcNow;

    /// <summary>
    ///     Date to which order should be done and delivered
    /// </summary>
    [Required]
    public DateTime DateToFinishOrderAndDiliver { get; set; }

    /// <summary>
    ///     Items which user bought
    /// </summary>
    [Required]
    public string UserItems { get; set; } = string.Empty;

    /// <summary>
    ///     Email of user for notifications
    /// </summary>
    [Required]
    public string UserEmail { get; set; } = string.Empty;

    /// <summary>
    ///     Name of user for delivery
    /// </summary>
    [Required]
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    ///     Surname of user for delivery
    /// </summary>
    [Required]
    public string UserSurname { get; set; } = string.Empty;

    /// <summary>
    ///     Use selected office on which order should be sent
    /// </summary>
    [Required]
    public string PostOffice { get; set; } = string.Empty;

    /// <summary>
    ///     Phone number of user for delivery
    /// </summary>
    [Required]
    public string UserPhoneNumber { get; set; } = string.Empty;

    /// <summary>
    ///     Is order done 
    /// </summary>
    [Required]
    public bool IsOrderDone { get; set; } = false;

    /// <summary>
    ///     Price of the current order
    /// </summary>
    [Required]
    public decimal OrderPrice { get; set; }

    /// <summary>
    ///     Unique user token of the current order
    /// </summary>
    [Required]
    public string UserUniqueToken { get; set; } = string.Empty;

    /// <summary>
    ///     Is user made order
    /// </summary>
    [Required]
    public bool IsOrderMade { get; set; } = false;
}
