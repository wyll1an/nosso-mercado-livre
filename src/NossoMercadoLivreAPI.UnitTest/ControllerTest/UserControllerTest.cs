using AutoMapper;
using FluentValidation;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Interfaces.Services;
using NossoMercadoLivreAPI.Domain.Request;
using NossoMercadoLivreAPI.Domain.Response;
using NossoMercadoLivreAPI.Infra.Resources;
using NossoMercadoLivreAPI.Service.Common;
using NossoMercadoLivreAPI.UnitTest.ServiceTest;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Xunit;

namespace NossoMercadoLivreAPI.UnitTest.ControllerTest
{
    public class UserControllerTest
    {
        private readonly IUserService _service;
        private IMapper _mapper;

        public UserControllerTest()
        {
            SetAutoMapper();

            _service = new UserServiceTest(_mapper);
        }

        internal void SetAutoMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserRequest, UserEntity>()
                    .ForMember(dest =>
                        dest.PasswordHash,
                        opt => opt.MapFrom(src => src.Password));
                cfg.CreateMap<UserUpdateRequest, UserEntity>();
                cfg.CreateMap<UserEntity, UserResponse>();
            });

            _mapper = new Mapper(configuration);
        }

        #region THEORY
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("userhotmail.com")]
        [InlineData("user@hotmail")]
        [InlineData("@hotmail.com")]
        [InlineData("@hotmail")]
        public async Task Theory_PostUser_Email_ReturnError(string Email)
        {
            var user = new UserRequest()
            {
                Email = Email,
                FullName = "Usuario Teste",
                Document = "5634764",
                PhoneNumber = "34998765678",
                Password = "teste123"
            };

            await Assert.ThrowsAsync<ValidationException>(() => _service.SaveUserAsync(user));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("dhciuyripbhlmnekgaeblhrntlvvmfhyqgcxaiokbrspxctxygfdhciuyripbhlmnekgaeblhrntlvvmfhyqgcxaiokbrspxctxyg")]
        public async Task Theory_PostUser_FullName_ReturnError(string fullName)
        {
            var user = new UserRequest()
            {
                Email = "user@hotmail.com",
                FullName = fullName,
                Document = "5634764",
                PhoneNumber = "34998765678",
                Password = "teste123"
            };

            await Assert.ThrowsAsync<ValidationException>(() => _service.SaveUserAsync(user));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("dhci")]
        [InlineData("dhciuyripbhlmnek")]
        public async Task Theory_PostUser_Password_ReturnError(string password)
        {
            var user = new UserRequest()
            {
                Email = "user@hotmail.com",
                FullName = "Usuario Teste",
                Document = "5634764",
                PhoneNumber = "34998765678",
                Password = password
            };

            await Assert.ThrowsAsync<ValidationException>(() => _service.SaveUserAsync(user));
        }
        #endregion
        #region FACT
        [Fact]
        public async Task Fact_PostUser_ReturnSuccess()
        {
            // Arrange
            var user = new UserRequest()
            {
                Email = "user@hotmail.com",
                FullName = "Usuario Teste",
                Document = "5634764",
                PhoneNumber = "34998765678",
                Password = "teste123"
            };

            // Act
            var userSave = await _service.SaveUserAsync(user);
            
            // Assert
            Assert.Equal(2, userSave.Id);
            Assert.Equal(user.Email, userSave.Email);
            Assert.Equal(user.FullName, userSave.FullName);
            Assert.Equal(user.Document, userSave.Document);
            Assert.Equal(user.PhoneNumber, userSave.PhoneNumber);
        }

        [Fact]
        public async Task Fact_PostUser_EmailAlreadyExists_ReturnException()
        {
            // Arrange
            var user = new UserRequest()
            {
                Email = "user@hotmail.com",
                FullName = "Usuario Teste",
                Document = "5634764",
                PhoneNumber = "34998765678",
                Password = "teste123"
            };

            // Act
            var userSave = await _service.SaveUserAsync(user);

            // Assert
            Exception ex = await Assert.ThrowsAsync<Exception>(() => _service.SaveUserAsync(user));
            Assert.Equal(MessagesAPI.USER_ALREADY_EXISTS, ex.Message);
        }


        [Fact]
        public async Task Fact_PutUser_ReturnSuccess()
        {
            // Arrange
            var user = new UserUpdateRequest()
            {
                Id = 1,
                FullName = "Usuario Teste atualizado",
                Document = "5634765",
                PhoneNumber = "34998765674",
            };

            // Act
            var userUpdate = await _service.UpdateUserAsync(user);

            // Assert
            Assert.Equal(user.Id, userUpdate.Id);
            Assert.Equal(user.FullName, userUpdate.FullName);
            Assert.Equal(user.Document, userUpdate.Document);
            Assert.Equal(user.PhoneNumber, userUpdate.PhoneNumber);
        }
        #endregion

    }
}
