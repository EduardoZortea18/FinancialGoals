using FinancialGoals.Domain.Entities;
using FinancialGoals.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinancialGoals.Infra.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly FinancialGoalsContext _context;

        public BaseRepository(FinancialGoalsContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAll()
            => await _context.Set<T>().ToListAsync();

        public async Task<T> GetOne(Expression<Func<T, bool>> expression)
            => await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(expression);

        public async virtual Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveChangesAsync();
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> expression)
            => await _context.Set<T>().AsNoTracking().Where(expression).AnyAsync();

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
