using ShoShoppers.Dal.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoShoppers.Dal.Entities;

/// <summary>
///     Class which describes Rewievs table
/// </summary>
[Table("Rewievs")]
public sealed class Review : BaseEntity
{
    /// <summary>
    ///     ImageLink of the current review
    /// </summary>
    [Required]
    public string ImageLink { get; set; } = string.Empty;
}