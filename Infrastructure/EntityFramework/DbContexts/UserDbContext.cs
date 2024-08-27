using EventsBookingBackend.Domain.User.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsBookingBackend.Infrastructure.EntityFramework.DbContexts;

public class UserDbContext(DbContextOptions<UserDbContext> options) : BaseDbContext<UserDbContext>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("users");
    }

    public DbSet<User> Users { get; set; }
}