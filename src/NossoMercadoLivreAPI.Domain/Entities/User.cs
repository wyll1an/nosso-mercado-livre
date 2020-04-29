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
            FullName = userRequest.FullName;
            Email = userRequest.Email;
            Document = userRequest.Document;
            PhoneNumber = userRequest.PhoneNumber;
            Password = userRequest.Password;
            CreatedDate = DateTime.Now;
        }

        public User(long id, string fullName, string email, string document, string phoneNumber, string password)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Document = document;
            PhoneNumber = phoneNumber;
            Password = password;
            CreatedDate = DateTime.Now;
        }

        public long Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Document { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedDate { get; private set; }
    }
}
