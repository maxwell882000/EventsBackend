using EventsBookingBackend.Domain.Auth.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventsBookingBackend.Infrastructure.EntityFramework.DbContexts;

public class AuthDbContext : IdentityDbContext<Auth>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }
}