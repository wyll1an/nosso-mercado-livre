using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using NossoMercadoLivreAPI.Domain.Response.Base;

namespace NossoMercadoLivreAPI.Domain.Response
{
    public class UserProfileResponse : BaseResponse
    {
        [JsonIgnore]
        public override long Id { get; set; }
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("profile_id")]
        public long ProfileId { get; set; }

    }
}
