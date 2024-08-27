using EventsBookingBackend.Infrastructure.EntityFramework.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventEntity = EventsBookingBackend.Domain.Event.Entities.Event;

namespace EventsBookingBackend.Infrastructure.EntityFramework.Configurations.Event;

public class EventConfiguration : BaseEntityConfiguration<EventEntity>
{
    public override void Configure(EntityTypeBuilder<EventEntity> builder)
    {
        base.Configure(builder);
        builder.OwnsOne(e => e.Building).WithOwner();
    }
}