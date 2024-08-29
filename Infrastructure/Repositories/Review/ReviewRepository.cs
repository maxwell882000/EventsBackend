using EventsBookingBackend.Domain.Review.Repositories;
using EventsBookingBackend.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EventsBookingBackend.Infrastructure.Repository.Review;

public class ReviewRepository(ReviewDbContext context) : IReviewRepository
{
    public async Task<Domain.Review.Entities.Review> Create(Domain.Review.Entities.Review review)
    {
        await context.Reviews.AddAsync(review);
        await context.SaveChangesAsync();
        return review;
    }

    public async Task<Domain.Review.Entities.Review> Update(Domain.Review.Entities.Review review)
    {
        context.Attach(review).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return review;
    }
}