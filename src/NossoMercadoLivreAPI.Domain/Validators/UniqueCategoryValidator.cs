using Microsoft.Extensions.DependencyInjection;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivreAPI.Domain.Validators
{
    public class UniqueCategoryValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ICategoryRepository context = validationContext.GetService<ICategoryRepository>();

            bool result = context.CheckCategoryIsUnique(value.ToString());

            return result ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName)) : ValidationResult.Success;
        }
    }
}
