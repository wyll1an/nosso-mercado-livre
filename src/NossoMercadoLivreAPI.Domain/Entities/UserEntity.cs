using System;
using System.Collections.Generic;
using NossoMercadoLivreAPI.Domain.Entities.Base;

namespace NossoMercadoLivreAPI.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }

        public List<UserProfileEntity> UserProfiles { get; set; }
    }
}
