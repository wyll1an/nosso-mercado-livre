using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using NossoMercadoLivreAPI.Domain.Request.Base;

namespace NossoMercadoLivreAPI.Domain.Request
{
    public class UserProfileRequest : BaseRequest
    {
        [JsonIgnore]
        public override long Id { get; set; }

        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("profile_id")]
        public long ProfileId { get; set; }
    }
}
