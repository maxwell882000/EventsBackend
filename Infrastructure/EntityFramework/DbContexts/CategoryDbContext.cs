using EventsBookingBackend.Domain.Category.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsBookingBackend.Infrastructure.EntityFramework.DbContexts;

public class CategoryDbContext(DbContextOptions<CategoryDbContext> options)  : BaseDbContext<CategoryDbContext>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("categories");
    }

    public DbSet<Category> Categories { get; init; }
}