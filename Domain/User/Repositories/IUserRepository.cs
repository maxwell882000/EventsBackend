using EventsBookingBackend.Domain.Common.Repositories;

namespace EventsBookingBackend.Domain.User.Repositories;

public interface IUserRepository : ICrudRepository<Entities.User>;