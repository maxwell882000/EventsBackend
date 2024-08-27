using EventsBookingBackend.Domain.Common.Repositories;

namespace EventsBookingBackend.Domain.Review.Repositories;

public interface IReviewRepository
{
    public Task<Entities.Review> Create(Entities.Review review);
    public Task<Entities.Review> Update(Entities.Review review);
}