using EventsBookingBackend.Domain.Common.Entities;

namespace EventsBookingBackend.Domain.Review.Entities;

public class Review : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid EventId { get; set; }
    public int Mark { get; set; }
    public string Comment { get; set; }
    public List<string> MediaFiles { get; set; }
}