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
                    IsActive = true
                },
                new CategoryEntity
                {
                    Icon = "FootballIcon",
                    Name = "Футбол",
                    BgColor = "#12B76A1F",
                    IsActive = false
                },
                new CategoryEntity
                {
                    Icon = "BasketballIcon",
                    Name = "Баскетбол",
                    BgColor = "#F790091F",
                    IsActive = false
                },
                new CategoryEntity
                {
                    Icon = "TennisIcon",
                    Name = "Теннис",
                    BgColor = "#F63D681F",
                    IsActive = false
                },
                new CategoryEntity
                {
                    Icon = "PingPongIcon",
                    Name = "Пинг понг",
                    BgColor = "#0BA5EC1F",
                    IsActive = false
                }
            );
        }
    }
}