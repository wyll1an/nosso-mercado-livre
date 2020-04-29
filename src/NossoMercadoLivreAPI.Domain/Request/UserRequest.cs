using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace NossoMercadoLivreAPI.Domain.Request
{
    public class UserRequest
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("document")]
        public string Document { get; set; }
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }   
        [JsonPropertyName("password")]
        public string Password { get; set; }


    }
}
