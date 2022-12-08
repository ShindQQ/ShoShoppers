using AutoMapper;
using ShoShoppers.Bll.Models;
using ShoShoppers.Dal.Entities.ItemsForSale;

namespace ShoShoppers.Bll.Profiles;

/// <summary>
///     IndividualDesigns Profile for Automapper
/// </summary>
public sealed class IndividualDesignsProfile : Profile
{
    /// <summary>
    ///     Constructor for profiler
    /// </summary>
    public IndividualDesignsProfile()
    {
        CreateMap<IndividualDesign, IndividualDesignDto>().ReverseMap();
        CreateMap<IndividualDesign, IndividualDesignDto>();
        CreateMap<IndividualDesignDto, IndividualDesign>();
    }
}