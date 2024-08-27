using EventsBookingBackend.Domain.Review.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsBookingBackend.Infrastructure.EntityFramework.DbContexts;

public class ReviewDbContext(DbContextOptions<ReviewDbContext> options) : BaseDbContext<ReviewDbContext>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("reviews");
    }

    public DbSet<Review> Reviews { get; set; }
}