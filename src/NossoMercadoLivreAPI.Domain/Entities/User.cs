﻿using NossoMercadoLivreAPI.Domain.Request;
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
            Email = userRequest.Email;
            Password = BCrypt.Net.BCrypt.HashPassword(userRequest.Password);
        }

        public User(string email, string password)
        {
            Email = email;
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public long Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
