using AutoMapper;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Request;
using NossoMercadoLivreAPI.Domain.Response;

namespace NossoMercadoLivreAPI.Service.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserRequest, UserEntity>()
                .ForMember(dest =>
                    dest.PasswordHash,
                    opt => opt.MapFrom(src => src.Password));
            CreateMap<UserUpdateRequest, UserEntity>();
            CreateMap<UserEntity, UserResponse>();

            CreateMap<ProfileRequest, ProfileEntity>();
            CreateMap<ProfileEntity, ProfileResponse>();

            CreateMap<UserProfileRequest, UserProfileEntity>();
            CreateMap<UserProfileEntity, UserProfileResponse>();
        }
    }
}