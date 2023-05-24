using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using SimApi.Data.Domain;

namespace SimApi.Data.Context;

public class SimDbContext : DbContext
{
    public SimDbContext(DbContextOptions<SimDbContext> options) : base(options)
    {

    }
    
   
    public DbSet<staff> staff { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        

        builder.Entity<staff>().HasIndex(x => x.Email).IsUnique(true);
        builder.Entity<Category>().HasMany(x => x.products).WithOne(x => x.category).HasForeignKey(x => x.categoryId).OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(builder);

    }
}
