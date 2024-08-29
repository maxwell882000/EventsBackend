using EventsBookingBackend.Domain.Category.Repositories;
using EventsBookingBackend.Infrastructure.Persistence.DbContexts;
using EventsBookingBackend.Infrastructure.Repository.Common;

namespace EventsBookingBackend.Infrastructure.Repository.Category;

public class CategoryRepository(CategoryDbContext context)
    : CrudRepository<Domain.Category.Entities.Category, CategoryDbContext>(context),
        ICategoriesRepository;