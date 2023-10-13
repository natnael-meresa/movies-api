using Application.Contracts.Persistence;
using Domain.Commmon;
using Microsoft.EntityFrameworkCore;
using Persistence.Configureations;

namespace Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly MoviesAPIDatabaseContext _context;

    public GenericRepository(MoviesAPIDatabaseContext context)
    {
        _context = context;
    }

    public async Task<T?> GetAsync(int? id) {
        return await _context.Set<T>()
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<List<T>> GetAllAsync() {
        return await _context.Set<T>()
        .AsNoTracking()
        .ToListAsync();
    }
    public async Task CreateAsync(T entity) {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task UpdateAsync(T entity) {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity) {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
}