using ShoShoppers.Bll.Filters.Base;

namespace ShoShoppers.Bll.Filters;

/// <summary>
///     Class to work with filtration of orders
/// </summary>
public sealed class OrderFilter : BaseFilter
{
    /// <summary>
    ///     Date when order was done
    /// </summary>
    public DateTime? DateOfOrder { get; set; }

    /// <summary>
    ///     Date to which order should be done and delivered
    /// </summary>
    public DateTime? DateToFinishOrderAndDiliver { get; set; }

    /// <summary>
    ///     Items which user bought
    /// </summary>
    public string UserItems { get; set; } = string.Empty;

    /// <summary>
    ///     Email of user for notifications
    /// </summary>
    public string USerEmail { get; set; } = string.Empty;

    /// <summary>
    ///     Name of user for delivery
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    ///     Surname of user for delivery
    /// </summary>
    public string UserSurname { get; set; } = string.Empty;

    /// <summary>
    ///     Use selected office on which order should be sent
    /// </summary>
    public string PostOffice { get; set; } = string.Empty;

    /// <summary>
    ///     Phone number of user for delivery
    /// </summary>
    public string UserPhoneNumber { get; set; } = string.Empty;

    /// <summary>
    ///     Is order done 
    /// </summary>
    public bool? IsOrderDone { get; set; }

    /// <summary>
    ///     Price of the current order
    /// </summary>
    public decimal? OrderPrice { get; set; }

    /// <summary>
    ///     Unique user token of the current order
    /// </summary>
    public string UserUniqueToken { get; set; } = string.Empty;

    /// <summary>
    ///     Is user made order
    /// </summary>
    public bool? IsOrderMade { get; set; }
}
