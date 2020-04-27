using System.Collections.Generic;
using NossoMercadoLivreAPI.Domain.Entities.Base;

namespace NossoMercadoLivreAPI.Domain.Entities
{
    public class ProfileEntity : BaseEntity
    {
        public string Description { get; set; }

        public IEnumerable<UserProfileEntity> UserProfiles { get; set; }
    }
}
