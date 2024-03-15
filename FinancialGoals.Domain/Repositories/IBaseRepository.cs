using FinancialGoals.Domain.Entities;
using System.Linq.Expressions;

namespace FinancialGoals.Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Create(T entity);
        Task Update(T entity);
        Task<T> GetOne(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll();
        Task<bool> Exists(Expression<Func<T, bool>> expression);
        Task SaveChangesAsync();
    }
}
