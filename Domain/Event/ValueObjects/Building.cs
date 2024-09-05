using EventsBookingBackend.Domain.Common.ValueObjects;

namespace EventsBookingBackend.Domain.Event.ValueObjects;

public class Building : BaseValueObject
{
    public LatLong LatLong { get; set; }
    public string Address { get; set; }

    private List<WorkHour> _workHours = new List<WorkHour>();

    public List<WorkHour> WorkHours
    {
        get => _workHours.OrderBy(e => e.Day).ToList();
        set => _workHours = value ?? new List<WorkHour>();
    }

    public WorkHour? WorkDay =>
        WorkHours.FirstOrDefault(e => e.Day >= DateTime.Now.DayOfWeek) ?? WorkHours.FirstOrDefault();

    public bool IsOpen => DateTime.Now.DayOfWeek == WorkDay?.Day && WorkDay?.FromHour <= DateTime.Now.Hour &&
                          WorkDay?.ToHour >= DateTime.Now.Hour;

    public string NextTime => WorkDay == null ? "" :
        IsOpen ? "Открыто до " + WorkDay.ToHour + ":00" : "Закрыто до " + WorkDay.FromHour + ":00";
}