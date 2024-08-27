using EventsBookingBackend.Domain.Common.Entities;

namespace EventsBookingBackend.Domain.Category.Entities;

public class Category : BaseEntity
{
    public string Icon { get; set; }
    public string BgColor { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}