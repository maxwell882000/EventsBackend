using System.Security.Claims;
using EventsBookingBackend.DependencyInjections;
using EventsBookingBackend.Infrastructure.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuth();
builder.Services.AddDatabases(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddApplicationServices();
builder.Services.AddCommonExtensions();

var app = builder.Build();

app.MapGet("/login", (string username) =>
{
    var claimsPrincipal = new ClaimsPrincipal(
        new ClaimsIdentity(
            new[] { new Claim(ClaimTypes.Name, username) },
            BearerTokenDefaults.AuthenticationScheme
        )
    );

    return Results.SignIn(claimsPrincipal);
});

app.MapGet("/user", (ClaimsPrincipal user) => { return Results.Ok($"Welcome {user.Identity.Name}!"); })
    .RequireAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();
    dbContext.Database.Migrate();
}

app.UseMiddlewares();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();