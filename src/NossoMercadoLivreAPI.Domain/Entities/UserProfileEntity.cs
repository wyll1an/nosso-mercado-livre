using NossoMercadoLivreAPI.Domain.Entities.Base;

namespace NossoMercadoLivreAPI.Domain.Entities
{
    public class UserProfileEntity : BaseEntity
    {
        public long UserId { get; set; }
        public UserEntity User { get; set; }

        public long ProfileId { get; set; }
        public ProfileEntity Profile { get; set; }
    }
}
