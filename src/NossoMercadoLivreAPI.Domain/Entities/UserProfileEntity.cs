using NossoMercadoLivreAPI.Domain.Entities.Base;

namespace NossoMercadoLivreAPI.Domain.Entities
{
    public class UserProfileEntity : BaseEntity
    {
        public UserProfileEntity()
        {
        }

        public UserProfileEntity(long userId, long profileId)
        {
            this.UserId = userId;
            this.ProfileId = profileId;
        }

        public long UserId { get; set; }
        public UserEntity User { get; set; }

        public long ProfileId { get; set; }
        public ProfileEntity Profile { get; set; }
    }
}
