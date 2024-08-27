using EventsBookingBackend.Infrastructure.EntityFramework.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserEntity = EventsBookingBackend.Domain.User.Entities.User;

namespace EventsBookingBackend.Infrastructure.EntityFramework.Configurations.User;

public class UserConfiguration : BaseEntityConfiguration<UserEntity>
{
    public override void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        base.Configure(builder);
    }
}