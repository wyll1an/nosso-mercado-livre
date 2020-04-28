using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Request;
using NossoMercadoLivreAPI.Domain.Response;

namespace NossoMercadoLivreAPI.Domain.Interfaces.Services
{
    public interface IUserService : IService<UserRequest, UserResponse, UserEntity>
    {
        Task<UserResponse> SaveUserAsync(UserRequest user);
        Task<UserResponse> UpdateUserAsync(UserUpdateRequest user);
    }
}
