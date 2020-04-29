using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NossoMercadoLivreAPI.Domain.Request
{
    public class UserRequest
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Nome Completo é obrigatório.")]
        [StringLength(100, ErrorMessage = "Nome Completo deve ter entre {2} e {1} caracteres.", MinimumLength = 1)]
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail é inválido.")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Documento é obrigatório.")]
        [StringLength(20, ErrorMessage = "Documento deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]
        [JsonPropertyName("document")]
        public string Document { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [StringLength(11, ErrorMessage = "Telefone deve ter entre {2} e {1} caracteres.", MinimumLength = 10)]
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório.")]
        [StringLength(15, ErrorMessage = "Senha deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]
        [JsonPropertyName("password")]
        public string Password { get; set; }


    }
}
