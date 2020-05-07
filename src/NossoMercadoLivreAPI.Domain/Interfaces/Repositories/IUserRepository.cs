using NossoMercadoLivreAPI.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NossoMercadoLivreAPI.Domain.Interfaces.Repositories
{
    public interface IUserRepository 
    {
        Task<User> InsertAsync(User entity);
        bool CheckUserIsUnique(string email);
    }
}
