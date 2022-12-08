namespace ShoShoppers.Bll.Models.Base;

/// <summary>
///     Abstract class which will be inherited for future models with id
/// </summary>
public abstract class BaseModel
{
    /// <summary>
    ///     The id of the model
    /// </summary>
    public long Id { get; set; }
}