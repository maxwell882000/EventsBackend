using AutoMapper;
using EventsBookingBackend.Application.Common.Exceptions;
using EventsBookingBackend.Application.Models.Auth.Requests;
using EventsBookingBackend.Application.Models.Auth.Responses;
using EventsBookingBackend.Domain.User.Entities;
using EventsBookingBackend.Domain.User.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.Data;

namespace EventsBookingBackend.Application.Services.Auth;

public class AuthService(
    UserManager<Domain.Auth.Entities.Auth> userManager,
    IUserRepository userRepository,
    IMapper mapper) // Add DbContext to manage transactions
    : IAuthService
{
    public async Task<AuthRegisterResponse> Register(AuthRegisterRequest request)
    {
        if (request.Password != request.RepeatPassword)
            throw new AppValidationException("Passwords do not match");

        // using var transaction = await dbContext.Database.BeginTransactionAsync();

        try
        {
            // Create the auth entity
            var authResult = await userManager.CreateAsync(mapper.Map<Domain.Auth.Entities.Auth>(request));
            if (!authResult.Succeeded)
            {
                throw new AppValidationException(string.Join(", ", authResult.Errors.Select(e => e.Description)));
            }

            // Create the user entity
            await userRepository.Create(mapper.Map<User>(request));

            // Commit the transaction
            // await transaction.CommitAsync();

            return new AuthRegisterResponse();
        }
        catch
        {
            // Rollback the transaction in case of an error
            // await transaction.RollbackAsync();
            throw;
        }
    }
}