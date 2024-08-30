using EventsBookingBackend.Application.Models.Common;
using EventsBookingBackend.Domain.Event.ValueObjects;

namespace EventsBookingBackend.Application.Models.Event.Responses;

public class GetAllEventsResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string WorkTime { get; set; }
    public bool IsOpen { get; set; }
    public FileDto Image { get; set; }
    public string Address { get; set; }
    public LatLong Coordinates { get; set; }
    public float? Mark { get; set; } = 0;
    public int? ReviewCount { get; set; } = 0;
    public Guid CategoryId { get; set; }
    public bool IsLiked { get; set; } = false;
}