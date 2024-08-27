using EventsBookingBackend.Infrastructure.EntityFramework.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReviewEntity = EventsBookingBackend.Domain.Review.Entities.Review;

namespace EventsBookingBackend.Infrastructure.EntityFramework.Configurations.Review;

public class ReviewConfiguration : BaseEntityConfiguration<ReviewEntity>
{
    public override void Configure(EntityTypeBuilder<ReviewEntity> builder)
    {
        base.Configure(builder);

    }
}