using NossoMercadoLivreAPI.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NossoMercadoLivreAPI.Domain.Interfaces.Repositories
{
    public interface IUserRepository 
    {
        Task<UserEntity> InsertAsync(UserEntity entity);
        Task<UserEntity> GetOneByFilterAsync(Expression<Func<UserEntity, bool>> filter);
    }
}
