using FluentValidation;
using System;
using NossoMercadoLivreAPI.Domain.Request;
using NossoMercadoLivreAPI.Infra.Resources;

namespace NossoMercadoLivreAPI.Service.Validators
{
    public class UserProfileValidator : AbstractValidator<UserProfileRequest>
    {
        public UserProfileValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x => throw new ArgumentNullException(MessagesAPI.OBJECT_INVALID));

            RuleFor(c => c.UserId)
                .NotNull().WithMessage(MessagesAPI.USER_REQUIRED);
               
            RuleFor(c => c.ProfileId)
                .NotNull().WithMessage(MessagesAPI.PROFILE_REQUIRED);

        }
    }
}
