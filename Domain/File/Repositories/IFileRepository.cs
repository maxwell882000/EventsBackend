using EventsBookingBackend.Domain.Common.Repositories;

namespace EventsBookingBackend.Domain.Files.Repositories;

public interface IFileRepository : ICrudRepository<File.Entities.File>;