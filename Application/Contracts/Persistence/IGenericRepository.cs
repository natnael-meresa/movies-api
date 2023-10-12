using Domain.Commmon;

namespace Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetAsync(int? id);
    Task<List<T>> GetAllAsync();
    Task CreateAsync(T entity);
    Task UdateAsync(T entity);
    Task DeleteAsync(T entity);
}