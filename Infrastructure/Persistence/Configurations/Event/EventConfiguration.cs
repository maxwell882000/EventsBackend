using EventsBookingBackend.Domain.Event.Entities;
using EventsBookingBackend.Infrastructure.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventEntity = EventsBookingBackend.Domain.Event.Entities.Event;

namespace EventsBookingBackend.Infrastructure.Persistence.Configurations.Event;

public class EventConfiguration : BaseEntityConfiguration<EventEntity>
{
    public override void Configure(EntityTypeBuilder<EventEntity> builder)
    {
        base.Configure(builder);
        builder.OwnsOne(e => e.Building, x =>
        {
            x.OwnsOne(e => e.LatLong);
            x.OwnsMany(e => e.WorkHours);
        });
        builder.OwnsOne(e => e.PreviewImage);
        builder.OwnsMany(e => e.Images);
        builder.HasOne(e => e.AggregatedReviews)
            .WithOne(e => e.Event)
            .HasForeignKey<EventAggregatedReview>(e => e.EventId);
    }
}