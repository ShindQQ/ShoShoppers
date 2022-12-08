using AutoMapper;
using ShoShoppers.Bll.Models;
using ShoShoppers.Dal.Entities.ItemsForSale;

namespace ShoShoppers.Bll.Profiles;

/// <summary>
///     Shoppers Profile for Automapper
/// </summary>
public sealed class ShoppersProfile : Profile
{
    /// <summary>
    ///     Constructor for profiler
    /// </summary>
    public ShoppersProfile()
    {
        CreateMap<Shopper, ShopperDto>().ReverseMap();
        CreateMap<Shopper, ShopperDto>();
        CreateMap<ShopperDto, Shopper>();
    }
}