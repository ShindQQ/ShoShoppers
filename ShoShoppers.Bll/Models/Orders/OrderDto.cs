using ShoShoppers.Bll.Models.Base;

namespace ShoShoppers.Bll.Models.Orders;

/// <summary>
///     Class which discribes order in database
/// </summary>
public sealed class OrderDto : BaseModel
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
    public List<OrderUserItemDto> UserItems { get; set; } = null!;

    /// <summary>
    ///     Email of user for notifications
    /// </summary>
    public string UserEmail { get; set; } = string.Empty;

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
    ///     Concatinating all items of user in string
    /// </summary>
    /// <returns>item ammount x item name, item ammount x item name, ...</returns>
    public override string ToString()
    {
        return string.Join(", ", UserItems.Select(item => item.ToString()));
    }
}
