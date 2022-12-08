using ShoShoppers.Bll.Filters;
using ShoShoppers.Dal.Entities.ItemsForSale;

namespace ShoShoppers.Bll.Services.Interfaces;

/// <summary>
///     Interface which represents Individual Design Service with inherited methods of the Base Service and it`s overriden
///     methods
/// </summary>
public interface IIndividualDesignService : IBaseService<IndividualDesign, IndividualDesignFilter>
{
}