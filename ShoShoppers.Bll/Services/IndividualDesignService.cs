using ShoShoppers.Bll.Filters;
using ShoShoppers.Bll.Services.Interfaces;
using ShoShoppers.Dal.Contexts;
using ShoShoppers.Dal.Entities.ItemsForSale;

namespace ShoShoppers.Bll.Services;

/// <summary>
///     Class which represents Individual Design Service with inherited methods of the Base Service and it`s overriden
///     methods
/// </summary>
public sealed class IndividualDesignService : BaseItemsForSaleService<IndividualDesign, IndividualDesignFilter>,
    IIndividualDesignService
{
    /// <summary>
    ///     Constructor for IndividualDesign Service
    /// </summary>
    /// <param name="context">Database context</param>
    public IndividualDesignService(ShoShoppersContext context) : base(context)
    {
    }
}