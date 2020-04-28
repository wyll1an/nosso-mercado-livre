using AutoMapper;
using FluentValidation;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Interfaces.Services;
using NossoMercadoLivreAPI.Domain.Request;
using NossoMercadoLivreAPI.Domain.Response;
using NossoMercadoLivreAPI.Infra.Resources;
using NossoMercadoLivreAPI.Service.Validators;
using NossoMercadoLivreAPI.UnitTest.ContextTest;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NossoMercadoLivreAPI.Service.Common;

namespace NossoMercadoLivreAPI.UnitTest.ServiceTest
{
    public class UserServiceTest : ContextDbTest, IUserService
    {
        private readonly IMapper _mapper;

        public UserServiceTest(IMapper mapper)
        {
            _mapper = mapper;

            Initialization = InitializeAsync();
        }

        public Task Initialization { get; private set; }

        public async Task<UserResponse> SaveUserAsync(UserRequest user)
        {
            try
            {
                await ValidateAsync(user, Activator.CreateInstance<UserValidator>());
                
                #region Validações
                var userEntity = await _context.User.AsNoTracking().Where(u => u.Email == user.Email).FirstOrDefaultAsync();
                if (userEntity != null)
                    throw new Exception(MessagesAPI.USER_ALREADY_EXISTS);
                #endregion

                UserEntity userSave = _mapper.Map<UserEntity>(user);

                #region Criptografia de Senha
                userSave.PasswordHash = Util.GetSha256Hash(new SHA256CryptoServiceProvider(), user.Password);
                #endregion

                await _context.User.AddAsync(userSave);
                await _context.SaveChangesAsync();

                return _mapper.Map<UserResponse>(userSave);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserResponse> UpdateUserAsync(UserUpdateRequest user)
        {
            try
            {
                await ValidateAsync(user, Activator.CreateInstance<UserUpdateValidator>());

                #region Validações
                var userEntity = await _context.User.AsNoTracking().Where(u => u.Id == user.Id).FirstOrDefaultAsync();
                if (userEntity is null)
                    throw new Exception(MessagesAPI.USER_NOT_FOUND);
                #endregion

                UserEntity userUpdate = _mapper.Map<UserEntity>(user);

                _context.Entry(userUpdate).Property(x => x.PasswordHash).IsModified = false;
                _context.Entry(userUpdate).Property(x => x.Email).IsModified = false;
                _context.Entry(userEntity).CurrentValues.SetValues(userUpdate);
                await _context.SaveChangesAsync();

                return _mapper.Map<UserResponse>(userUpdate);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<UserResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse> InsertAsync<V>(UserRequest entity) where V : AbstractValidator<UserRequest>
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }


        public Task<UserResponse> UpdateAsync<V>(UserRequest entity) where V : AbstractValidator<UserRequest>
        {
            throw new NotImplementedException();
        }


        private async Task ValidateAsync(UserRequest user, AbstractValidator<UserRequest> validator)
        {
            if (user is null)
                throw new ValidationException(MessagesAPI.OBJECT_INVALID);

            await validator.ValidateAndThrowAsync(user);
        }

        private async Task ValidateAsync(UserUpdateRequest user, AbstractValidator<UserUpdateRequest> validator)
        {
            if (user is null)
                throw new ValidationException(MessagesAPI.OBJECT_INVALID);

            await validator.ValidateAndThrowAsync(user);
        }

        private async Task InitializeAsync()
        {
            var user = new UserRequest()
            {
                Email = "first@hotmail.com",
                FullName = "Primeiro Teste",
                Document = "5634765",
                PhoneNumber = "34998765674",
                Password = "teste123"
            };

            await SaveUserAsync(user);
        }
    }
}
