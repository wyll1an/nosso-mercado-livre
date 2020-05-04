using NossoMercadoLivreAPI.Domain.Request;
using System;
using System.Text.Json.Serialization;

namespace NossoMercadoLivreAPI.Domain.Entities
{
    public class User
    {
        /// <summary>
        ///  O campo password deve ser passado sem criptografia.
        /// </summary>
        /// <param name="userRequest"></param>
        public User(UserRequest userRequest)
        {
            Email = userRequest.Email;
            Password = BCrypt.Net.BCrypt.HashPassword(userRequest.Password);
        }

        public long Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
