using NossoMercadoLivreAPI.Domain.Validators;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NossoMercadoLivreAPI.Domain.Request
{
    public class UserRequest
    {
        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail é inválido.")]
        [UniqueUserValidator(ErrorMessage = "Usuário com este e-mail já existe.")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório.")]
        [StringLength(15, ErrorMessage = "Senha deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]
        [JsonPropertyName("password")]
        public string Password { get; set; }


    }
}
