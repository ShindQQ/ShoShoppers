using AutoMapper;
using ShoShoppers.Bll.Models;
using ShoShoppers.Dal.Entities.ItemsForSale;

namespace ShoShoppers.Bll.Profiles;

/// <summary>
///     Pins Profile for Automapper
/// </summary>
public sealed class PinsProfile : Profile
{
    /// <summary>
    ///     Constructor for profiler
    /// </summary>
    public PinsProfile()
    {
        CreateMap<Pin, PinDto>().ReverseMap();
        CreateMap<Pin, PinDto>();
        CreateMap<PinDto, Pin>();
    }
}