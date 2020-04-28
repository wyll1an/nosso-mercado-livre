using AutoMapper;
using NossoMercadoLivreAPI.Domain.Const;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using NossoMercadoLivreAPI.Domain.Interfaces.Services;
using NossoMercadoLivreAPI.Domain.Interfaces.UnitOfWork;
using NossoMercadoLivreAPI.Domain.Request;
using NossoMercadoLivreAPI.Domain.Response;
using NossoMercadoLivreAPI.Service.Services.Base;
using System;
using System.Threading.Tasks;

namespace NossoMercadoLivreAPI.Service.Services
{
    public class UserProfileService : BaseService<UserProfileRequest, UserProfileResponse, UserProfileEntity>, IUserProfileService
    {
        private readonly IUserProfileRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserProfileService(IUserProfileRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserProfileResponse> InsertUserProfileWithProfileAdmin(long userId)
        {
            try
            {
                await _unitOfWork.BeginAsync();

                UserProfileEntity userProfileEntity = new UserProfileEntity(userId, UserProfileConst.UserAdmin);

                await _repository.InsertAsync(userProfileEntity);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<UserProfileResponse>(userProfileEntity);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                throw ex;
            }
        }

        public async Task<UserProfileResponse> InsertUserProfileWithProfileDefault(long userId)
        {
            try
            {
                await _unitOfWork.BeginAsync();

                UserProfileEntity userProfileEntity = new UserProfileEntity(userId, UserProfileConst.UserDefault);

                await _repository.InsertAsync(userProfileEntity);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<UserProfileResponse>(userProfileEntity);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                throw ex;
            }
        }
    }
}
