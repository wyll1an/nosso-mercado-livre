using NossoMercadoLivreAPI.Domain.Validators;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NossoMercadoLivreAPI.Domain.Request
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [UniqueCategoryValidator(ErrorMessage = "Nome desta categoria já existe.")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("category_id")]
        public long? CategoryId { get; set; }
    }
}
