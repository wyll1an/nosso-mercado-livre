using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using NossoMercadoLivreAPI.Infra.Data.Context;
using NossoMercadoLivreAPI.Infra.Data.Repository.Base;

namespace NossoMercadoLivreAPI.Infra.Data.Repository
{
    public class UserProfileRepository : BaseRepository<UserProfileEntity>, IUserProfileRepository
    {
        public UserProfileRepository(ContextDb context)
            : base(context)
        {
        }
    }
}
