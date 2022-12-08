namespace ShoShoppers.Bll.Models.Orders;

/// <summary>
///     Class which discribes items of user: it`s name and ammount
/// </summary>
public sealed class OrderUserItemDto
{
    /// <summary>
    ///     Id of the item in db
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Ammount of the item in cart
    /// </summary>
    public int Ammount { get; set; }

    /// <summary>
    ///     Name of item in cart
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Concatenating item ammount and name
    /// </summary>
    /// <returns>item ammount x item name</returns>
    public override string ToString()
    {
        return Ammount.ToString() + " x " + Name;
    }
}
