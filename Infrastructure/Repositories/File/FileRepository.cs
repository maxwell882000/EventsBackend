using EventsBookingBackend.Domain.Files.Repositories;
using EventsBookingBackend.Infrastructure.Persistence.DbContexts;
using EventsBookingBackend.Infrastructure.Repository.Common;

namespace EventsBookingBackend.Infrastructure.Repositories.File;

public class FileRepository(FileDbContext context)
    : CrudRepository<Domain.File.Entities.File, FileDbContext>(context), IFileRepository;