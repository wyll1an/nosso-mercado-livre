using Microsoft.EntityFrameworkCore;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using NossoMercadoLivreAPI.Infra.Data.Context;
using System;
using System.Linq;
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


        public async Task<User> InsertAsync(User entity)
        {
            await _context.Set<User>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public bool CheckUserIsUnique(string email)
        {
            return _context.Set<User>().Where(u => u.Email == email).Any();
        }
    }
}
