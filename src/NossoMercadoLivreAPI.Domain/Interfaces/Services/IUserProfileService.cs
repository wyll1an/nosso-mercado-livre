using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Request;
using NossoMercadoLivreAPI.Domain.Response;
using System.Threading.Tasks;

namespace NossoMercadoLivreAPI.Domain.Interfaces.Services
{
    public interface IUserProfileService : IService<UserProfileRequest, UserProfileResponse, UserProfileEntity>
    {
        Task<UserProfileResponse> InsertUserProfileWithProfileDefault(long userId);
        Task<UserProfileResponse> InsertUserProfileWithProfileAdmin(long userId);
    }
}
