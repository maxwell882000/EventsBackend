using EventsBookingBackend.Domain.Common.Repositories;

namespace EventsBookingBackend.Domain.Category.Repositories;

public interface ICategoriesRepository : ICrudRepository<Entities.Category>;