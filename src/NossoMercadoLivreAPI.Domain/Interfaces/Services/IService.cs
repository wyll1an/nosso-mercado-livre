using FluentValidation;
using System.Collections.Generic;
using NossoMercadoLivreAPI.Domain.Entities.Base;
using NossoMercadoLivreAPI.Domain.Request.Base;
using NossoMercadoLivreAPI.Domain.Response.Base;
using System.Threading.Tasks;

namespace NossoMercadoLivreAPI.Domain.Interfaces.Services
{
    public interface IService<T, R, E> where T : BaseRequest
                                       where R : BaseResponse
                                       where E : BaseEntity
    {
        Task<R> InsertAsync<V>(T entity) where V : AbstractValidator<T>;

        Task<R> UpdateAsync<V>(T entity) where V : AbstractValidator<T>;

        Task RemoveAsync(long id);

        Task<R> GetByIdAsync(long id);

        Task<List<R>> GetAllAsync();
    }
}