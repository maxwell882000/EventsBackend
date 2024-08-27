using EventsBookingBackend.Domain.Event.Repositories;
using EventsBookingBackend.Infrastructure.EntityFramework.DbContexts;
using EventsBookingBackend.Infrastructure.Repository.Common;

namespace EventsBookingBackend.Infrastructure.Repository.Event;

public class EventRepository(EventDbContext context) : CrudRepository<Domain.Event.Entities.Event, EventDbContext>(context), IEventRepository;