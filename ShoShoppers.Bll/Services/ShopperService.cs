using ShoShoppers.Bll.Filters;
using ShoShoppers.Bll.Services.Interfaces;
using ShoShoppers.Dal.Contexts;
using ShoShoppers.Dal.Entities.ItemsForSale;

namespace ShoShoppers.Bll.Services;

/// <summary>
///     Class which represents Shopper Service with inherited methods of the Base Service and it`s overriden methods
/// </summary>
public sealed class ShopperService : BaseItemsForSaleService<Shopper, ShopperFilter>, IShopperService
{
    /// <summary>
    ///     Constructor for Shopper Service
    /// </summary>
    /// <param name="context">Database context</param>
    public ShopperService(ShoShoppersContext context) : base(context)
    {
    }
}