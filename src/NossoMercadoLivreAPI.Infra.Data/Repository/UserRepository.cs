using Microsoft.EntityFrameworkCore;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Interfaces.Context;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using NossoMercadoLivreAPI.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NossoMercadoLivreAPI.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _context;
        public UserRepository(IDbContext context)
        {
            _context = context;
        }

        public virtual async Task<User> InsertAsync(User entity)
        {
            await _context.Instance.Set<User>().AddAsync(entity);
            await _context.Instance.SaveChangesAsync();

            return entity;
        }
    }
}
