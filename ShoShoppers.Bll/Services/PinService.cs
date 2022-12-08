using ShoShoppers.Bll.Filters;
using ShoShoppers.Bll.Services.Interfaces;
using ShoShoppers.Dal.Contexts;
using ShoShoppers.Dal.Entities.ItemsForSale;

namespace ShoShoppers.Bll.Services;

/// <summary>
///     Class which represents Pin Service with inherited methods of the Base Service and it`s overriden methods
/// </summary>
public sealed class PinService : BaseItemsForSaleService<Pin, PinFilter>, IPinService
{
    /// <summary>
    ///     Constructor for Pin Service
    /// </summary>
    /// <param name="context">Database context</param>
    public PinService(ShoShoppersContext context) : base(context)
    {
    }
}