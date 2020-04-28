using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using NossoMercadoLivreAPI.Domain.Interfaces.Services;
using NossoMercadoLivreAPI.Domain.Interfaces.UnitOfWork;
using NossoMercadoLivreAPI.Infra.Data.Repository;
using NossoMercadoLivreAPI.Infra.Data.UnitOfWork;
using NossoMercadoLivreAPI.Service.Services;

namespace NossoMercadoLivreAPI.Infra.CrossCutting.IoC
{
    public class DependencyInjection
    {
        private readonly IServiceCollection _service;

        public DependencyInjection(IServiceCollection service)
        {
            _service = service;
        }

        public void RegisterServices()
        {
            // Transação
            _service.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            _service.AddScoped<IUserService, UserService>();
            _service.AddScoped<IProfileService, ProfileService>();
            _service.AddScoped<IUserProfileService, UserProfileService>();

            // Repositories
            _service.AddScoped<IUserRepository, UserRepository>();
            _service.AddScoped<IProfileRepository, ProfileRepository>();
            _service.AddScoped<IUserProfileRepository, UserProfileRepository>();
        }
    }
}
