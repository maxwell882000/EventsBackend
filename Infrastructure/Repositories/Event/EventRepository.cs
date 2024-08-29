using EventsBookingBackend.Domain.Event.Repositories;
using EventsBookingBackend.Infrastructure.Persistence.DbContexts;
using EventsBookingBackend.Infrastructure.Repository.Common;

namespace EventsBookingBackend.Infrastructure.Repository.Event;

public class EventRepository(EventDbContext context) : CrudRepository<Domain.Event.Entities.Event, EventDbContext>(context), IEventRepository;