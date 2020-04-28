using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NossoMercadoLivreAPI.Domain.Entities.Base;

namespace NossoMercadoLivreAPI.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T entity);
        Task<List<T>> InsertListAsync(List<T> entities);
        Task<T> UpdateAsync(T entity);
        Task RemoveAsync(long id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllSortedAsync(params Expression<Func<T, object>>[] orderBy);
        Task<List<T>> GetByFilterWithIncludesAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetOneByFilterWithIncludesAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetAllByIncludesAsync(params Expression<Func<T, object>>[] includeProperties);
    }
}
