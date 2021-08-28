using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MatchAPP.Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] propertiesToInclude);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] propertiesToInclude);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
