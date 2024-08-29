using EventsBookingBackend.Domain.Common.ValueObjects;

namespace EventsBookingBackend.Domain.Event.ValueObjects;

public class Building : BaseValueObject
{
    public LatLong LatLong { get; set; }
    public string Address { get; set; }
    public List<WorkHour> WorkHours { get; set; }

    public WorkHour? WorkTime => WorkHours.FirstOrDefault(e => e.Day == DateTime.Now.Day);
    public bool IsOpen => WorkTime?.FromHour <= DateTime.Now.Hour && WorkTime?.ToHour >= DateTime.Now.Hour;
}