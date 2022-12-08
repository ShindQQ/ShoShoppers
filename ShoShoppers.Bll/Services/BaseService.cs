using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShoShoppers.Bll.Filters.Base;
using ShoShoppers.Bll.Models.HelperModels;
using ShoShoppers.Bll.Services.Interfaces;
using ShoShoppers.Dal.Contexts;
using ShoShoppers.Dal.Entities.Base;
using System.Linq.Dynamic.Core;

namespace ShoShoppers.Bll.Services;

/// <summary>
///     Abstract class which will be inherited for base service
/// </summary>
/// <typeparam name="T1">Represents entity</typeparam>
/// <typeparam name="T2">Represents filter</typeparam>
public abstract class BaseService<T1, T2> : IBaseService<T1, T2> where T1 : BaseEntity where T2 : BaseFilter
{
    /// <summary>
    ///     Database context
    /// </summary>
    protected readonly ShoShoppersContext Context;

    /// <summary>
    ///     Constructor for services
    /// </summary>
    /// <param name="context">Database context</param>
    protected BaseService(ShoShoppersContext context)
    {
        Context = context;
    }

    /// <summary>
    ///     Adding entity to the table of database
    /// </summary>
    /// <param name="entity">Entity which will be added with type of T which represents selected Entity type</param>
    /// <returns>Added entity</returns>
    public virtual async ValueTask<T1> AddAsync(T1 entity)
    {
        await Context.Set<T1>().AddAsync(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    /// <summary>
    ///     Updating entity to the table of database
    /// </summary>
    /// <param name="entity">Entity which will be updated with type of T which represents selected Entity type</param>
    /// <returns>Task</returns>
    public virtual async Task UpdateAsync(T1 entity)
    {
        Context.Set<T1>().Update(entity);
        await Context.SaveChangesAsync();
    }

    /// <summary>
    ///     Deleting entity to the table of database
    /// </summary>
    /// <param name="entity">Entity which will be deleted with type of T which represents selected Entity type</param>
    /// <returns>Task</returns>
    public virtual async Task DeleteAsync(T1 entity)
    {
        Context.Set<T1>().Remove(entity);
        await Context.SaveChangesAsync();
    }

    /// <summary>
    ///     Getting entities from database by selecting filter options or not
    /// </summary>
    /// <param name="range">Selected pagination for entity</param>
    /// <param name="filter">Selected filter for entity</param>
    /// <param name="sort">Selected sorting for entity</param>
    /// <returns>PaginationHelper</returns>
    public virtual async ValueTask<PaginationHelper<T1>> GetAsync(string? range = null, string? filter = null,
        string? sort = null)
    {
        var query = await Context.Set<T1>().ToListAsync();

        return new PaginationHelper<T1>(0, 0, query.Count, query);
    }

    /// <summary>
    ///     Searching for entitiy from database by selecting filter options or not
    /// </summary>
    /// <param name="filter">Selected filter for entity</param>
    /// <returns>Found entity by filter</returns>
    public virtual async Task<T1?> FindAsync(T2 filter)
    {
        return await Context.Set<T1>().FirstOrDefaultAsync();
    }

    ///     Checking existing of the entitiy from database by selecting filter options or not
    /// </summary>
    /// <param name="filter">Selected filter for entity</param>
    /// <returns>True if entity exist, false if no</returns>
    public virtual async Task<bool> IsExistAsync(T2 filter)
    {
        return await Context.Set<T1>().AnyAsync();
    }

    /// <summary>
    ///     Setting sorting to request
    /// </summary>
    /// <param name="query">Query which will be modified</param>
    /// <param name="sort">Sorting requesr</param>
    /// <returns>Added sorting in query</returns>
    public IQueryable<T1> SetSorting(IQueryable<T1> query, string? sort = null)
    {
        if (!string.IsNullOrEmpty(sort))
        {
            var sortVal = JsonConvert.DeserializeObject<List<string>>(sort);
            var condition = sortVal?.First();
            var order = sortVal?.Last() == "ASC" ? "" : "DESC";
            query = query.OrderBy($"{condition} {order}");
        }

        return query;
    }

    /// <summary>
    ///     Setting pagination to request
    /// </summary>
    /// <param name="query">Query which will be modified</param>
    /// <param name="count">Total count of entities in request</param>
    /// <param name="range">Range of pagination</param>
    /// <returns>PaginationHelper and splitted query</returns>
    public async ValueTask<PaginationHelper<T1>> SetPaginationAsync(IQueryable<T1> query, int count, string? range = null)
    {
        var from = 0;
        var to = 0;

        if (!string.IsNullOrEmpty(range))
        {
            var rangeVal = JsonConvert.DeserializeObject<List<int>>(range);
            from = rangeVal.First();
            to = rangeVal.Last();
            query = query.Skip(from).Take(to - from + 1);
        }

        return new PaginationHelper<T1>(from, to, count, await query.ToListAsync());
    }
}