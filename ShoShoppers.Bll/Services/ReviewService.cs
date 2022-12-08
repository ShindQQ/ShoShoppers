using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShoShoppers.Bll.Filters;
using ShoShoppers.Bll.Models.HelperModels;
using ShoShoppers.Bll.Services.Interfaces;
using ShoShoppers.Dal.Contexts;
using ShoShoppers.Dal.Entities;

namespace ShoShoppers.Bll.Services;

/// <summary>
///     Class which represents Review Service with inherited methods of the Base Service and it`s overriden methods
/// </summary>
public sealed class ReviewService : BaseService<Review, ReviewFilter>, IReviewService
{
    /// <summary>
    ///     Constructor for Review Service
    /// </summary>
    /// <param name="context">Database context</param>
    public ReviewService(ShoShoppersContext context) : base(context)
    {
    }

    /// <summary>
    ///     Getting Review entities from database by selecting filter
    /// </summary>
    /// <param name="range">Selected pagination for Review entity</param>
    /// <param name="filter">Selected filter for Review entity</param>
    /// <param name="sort">Selected sorting for Review entity</param>
    /// <returns>Pagination Helper of Review entity</returns>
    public override async ValueTask<PaginationHelper<Review>> GetAsync(string? range = null, string? filter = null,
        string? sort = null)
    {
        var query = Context.Reviews.AsQueryable();

        ReviewFilter? filterVal = null;

        if (!string.IsNullOrEmpty(filter)) filterVal = JsonConvert.DeserializeObject<ReviewFilter>(filter);

        if (filterVal != null) query = query.Where(f => !filterVal.Id.HasValue || f.Id == filterVal.Id);

        query = SetSorting(query, sort);

        return await SetPaginationAsync(query, query.Count(), range);
    }


    /// <summary>
    ///     Checking existing of the Review entity from database by selecting filter
    /// </summary>
    /// <param name="filter">ReviewFilter for Review entity</param>
    /// <returns>True if entity exist, false if no</returns>
    public override async Task<bool> IsExistAsync(ReviewFilter filter)
    {
        return await Context.Reviews.AnyAsync(f => !filter.Id.HasValue || f.Id.Equals(filter.Id));
    }

    /// <summary>
    ///     Finding of the Review entity from database by selecting filter
    /// </summary>
    /// <param name="filter">ReviewFilter for Review entity</param>
    /// <returns>Found review</returns>
    public override async Task<Review?> FindAsync(ReviewFilter filter)
    {
        var query = Context.Reviews.AsQueryable();

        if (filter != null) query = query.Where(f => !filter.Id.HasValue || f.Id.Equals(filter.Id));

        return await query.FirstOrDefaultAsync();
    }
}