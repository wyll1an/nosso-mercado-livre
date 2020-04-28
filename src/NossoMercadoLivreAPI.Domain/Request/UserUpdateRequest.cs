using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using NossoMercadoLivreAPI.Domain.Request.Base;

namespace NossoMercadoLivreAPI.Domain.Request
{
    public class UserUpdateRequest : BaseRequest
    {
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }
        [JsonPropertyName("document")]
        public string Document { get; set; }
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
