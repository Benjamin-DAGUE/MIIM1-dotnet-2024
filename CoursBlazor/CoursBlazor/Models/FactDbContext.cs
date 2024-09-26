using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CoursBlazor.Models;

public class FactDbContext : DbContext
{
    #region Properties

    public DbSet<Fact> Facts { get; set; }

    #endregion

    #region Constructors

    public FactDbContext()
    {
        
    }

    public FactDbContext(DbContextOptions options) 
        : base(options)
    {
            
    }

    #endregion

    #region Methods

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Fact>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Data).HasMaxLength(500);
        });
    }

    #endregion

}
