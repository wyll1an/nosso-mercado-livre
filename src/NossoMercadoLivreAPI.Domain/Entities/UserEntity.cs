using System;
using System.Collections.Generic;
using NossoMercadoLivreAPI.Domain.Entities.Base;
using NossoMercadoLivreAPI.Domain.Request;

namespace NossoMercadoLivreAPI.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity()
        {
        }

        /// <summary>
        /// Construtor para update de usuário.
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="document"></param>
        /// <param name="phoneNumber"></param>
        public UserEntity(UserUpdateRequest userUpdate, UserEntity userEntity)
        {
            this.Id = userEntity.Id;
            this.CreatedDate = userEntity.CreatedDate;
            this.UpdatedDate = userEntity.UpdatedDate;
            this.Email = userEntity.Email;
            this.PasswordHash = userEntity.PasswordHash;
            this.UserProfiles = userEntity.UserProfiles;
            this.FullName = userUpdate.FullName;
            this.Document = userUpdate.Document;
            this.PhoneNumber = userUpdate.PhoneNumber;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }

        public List<UserProfileEntity> UserProfiles { get; set; }
    }
}
