using EventsBookingBackend.Domain.Common.Repositories;

namespace EventsBookingBackend.Domain.Event.Repositories;

public interface IEventRepository : ICrudRepository<Entities.Event>;