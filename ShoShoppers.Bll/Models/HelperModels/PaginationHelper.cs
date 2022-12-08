namespace ShoShoppers.Bll.Models.HelperModels;

/// <summary>
///     Helper for setting pagination
/// </summary>
public sealed class PaginationHelper<T> // TODO: add ienumerable of entity
{
    /// <summary>
    ///     Constructor for Pagination Helper
    /// </summary>
    /// <param name="from">Index from which pagination starts</param>
    /// <param name="to">End of pagination</param>
    /// <param name="count">Total count of entities</param>
    /// <param name="entities">Set of entities</param>
    public PaginationHelper(int from, int to, int count, IEnumerable<T> entities)
    {
        From = from;
        To = to;
        Count = count;
        Entities = entities;
    }

    /// <summary>
    ///     Index from which pagination starts
    /// </summary>
    public int From { get; set; }

    /// <summary>
    ///     End of pagination
    /// </summary>
    public int To { get; set; }

    /// <summary>
    ///     Total count of entities
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    ///     Set of entities
    /// </summary>
    public IEnumerable<T> Entities { get; set; }
}