using AutoMapper;
using ShoShoppers.Bll.Models;
using ShoShoppers.Dal.Entities;

namespace ShoShoppers.Bll.Profiles;

/// <summary>
///     Emails Profile for Automapper
/// </summary>
public sealed class EmailsProfile : Profile
{
    /// <summary>
    ///     Constructor for profiler
    /// </summary>
    public EmailsProfile()
    {
        CreateMap<Email, SubscriberDto>().ReverseMap();
        CreateMap<Email, SubscriberDto>();
        CreateMap<SubscriberDto, Email>();
    }
}