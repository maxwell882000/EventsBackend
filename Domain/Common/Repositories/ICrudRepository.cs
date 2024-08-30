using EventsBookingBackend.Domain.Common.Entities;
using EventsBookingBackend.Domain.Common.Specifications;

namespace EventsBookingBackend.Domain.Common.Repositories;

public interface ICrudRepository<T> where T : BaseEntity
{
    public Task<T> Create(T entity);
    public Task<T> Update(T entity);
    public Task<bool> Delete(T entity);
    public Task<List<T>> FindAll(ISpecification<T>? specification = null);
    public Task<T?> FindFirst(ISpecification<T> specification);
}