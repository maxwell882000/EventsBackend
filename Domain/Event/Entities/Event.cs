using EventsBookingBackend.Domain.Common.Entities;
using EventsBookingBackend.Domain.Event.ValueObjects;

namespace EventsBookingBackend.Domain.Event.Entities;

public class Event : BaseEntity
{
    public string Name { get; set; }
    public Building Building { get; set; }

    public ICollection<LikedEvent> LikedEvents { get; set; }
}