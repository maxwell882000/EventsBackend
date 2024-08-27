using EventsBookingBackend.Domain.Common.ValueObjects;

namespace EventsBookingBackend.Domain.Event.ValueObjects;

public class WorkHour : BaseValueObject
{
    public int Day { get; set; }
    public int FromHour { get; set; }
    public int ToHour { get; set; }
}