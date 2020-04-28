﻿using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using NossoMercadoLivreAPI.Domain.Request.Base;

namespace NossoMercadoLivreAPI.Domain.Request
{
    public class ProfileRequest : BaseRequest
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}