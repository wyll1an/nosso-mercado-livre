using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using NossoMercadoLivreAPI.Domain.Response.Base;

namespace NossoMercadoLivreAPI.Domain.Response
{
    public class UserResponse : BaseResponse
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
        [JsonPropertyName("user_profiles")]
        public IEnumerable<UserProfileResponse> UserProfiles { get; set; }
    }
}
