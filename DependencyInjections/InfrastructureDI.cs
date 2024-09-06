using EventsBookingBackend.Api.Identity;
using EventsBookingBackend.Domain.Auth.Entities;
using EventsBookingBackend.Domain.Booking.Repositories;
using EventsBookingBackend.Domain.Category.Repositories;
using EventsBookingBackend.Domain.Event.Repositories;
using EventsBookingBackend.Domain.File.Repositories;
using EventsBookingBackend.Domain.Files.Services;
using EventsBookingBackend.Domain.Review.Repositories;
using EventsBookingBackend.Domain.User.Repositories;
using EventsBookingBackend.Infrastructure.Persistence.DbContexts;
using EventsBookingBackend.Infrastructure.Repositories.Event;
using EventsBookingBackend.Infrastructure.Repositories.File;
using EventsBookingBackend.Infrastructure.Repositories.Booking;
using EventsBookingBackend.Infrastructure.Repositories.Category;
using EventsBookingBackend.Infrastructure.Repositories.Event;
using EventsBookingBackend.Infrastructure.Repositories.Review;
using EventsBookingBackend.Infrastructure.Repositories.User;
using EventsBookingBackend.Infrastructure.Services.File;
using EventsBookingBackend.Shared.Options.File;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsBookingBackend.DependencyInjections;

public static class InfrastructureDi
{
    public static void AddAuth(this IServiceCollection services)
    {
        services.AddIdentity<Auth, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders()
            .AddErrorDescriber<RussianIdentityErrorDescriber>();
        services.AddAuthorization(options =>
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(BearerTokenDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
        });
        services
            .AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = BearerTokenDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = BearerTokenDefaults.AuthenticationScheme;
                cfg.DefaultSignInScheme = BearerTokenDefaults.AuthenticationScheme;
                cfg.DefaultScheme = BearerTokenDefaults.AuthenticationScheme;
                cfg.DefaultForbidScheme = BearerTokenDefaults.AuthenticationScheme;
            })
            .AddBearerToken();
    }

    public static void AddDatabases(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetValue<string>("Database:Postgresql:ConnectionString");

        services.AddDbContextPool<UserDbContext>(options =>
            options.UseNpgsql(connectionString,
                    x =>
                        x.MigrationsHistoryTable(HistoryRepository.DefaultTableName,
                            schema: "users"))
                .UseSnakeCaseNamingConvention());
        services.AddDbContextPool<ReviewDbContext>(options =>
            options.UseNpgsql(connectionString, x =>
                    x.MigrationsHistoryTable(HistoryRepository.DefaultTableName,
                        schema: "reviews"))
                .UseSnakeCaseNamingConvention());
        services.AddDbContextPool<EventDbContext>(options =>
        {
            options.UseNpgsql(connectionString, x =>
                    x.MigrationsHistoryTable(HistoryRepository.DefaultTableName,
                        schema: "events"))
                .UseSnakeCaseNamingConvention();
        });
        services.AddDbContextPool<CategoryDbContext>(options =>
            options.UseNpgsql(connectionString, x =>
                    x.MigrationsHistoryTable(HistoryRepository.DefaultTableName,
                        schema: "categories"))
                .UseSnakeCaseNamingConvention());
        services.AddDbContextPool<BookingDbContext>(options =>
            options.UseNpgsql(connectionString, x =>
                    x.MigrationsHistoryTable(HistoryRepository.DefaultTableName,
                        schema: "bookings"))
                .UseSnakeCaseNamingConvention());
        services.AddDbContextPool<AuthDbContext>(options =>
            options.UseNpgsql(connectionString, x =>
                    x.MigrationsHistoryTable(HistoryRepository.DefaultTableName,
                        schema: "auth"))
                .UseSnakeCaseNamingConvention());
        services.AddDbContextPool<FileDbContext>(options =>
            options.UseNpgsql(connectionString, x =>
                    x.MigrationsHistoryTable(HistoryRepository.DefaultTableName,
                        schema: "files"))
                .UseSnakeCaseNamingConvention());
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        #region Booking

        services.AddTransient<IBookingTypeRepository, BookingTypeRepository>();
        services.AddTransient<IBookingOptionRepository, BookingOptionRepository>();
        services.AddTransient<IBookingRepository, BookingRepository>();
        services.AddTransient<IBookingLimitRepository, BookingLimitRepository>();

        #endregion

        #region Category

        services.AddTransient<ICategoriesRepository, CategoryRepository>();

        #endregion

        #region Event

        services.AddTransient<IEventRepository, EventRepository>();
        services.AddTransient<ILikedEventRepository, LikedEventRepository>();
        services.AddTransient<IEventAggregatedReviewRepository, EventAggregatedReviewRepository>();

        #endregion

        #region Review

        services.AddTransient<IReviewRepository, ReviewRepository>();
        services.AddTransient<IReviewAggregateRepository, ReviewAggregateRepository>();

        #endregion

        #region User

        services.AddTransient<IUserRepository, UserRepository>();

        #endregion

        #region File

        services.AddTransient<IFileDbRepository, FileDbDbRepository>();
        services.AddTransient<IFileSystemRepository, FileSystemRepository>();

        #endregion
    }

    public static void AddServices(this IServiceCollection services)
    {
        #region File

        services.AddTransient<IFileService, FileService>();

        #endregion
    }

    public static void AddInfraOptions(this IServiceCollection services, IConfiguration configuration)
    {
        #region File

        services.Configure<FileOption>(
            configuration.GetSection(nameof(FileOption)));

        #endregion
    }
}