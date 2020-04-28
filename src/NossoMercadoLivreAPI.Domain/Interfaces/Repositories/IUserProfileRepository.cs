using System.Threading.Tasks;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Response;

namespace NossoMercadoLivreAPI.Domain.Interfaces.Repositories
{
    public interface IUserProfileRepository : IRepository<UserProfileEntity>
    {
    }
}
