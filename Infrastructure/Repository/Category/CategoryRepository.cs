using EventsBookingBackend.Domain.Category.Repositories;
using EventsBookingBackend.Infrastructure.EntityFramework.DbContexts;
using EventsBookingBackend.Infrastructure.Repository.Common;

namespace EventsBookingBackend.Infrastructure.Repository.Category;

public class CategoryRepository(CategoryDbContext context)
    : CrudRepository<Domain.Category.Entities.Category, CategoryDbContext>(context),
        ICategoriesRepository;