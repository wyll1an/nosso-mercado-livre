using AutoMapper;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using NossoMercadoLivreAPI.Domain.Interfaces.Services;
using NossoMercadoLivreAPI.Domain.Interfaces.UnitOfWork;
using NossoMercadoLivreAPI.Domain.Request;
using NossoMercadoLivreAPI.Domain.Response;
using NossoMercadoLivreAPI.Service.Services.Base;

namespace NossoMercadoLivreAPI.Service.Services
{
    public class ProfileService : BaseService<ProfileRequest, ProfileResponse, ProfileEntity>, IProfileService
    {
        private readonly IProfileRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProfileService(IProfileRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
