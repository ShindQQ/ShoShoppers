using AutoMapper;
using ShoShoppers.Bll.Models;
using ShoShoppers.Dal.Entities;

namespace ShoShoppers.Bll.Profiles;

/// <summary>
///     Reviews Profile for Automapper
/// </summary>
public sealed class ReviewsProfile : Profile
{
    /// <summary>
    ///     Constructor for profiler
    /// </summary>
    public ReviewsProfile()
    {
        CreateMap<Review, ReviewDto>().ReverseMap();
        CreateMap<Review, ReviewDto>();
        CreateMap<ReviewDto, Review>();
    }
}