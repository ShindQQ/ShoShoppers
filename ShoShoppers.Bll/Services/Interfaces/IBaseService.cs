using ShoShoppers.Bll.Filters.Base;
using ShoShoppers.Bll.Models.HelperModels;
using ShoShoppers.Dal.Entities.Base;

namespace ShoShoppers.Bll.Services.Interfaces;

/// <summary>
///     Interface which will be inherited for base service
/// </summary>
/// <typeparam name="T1">Represents entity</typeparam>
/// <typeparam name="T2">Represents filter</typeparam>
public interface IBaseService<T1, T2> where T1 : BaseEntity where T2 : BaseFilter
{
    /// <summary>
    ///     Adding entity to the table of database
    /// </summary>
    /// <param name="entity">Entity which will be added with type of T which represents selected Entity type</param>
    /// <returns>Added entity</returns>
    ValueTask<T1> AddAsync(T1 entity);

    /// <summary>
    ///     Updating entity to the table of database
    /// </summary>
    /// <param name="entity">Entity which will be updated with type of T which represents selected Entity type</param>
    /// <returns>Task</returns>
    Task UpdateAsync(T1 entity);

    /// <summary>
    ///     Deleting entity to the table of database
    /// </summary>
    /// <param name="entity">Entity which will be deleted with type of T which represents selected Entity type</param>
    /// <returns>Task</returns>
    Task DeleteAsync(T1 entity);

    /// <summary>
    ///     Getting entities from database by selecting filter options or not
    /// </summary>
    /// <param name="range">Selected pagination for entity</param>
    /// <param name="filter">Selected filter for entity</param>
    /// <param name="sort">Selected sorting for entity</param>
    /// <returns>PaginationHelper</returns>
    ValueTask<PaginationHelper<T1>> GetAsync(string? range = null, string? filter = null, string? sort = null);

    /// <summary>
    ///     Searching for entitiy from database by selecting filter options or not
    /// </summary>
    /// <param name="filter">Selected filter for entity</param>
    /// <returns>Found entity by filter</returns>
    Task<T1?> FindAsync(T2 filter);

    /// <summary>
    ///     Checking existing of the entitiy from database by selecting filter options or not
    /// </summary>
    /// <param name="filter">Selected filter for entity</param>
    /// <returns>True if entity exist, false if no</returns>
    Task<bool> IsExistAsync(T2 filter);

    /// <summary>
    ///     Setting sorting to request
    /// </summary>
    /// <param name="query">Query which will be modified</param>
    /// <param name="sort">Sorting requesr</param>
    /// <returns>Added sorting in query</returns>
    IQueryable<T1> SetSorting(IQueryable<T1> query, string? sort = null);

    /// <summary>
    ///     Setting pagination to request
    /// </summary>
    /// <param name="query">Query which will be modified</param>
    /// <param name="count">Total count of entities in request</param>
    /// <param name="range">Range of pagination</param>
    /// <returns>PaginationHelper</returns>
    ValueTask<PaginationHelper<T1>> SetPaginationAsync(IQueryable<T1> query, int count, string? range = null);
}