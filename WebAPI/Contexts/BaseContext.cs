using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAPI.Entities;

namespace WebAPI.Contexts;

public class BaseContext: DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Attiribute> Attiributes { get; set; }
    public DbSet<AttiributeValue> AttiributeValues { get; set; }

    public BaseContext (DbContextOptions dbContextOptions):base(dbContextOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
