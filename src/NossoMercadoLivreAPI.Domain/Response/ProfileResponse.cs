using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using NossoMercadoLivreAPI.Domain.Response.Base;

namespace NossoMercadoLivreAPI.Domain.Response
{
    public class ProfileResponse : BaseResponse
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
