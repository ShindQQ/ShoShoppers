using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShoShoppers.Bll.Filters.Base;
using ShoShoppers.Bll.Models.HelperModels;
using ShoShoppers.Bll.Services.Interfaces;
using ShoShoppers.Dal.Contexts;
using ShoShoppers.Dal.Entities.Base;

namespace ShoShoppers.Bll.Services;

/// <summary>
///     Abstract class which will be inherited for base items for sale services
/// </summary>
/// <typeparam name="T1">Represents entity</typeparam>
/// <typeparam name="T2">Represents filter</typeparam>
public abstract class BaseItemsForSaleService<T1, T2> : BaseService<T1, T2>, IBaseService<T1, T2>
    where T1 : BaseEntityForSale where T2 : BaseItemForSaleFilter
{
    /// <summary>
    ///     Constructor for services
    /// </summary>
    /// <param name="context">Database context</param>
    protected BaseItemsForSaleService(ShoShoppersContext context) : base(context)
    {
    }

    /// <summary>
    ///     Getting entities from database by selecting filter
    /// </summary>
    /// <param name="range">Selected pagination for the entity</param>
    /// <param name="filter">Selected filter for the entity</param>
    /// <param name="sort">Selected sorting for the entity</param>
    /// <returns>Pagination Helper of the entity</returns>
    public override async ValueTask<PaginationHelper<T1>> GetAsync(string? range = null, string? filter = null,
        string? sort = null)
    {
        var query = Context.Set<T1>().AsQueryable();

        T2? filterVal = null;

        if (!string.IsNullOrEmpty(filter)) filterVal = JsonConvert.DeserializeObject<T2>(filter);

        if (filterVal != null)
            query = query.Where(f => !filterVal.Id.HasValue || f.Id == filterVal.Id)
                .Where(f => !filterVal.Price.HasValue || f.Price == filterVal.Price)
                .Where(f => string.IsNullOrEmpty(filterVal.Name) || f.Name.ToLower().Contains(filterVal.Name.ToLower()))
                .Where(f => string.IsNullOrEmpty(filterVal.Description) ||
                            f.Description.ToLower().Contains(filterVal.Description.ToLower()))
                .Where(f => string.IsNullOrEmpty(filterVal.Color) ||
                            f.Color.ToLower().Contains(filterVal.Color.ToLower()))
                .Where(f => string.IsNullOrEmpty(filterVal.ImageColor) ||
                            f.ImageColor.ToLower().Contains(filterVal.ImageColor.ToLower()))
                .Where(f => !filterVal.ItemAmmount.HasValue || f.ItemAmmount == filterVal.ItemAmmount)
                .Where(f => !filterVal.ItemInProduction.HasValue || f.ItemInProduction == filterVal.ItemInProduction);

        query = SetSorting(query, sort);

        return await SetPaginationAsync(query, query.Count(), range);
    }

    /// <summary>
    ///     Checking existing of the entitiy from database by selecting filter
    /// </summary>
    /// <param name="filter">Filter for the entity</param>
    /// <returns>True if entity exist, false if no</returns>
    public override async Task<bool> IsExistAsync(T2 filter)
    {
        return await Context.Set<T1>().AnyAsync(f => (!filter.Id.HasValue || f.Id == filter.Id)
                                                      && (!filter.Price.HasValue || f.Price == filter.Price)
                                                      && (string.IsNullOrEmpty(filter.Name) ||
                                                          f.Name.ToLower().Contains(filter.Name.ToLower()))
                                                      && (string.IsNullOrEmpty(filter.Description) ||
                                                          f.Description.ToLower()
                                                              .Contains(filter.Description.ToLower()))
                                                      && (string.IsNullOrEmpty(filter.Color) || f.Description.ToLower()
                                                          .Contains(filter.Color.ToLower()))
                                                      && (string.IsNullOrEmpty(filter.ImageColor) ||
                                                          f.Description.ToLower()
                                                              .Contains(filter.ImageColor.ToLower()))
                                                      && (!filter.ItemAmmount.HasValue ||
                                                          f.ItemAmmount == filter.ItemAmmount)
                                                      && (!filter.ItemInProduction.HasValue ||
                                                          f.ItemInProduction == filter.ItemInProduction));
    }

    /// <summary>
    ///     Searching of the entitiy from database by selecting filter
    /// </summary>
    /// <param name="filter">Filter for the entity</param>
    /// <returns>Found entity</returns>
    public override async Task<T1?> FindAsync(T2 filter)
    {
        var query = Context.Set<T1>().AsQueryable();

        if (filter != null)
            query = query.Where(f => !filter.Id.HasValue || f.Id == filter.Id)
                .Where(f => !filter.Price.HasValue || f.Price == filter.Price)
                .Where(f => string.IsNullOrEmpty(filter.Name) || f.Name.ToLower().Contains(filter.Name.ToLower()))
                .Where(f => string.IsNullOrEmpty(filter.Description) ||
                            f.Description.ToLower().Contains(filter.Description.ToLower()))
                .Where(f => string.IsNullOrEmpty(filter.Color) || f.Color.ToLower().Contains(filter.Color.ToLower()))
                .Where(f => string.IsNullOrEmpty(filter.ImageColor) ||
                            f.ImageColor.ToLower().Contains(filter.ImageColor.ToLower()))
                .Where(f => !filter.ItemAmmount.HasValue || f.ItemAmmount == filter.ItemAmmount)
                .Where(f => !filter.ItemInProduction.HasValue || f.ItemInProduction == filter.ItemInProduction);

        return await query.FirstOrDefaultAsync();
    }
}