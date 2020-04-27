using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NossoMercadoLivreAPI.Domain.Entities.Base;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using NossoMercadoLivreAPI.Infra.Data.Context;
using System.Threading.Tasks;

namespace NossoMercadoLivreAPI.Infra.Data.Repository.Base
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ContextDb _context;

        public BaseRepository(ContextDb context)
            : base()
        {
            _context = context;
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public virtual async Task<List<T>> InsertListAsync(List<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();

            return entities.ToList();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            if (_context.Entry(entity).Property(p => p.CreatedDate).IsModified)
                _context.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
            
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task RemoveAsync(long id)
        {
            T result = await GetOneByFilterWithIncludesAsync(g => g.Id == id);
            if (result != null)
            {
                _context.Set<T>().Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<List<T>> GetAllSortedAsync(params Expression<Func<T, object>>[] orderBy)
        {
            var query = _context.Set<T>().OrderBy(orderBy.First());
            if (orderBy.Length > 1)
            {
                for (int i = 1; i < orderBy.Length; i++)
                {
                    query = query.ThenBy(orderBy[i]);
                }
            }
            return await query.ToListAsync();
        }

        public virtual async Task<List<T>> GetByFilterWithIncludesAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.Where(filter).ToListAsync();
        }

        public virtual async Task<T> GetOneByFilterWithIncludesAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.SingleOrDefaultAsync(filter);
        }

        public virtual async Task<List<T>> GetAllByIncludesAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }
    }
}
