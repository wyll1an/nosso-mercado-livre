using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using NossoMercadoLivreAPI.Infra.Data.Context;
using NossoMercadoLivreAPI.Infra.Data.Repository.Base;

namespace NossoMercadoLivreAPI.Infra.Data.Repository
{
    public class ProfileRepository : BaseRepository<ProfileEntity>, IProfileRepository
    {
        public ProfileRepository(ContextDb context)
            : base(context)
        {
        }
    }
}
