using EventsBookingBackend.Domain.Common.Entities;

namespace EventsBookingBackend.Domain.Common.Repositories;

public interface ICrudRepository<T> where T : BaseEntity
{
    public Task<T> Create(T entity);
    public Task<T> Update(T entity);
    public Task<bool> Delete(T entity);
    public Task<List<T>> FindAll();
}