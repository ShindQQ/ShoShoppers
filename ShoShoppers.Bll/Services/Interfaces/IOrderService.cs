using ShoShoppers.Bll.Filters;
using ShoShoppers.Bll.Models.Orders;
using ShoShoppers.Dal.Entities;

namespace ShoShoppers.Bll.Services.Interfaces;

/// <summary>
///     Interface which decribes all methods to work with Order Services
/// </summary>
public interface IOrderService : IBaseService<Order, OrderFilter>
{
    /// <summary>
    ///     Generating unique token for user
    /// </summary>
    /// <returns>New guid to string</returns>
    ValueTask<string> GenerateUserUniqueTokenAsync();

    /// <summary>
    ///     Updating order by user token
    /// </summary>
    /// <param name="entity">Entity with token</param>
    /// <returns>null if entity does not exists and entity if it exists</returns>
    ValueTask<Order> CreateOrderAsync(Order entity);

    /// <summary>
    ///     Updating pins and shoppers tables 
    /// </summary>
    /// <param name="order">Order`s user items</param>
    /// <returns>Task</returns>
    Task UpdatePinsAndShoppersAmmountAsync(OrderDto order);
}
