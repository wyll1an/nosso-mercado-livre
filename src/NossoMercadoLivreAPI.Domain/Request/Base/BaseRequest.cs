using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace NossoMercadoLivreAPI.Domain.Request.Base
{
    public abstract class BaseRequest
    {
        [JsonPropertyName("id")]
        public virtual long Id { get; set; }
    }
}
