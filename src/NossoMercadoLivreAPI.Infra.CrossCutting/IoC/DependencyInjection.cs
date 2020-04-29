using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using NossoMercadoLivreAPI.Domain.Interfaces.Services;
using NossoMercadoLivreAPI.Domain.Interfaces.UnitOfWork;
using NossoMercadoLivreAPI.Infra.Data.Repository;

namespace NossoMercadoLivreAPI.Infra.CrossCutting.IoC
{
    public class DependencyInjection
    {
        private readonly IServiceCollection _service;

        public DependencyInjection(IServiceCollection service)
        {
            _service = service;
        }

        
    }
}
