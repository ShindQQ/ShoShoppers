using ShoShoppers.Bll.Filters;
using ShoShoppers.Dal.Entities.ItemsForSale;

namespace ShoShoppers.Bll.Services.Interfaces;

/// <summary>
///     Interface which represents Shopper Service with inherited methods of the Base Service and it`s overriden methods
/// </summary>
public interface IShopperService : IBaseService<Shopper, ShopperFilter>
{
}