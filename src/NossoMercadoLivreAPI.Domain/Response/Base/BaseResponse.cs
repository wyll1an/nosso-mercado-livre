using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace NossoMercadoLivreAPI.Domain.Response.Base
{
    public abstract class BaseResponse
    {
        [JsonPropertyName("id")]
        public virtual long Id { get; set; }
    }
}
