using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoShoppers.Dal.Entities.Base;

/// <summary>
///     Abstract class which will be inherited for future entities
/// </summary>
[Table("BaseEntity")]
public abstract class BaseEntity
{
    /// <summary>
    ///     The id of the entity
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
}