using EventsBookingBackend.Infrastructure.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CategoryEntity = EventsBookingBackend.Domain.Category.Entities.Category;

namespace EventsBookingBackend.Infrastructure.Persistence.Configurations.Category
{
    public class CategoryConfiguration : BaseEntityConfiguration<CategoryEntity>
    {
        public override void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            base.Configure(builder);

            builder.HasData(
                new CategoryEntity
                {
                    Icon = "AllIcon",
                    Name = "Все",
                    BgColor = "#9E77ED1F",
                    IsDefault = true
                },
                new CategoryEntity
                {
                    Id = Guid.Parse("48c112b1-70f5-4270-8f75-98c74bc48d96"),
                    Icon = "FootballIcon",
                    Name = "Футбол",
                    BgColor = "#12B76A1F",
                    IsDefault = false
                },
                new CategoryEntity
                {
                    Icon = "BasketballIcon",
                    Name = "Баскетбол",
                    BgColor = "#F790091F",
                    IsDefault = false
                },
                new CategoryEntity
                {
                    Icon = "TennisIcon",
                    Name = "Теннис",
                    BgColor = "#F63D681F",
                    IsDefault = false
                },
                new CategoryEntity
                {
                    Icon = "PingPongIcon",
                    Name = "Пинг понг",
                    BgColor = "#0BA5EC1F",
                    IsDefault = false
                }
            );
        }
    }
}