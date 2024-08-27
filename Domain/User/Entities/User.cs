using EventsBookingBackend.Domain.Common.Entities;

namespace EventsBookingBackend.Domain.User.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string? Avatar { get; set; }
}