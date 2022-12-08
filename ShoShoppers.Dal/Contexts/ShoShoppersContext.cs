using Microsoft.EntityFrameworkCore;
using ShoShoppers.Dal.Entities;
using ShoShoppers.Dal.Entities.Base;
using ShoShoppers.Dal.Entities.ItemsForSale;

namespace ShoShoppers.Dal.Contexts;

/// <summary>
///     Class which represents database context to work with it
/// </summary>
public sealed class ShoShoppersContext : DbContext
{
    /// <summary>
    ///     Context class constructor
    /// </summary>
    /// <param name="options">Param to configure database context</param>
    public ShoShoppersContext(DbContextOptions<ShoShoppersContext> options) : base(options)
    {
    }

    /// <summary>
    ///     DbSet for Base Entity
    /// </summary>
    public DbSet<BaseEntity> BaseEntities { get; set; } = null!;

    /// <summary>
    ///     DbSet for Base Entity For Sale
    /// </summary>
    public DbSet<BaseEntityForSale> BaseEntityForSales { get; set; } = null!;

    /// <summary>
    ///     DbSet for Emails table
    /// </summary>
    public DbSet<Email> Emails { get; set; } = null!;

    /// <summary>
    ///     DbSet for Pins table
    /// </summary>
    public DbSet<Pin> Pins { get; set; } = null!;

    /// <summary>
    ///     DbSet for Shopers table
    /// </summary>
    public DbSet<Shopper> Shopers { get; set; } = null!;

    /// <summary>
    ///     DbSet for IndividualDesigns table
    /// </summary>
    public DbSet<IndividualDesign> IndividualDesigns { get; set; } = null!;

    /// <summary>
    ///     DbSet for Reviews table
    /// </summary>
    public DbSet<Review> Reviews { get; set; } = null!;

    /// <summary>
    ///     DbSet for Orders table
    /// </summary>
    public DbSet<Order> Orders { get; set; } = null!;
}