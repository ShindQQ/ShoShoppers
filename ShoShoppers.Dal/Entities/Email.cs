using ShoShoppers.Dal.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoShoppers.Dal.Entities;

/// <summary>
///     Class which describes Emails table
/// </summary>
[Table("Emails")]
public sealed class Email : BaseEntity
{
    /// <summary>
    ///     Email of the subscriber
    /// </summary>
    [Required]
    public string Mail { get; set; } = string.Empty;
}