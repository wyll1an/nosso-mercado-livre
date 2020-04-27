using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Request;
using NossoMercadoLivreAPI.Domain.Response;

namespace NossoMercadoLivreAPI.Domain.Interfaces.Services
{
    public interface IProfileService : IService<ProfileRequest, ProfileResponse, Domain.Entities.ProfileEntity>
    {
    }
}
