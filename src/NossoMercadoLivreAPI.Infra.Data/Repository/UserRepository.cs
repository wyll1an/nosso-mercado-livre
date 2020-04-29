using Microsoft.EntityFrameworkCore;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using NossoMercadoLivreAPI.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NossoMercadoLivreAPI.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextDb _context;
        public UserRepository(ContextDb context)
        {
            _context = context;
        }

        public virtual async Task<UserEntity> InsertAsync(UserEntity entity)
        {
            await _context.Set<UserEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<UserEntity> GetOneByFilterAsync(Expression<Func<UserEntity, bool>> filter)
        {
            return await _context.Set<UserEntity>().AsNoTracking().SingleOrDefaultAsync(filter);
        }
    }
}
