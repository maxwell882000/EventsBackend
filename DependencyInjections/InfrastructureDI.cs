using EventsBookingBackend.Domain.Auth.Entities;
using EventsBookingBackend.Domain.Booking.Repositories;
using EventsBookingBackend.Domain.Category.Repositories;
using EventsBookingBackend.Domain.Event.Repositories;
using EventsBookingBackend.Domain.Review.Repositories;
using EventsBookingBackend.Domain.User.Repositories;
using EventsBookingBackend.Infrastructure.EntityFramework.DbContexts;
using EventsBookingBackend.Infrastructure.Repository.Booking;
using EventsBookingBackend.Infrastructure.Repository.Category;
using EventsBookingBackend.Infrastructure.Repository.Event;
using EventsBookingBackend.Infrastructure.Repository.Review;
using EventsBookingBackend.Infrastructure.Repository.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventsBookingBackend.DependencyInjections;

public static class InfrastructureDi
{
    public static void AddAuth(this IServiceCollection services)
    {
        services
            .AddAuthentication()
            .AddBearerToken();
        services.AddAuthorization();
        services.AddIdentity<Auth, IdentityRole>()
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();
    }

    public static void AddDatabases(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetValue<string>("Database:Postgresql:ConnectionString");

        services.AddDbContextPool<UserDbContext>(options =>
            options.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention());
        services.AddDbContextPool<ReviewDbContext>(options =>
            options.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention());
        services.AddDbContextPool<EventDbContext>(options =>
            options.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention());
        services.AddDbContextPool<CategoryDbContext>(options =>
            options.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention());
        services.AddDbContextPool<BookingDbContext>(options =>
            options.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention());
        services.AddDbContextPool<AuthDbContext>(options =>
            options.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention());
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        #region Booking

        services.AddTransient<IBookingTypeRepository, BookingTypeRepository>();
        services.AddTransient<IBookingOptionRepository, BookingOptionRepository>();
        services.AddTransient<IBookingRepository, BookingRepository>();

        #endregion

        #region Category

        services.AddTransient<ICategoriesRepository, CategoryRepository>();

        #endregion

        #region Event

        services.AddTransient<IEventRepository, EventRepository>();
        services.AddTransient<ILikedEventRepository, LikedEventRepository>();

        #endregion

        #region Review

        services.AddTransient<IReviewRepository, ReviewRepository>();

        #endregion

        #region User

        services.AddTransient<IUserRepository, UserRepository>();

        #endregion
    }
}