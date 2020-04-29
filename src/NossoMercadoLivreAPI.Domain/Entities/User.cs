using NossoMercadoLivreAPI.Domain.Request;
using System;
using System.Text.Json.Serialization;

namespace NossoMercadoLivreAPI.Domain.Entities
{
    public class User
    {
        public User()
        {}

        public User(UserRequest userRequest)
        {
            Id = userRequest.Id;
            Email = userRequest.Email;
            Password = userRequest.Password;
        }

        public User(long id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public long Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
