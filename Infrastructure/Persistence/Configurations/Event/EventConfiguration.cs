using EventsBookingBackend.Domain.Common.ValueObjects;
using EventsBookingBackend.Domain.Event.Entities;
using EventsBookingBackend.Domain.Event.ValueObjects;
using EventsBookingBackend.Infrastructure.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
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
        builder.OwnsOne(e => e.State, x =>
        {
            x.Property(e => e.IsActive).HasDefaultValue(true);
            x.Property(e => e.IsReservable).HasDefaultValue(false);
        });
        builder.HasOne(e => e.AggregatedReviews)
            .WithOne(e => e.Event)
            .HasForeignKey<EventAggregatedReview>(e => e.EventId);
        Seed(builder);
    }

    private void Seed(EntityTypeBuilder<EventEntity> builder)
    {
        var image = "media/preview.png";

        var eventIdOne = Guid.NewGuid();
        var eventIdTwo = Guid.NewGuid();
        var eventIdThree = Guid.NewGuid();
        var eventIdFour = Guid.NewGuid();

        var categoryId = Guid.Parse("48c112b1-70f5-4270-8f75-98c74bc48d96");

        builder.HasData(new EventEntity()
        {
            Id = eventIdOne,
            Name = "Ташгрэс поле",
            CategoryId = categoryId
        });


        builder.HasData(new EventEntity
        {
            Id = eventIdTwo,
            Name = "225 школа поле",
            CategoryId = categoryId
        });

        builder.HasData(new EventEntity
        {
            Id = eventIdThree,
            Name = "МВЭС поле",
            CategoryId = categoryId
        });

        builder.HasData(new EventEntity
        {
            Id = eventIdFour,
            Name = "Эко парк поле",
            CategoryId = categoryId
        });

        builder.OwnsOne(e => e.Building, x =>
        {
            x.HasData(
                new
                {
                    Id = eventIdOne,
                    EventId = eventIdOne,
                    Address = "микрорайон ТашГРЭС, 37",
                },
                new
                {
                    Id = eventIdTwo,
                    EventId = eventIdTwo,
                    Address = "улица Каландар, 5",
                },
                new
                {
                    Id = eventIdThree,
                    EventId = eventIdThree,
                    Address = "ул. Мирзо Улугбека, 8А",
                },
                new
                {
                    Id = eventIdFour,
                    EventId = eventIdFour,
                    Address = "Ташкентский центральный экопарк имени Захириддина Мухаммада Бабура",
                }
            );

            x.OwnsOne(e => e.LatLong).HasData(
                new
                {
                    BuildingEventId = eventIdOne,
                    Latitude = 41.353098,
                    Longitude = 69.336008
                },
                new
                {
                    BuildingEventId = eventIdTwo,
                    Latitude = 41.331663,
                    Longitude = 69.328025
                },
                new
                {
                    BuildingEventId = eventIdThree,
                    Latitude = 41.332619,
                    Longitude = 69.329982
                },
                new
                {
                    BuildingEventId = eventIdFour,
                    Latitude = 41.309570,
                    Longitude = 69.295300
                }
            );
            x.OwnsMany(e => e.WorkHours).HasData(
                new
                {
                    Id = 1, Day = DayOfWeek.Monday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdOne
                }, // Monday
                new { Id = 3, Day = DayOfWeek.Wednesday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdOne },
                new { Id = 2, Day = DayOfWeek.Tuesday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdOne },
                new { Id = 5, Day = DayOfWeek.Friday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdOne },
                new { Id = 6, Day = DayOfWeek.Saturday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdOne },
                new { Id = 4, Day = DayOfWeek.Thursday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdOne },
                new { Id = 7, Day = DayOfWeek.Sunday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdOne },
                new
                {
                    Id = 8, Day = DayOfWeek.Monday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdTwo
                }, // Monday
                new { Id = 9, Day = DayOfWeek.Tuesday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdTwo },
                new { Id = 10, Day = DayOfWeek.Wednesday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdTwo },
                new { Id = 11, Day = DayOfWeek.Thursday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdTwo },
                new { Id = 12, Day = DayOfWeek.Friday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdTwo },
                new { Id = 13, Day = DayOfWeek.Saturday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdTwo },
                new { Id = 14, Day = DayOfWeek.Sunday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdTwo },
                new
                {
                    Id = 15, Day = DayOfWeek.Monday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdThree
                }, // Monday
                new { Id = 16, Day = DayOfWeek.Tuesday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdThree },
                new { Id = 17, Day = DayOfWeek.Wednesday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdThree },
                new { Id = 19, Day = DayOfWeek.Friday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdThree },
                new { Id = 20, Day = DayOfWeek.Saturday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdThree },
                new { Id = 18, Day = DayOfWeek.Thursday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdThree },
                new { Id = 21, Day = DayOfWeek.Sunday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdThree },
                new
                {
                    Id = 22, Day = DayOfWeek.Monday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdFour
                }, // Monday
                new { Id = 23, Day = DayOfWeek.Tuesday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdFour },
                new { Id = 24, Day = DayOfWeek.Wednesday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdFour },
                new { Id = 25, Day = DayOfWeek.Thursday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdFour },
                new { Id = 26, Day = DayOfWeek.Friday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdFour },
                new { Id = 27, Day = DayOfWeek.Saturday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdFour },
                new { Id = 28, Day = DayOfWeek.Sunday, FromHour = 10, ToHour = 23, BuildingEventId = eventIdFour }
            );
        });

        builder.OwnsOne(e => e.PreviewImage).HasData(
            new
            {
                EventId = eventIdOne,
                Path = image,
            },
            new
            {
                EventId = eventIdTwo,
                Path = image,
            },
            new
            {
                EventId = eventIdThree,
                Path = image,
            },
            new
            {
                EventId = eventIdFour,
                Path = image,
            });

        builder.OwnsMany(e => e.Images).HasData(
            new
            {
                EventId = eventIdOne,
                Id = 1,
                Path = image,
            }, new
            {
                EventId = eventIdTwo,
                Id = 2,
                Path = image,
            }, new
            {
                EventId = eventIdThree,
                Id = 3,
                Path = image,
            }, new
            {
                EventId = eventIdFour,
                Id = 4,
                Path = image,
            }
        );
    }
}