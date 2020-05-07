using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace NossoMercadoLivreAPI.Domain.Validators
{
    public class UniqueUserValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IUserRepository context = validationContext.GetService<IUserRepository>();

            bool result = context.CheckUserIsUnique(value.ToString());

            return result ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName)) : ValidationResult.Success;
        }
    }
}
