using ShoShoppers.Bll.Filters;
using ShoShoppers.Dal.Entities.ItemsForSale;

namespace ShoShoppers.Bll.Services.Interfaces;

/// <summary>
///     Interface which represents Pin Service with inherited methods of the Base Service and it`s overriden methods
/// </summary>
public interface IPinService : IBaseService<Pin, PinFilter>
{
}