using FluentValidation;
using System;
using NossoMercadoLivreAPI.Domain.Request;
using NossoMercadoLivreAPI.Infra.Resources;

namespace NossoMercadoLivreAPI.Service.Validators
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateRequest>
    {
        public UserUpdateValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x => throw new ArgumentNullException(MessagesAPI.OBJECT_INVALID));

            RuleFor(c => c.FullName)
                .NotEmpty().WithMessage(MessagesAPI.FULL_NAME_REQUIRED)
                .NotNull().WithMessage(MessagesAPI.FULL_NAME_REQUIRED)
                .Length(1, 100).WithMessage(MessagesAPI.FULL_NAME_MIN_MAX);

            RuleFor(c => c.Document)
                .NotEmpty().WithMessage(MessagesAPI.DOCUMENT_REQUIRED)
                .NotNull().WithMessage(MessagesAPI.DOCUMENT_REQUIRED)
                .Length(6, 20).WithMessage(MessagesAPI.DOCUMENT_MIN_MAX);

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage(MessagesAPI.PHONE_NUMBER_REQUIRED)
                .NotNull().WithMessage(MessagesAPI.PHONE_NUMBER_REQUIRED)
                .Length(10, 11).WithMessage(MessagesAPI.PHONE_NUMBER_MIN_MAX);
        }
    }
}
