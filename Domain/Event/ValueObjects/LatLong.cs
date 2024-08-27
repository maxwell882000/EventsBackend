using EventsBookingBackend.Domain.Common.ValueObjects;

namespace EventsBookingBackend.Domain.Event.ValueObjects;

public class LatLong : BaseValueObject
{
    public float Latitude { get; set; }
    public float Longitude { get; set; }
}