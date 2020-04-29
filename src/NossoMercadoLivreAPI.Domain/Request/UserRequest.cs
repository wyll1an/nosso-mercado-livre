using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NossoMercadoLivreAPI.Domain.Request
{
    public class UserRequest
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail é inválido.")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório.")]
        [StringLength(15, ErrorMessage = "Senha deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]
        [JsonPropertyName("password")]
        public string Password { get; set; }


    }
}
