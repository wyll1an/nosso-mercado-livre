using AutoMapper;
using System.Security.Cryptography;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using NossoMercadoLivreAPI.Domain.Interfaces.Services;
using NossoMercadoLivreAPI.Domain.Interfaces.UnitOfWork;
using NossoMercadoLivreAPI.Domain.Request;
using NossoMercadoLivreAPI.Domain.Response;
using NossoMercadoLivreAPI.Infra.Resources;
using NossoMercadoLivreAPI.Service.Services.Base;
using NossoMercadoLivreAPI.Service.Validators;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using FluentValidation;
using NossoMercadoLivreAPI.Service.Common;

namespace NossoMercadoLivreAPI.Service.Services
{
    public class UserService : BaseService<UserRequest, UserResponse, UserEntity>, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserProfileService _userProfileService;

        public UserService(IUserRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IUserProfileService userProfileService)
            : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userProfileService = userProfileService;
        }

        public async Task<UserResponse> SaveUserAsync(UserRequest user)
        {
            try
            {
                await ValidateAsync(user, Activator.CreateInstance<UserValidator>());

                #region Validações
                var userEntity = await _repository.GetOneByFilterWithIncludesAsync(u => u.Email == user.Email);
                if (userEntity != null)
                    throw new ArgumentException(MessagesAPI.USER_ALREADY_EXISTS);
                #endregion

                UserEntity userSave = _mapper.Map<UserEntity>(user);

                #region Criptografia de Senha
                userSave.PasswordHash = Util.GetSha256Hash(new SHA256CryptoServiceProvider(), user.Password);
                #endregion

                await _unitOfWork.BeginAsync();
                await _repository.InsertAsync(userSave);
                await _userProfileService.InsertUserProfileWithProfileDefault(userSave.Id);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<UserResponse>(userSave);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                throw ex;
            }
        }

        public async Task<UserResponse> UpdateUserAsync(UserUpdateRequest user)
        {
            try
            {
                await ValidateAsync(user, Activator.CreateInstance<UserUpdateValidator>());

                #region Validações
                var userEntity = await _repository.GetOneByFilterWithIncludesAsync(u => u.Id == user.Id, i => i.UserProfiles);
                if (userEntity is null)
                    throw new Exception(MessagesAPI.USER_NOT_FOUND);
                #endregion

                userEntity.FullName = user.FullName;
                userEntity.Document = user.Document;
                userEntity.PhoneNumber = user.PhoneNumber;

                await _unitOfWork.BeginAsync();
                await _repository.UpdateAsync(userEntity);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<UserResponse>(userEntity);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                throw ex;
            }
        }

        public override async Task<List<UserResponse>> GetAllAsync()
        {
            return _mapper.Map<List<UserResponse>>(await _repository.GetAllByIncludesAsync(u => u.UserProfiles));
        }

        public override async Task<UserResponse> GetByIdAsync(long id)
        {
            return _mapper.Map<UserResponse>(await _repository.GetOneByFilterWithIncludesAsync(u => u.Id == id, u => u.UserProfiles));
        }

        private async Task ValidateAsync(UserUpdateRequest entity, AbstractValidator<UserUpdateRequest> validator)
        {
            if (entity is null)
                throw new ValidationException(MessagesAPI.OBJECT_INVALID);

            await validator.ValidateAndThrowAsync(entity);
        }
    }
}
