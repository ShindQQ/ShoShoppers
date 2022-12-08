using ShoShoppers.Bll.Filters;
using ShoShoppers.Dal.Entities;

namespace ShoShoppers.Bll.Services.Interfaces;

/// <summary>
///     Interface which represents Review Service with inherited methods of the Base Service and it`s overriden methods
/// </summary>
public interface IReviewService : IBaseService<Review, ReviewFilter>
{
}