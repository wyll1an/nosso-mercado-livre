using Microsoft.EntityFrameworkCore;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using NossoMercadoLivreAPI.Infra.Data.Context;
using NossoMercadoLivreAPI.Infra.Data.Repository.Base;
using System.Threading.Tasks;

namespace NossoMercadoLivreAPI.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ContextDb context)
            : base(context)
        {
        }

        public override async Task<UserEntity> UpdateAsync(UserEntity userEntity)
        {
            _context.Entry(userEntity).Property(x => x.CreatedDate).IsModified = false;
            _context.Entry(userEntity).Property(x => x.PasswordHash).IsModified = false;
            _context.Entry(userEntity).Property(x => x.Email).IsModified = false;
            _context.Entry(userEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return userEntity;
        }
    }
}
