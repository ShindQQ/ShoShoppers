using AutoMapper;
using ShoShoppers.Bll.Models.Orders;
using ShoShoppers.Dal.Entities;

namespace ShoShoppers.Bll.Profiles;

/// <summary>
///     Orders Profile for Automapper
/// </summary>
public sealed class OrdersProfile : Profile
{
    /// <summary>
    ///     Constructor for profiler
    /// </summary>
    public OrdersProfile()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<Order, OrderDto>();
        CreateMap<OrderDto, Order>().ForMember(dest => dest.UserItems, m => m.MapFrom(src => src.ToString()));
    }
}
