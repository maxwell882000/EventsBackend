using EventsBookingBackend.Domain.User.Repositories;
using EventsBookingBackend.Infrastructure.Persistence.DbContexts;
using EventsBookingBackend.Infrastructure.Repository.Common;

namespace EventsBookingBackend.Infrastructure.Repository.User;

public class UserRepository(UserDbContext context)
    : CrudRepository<Domain.User.Entities.User, UserDbContext>(context), IUserRepository;