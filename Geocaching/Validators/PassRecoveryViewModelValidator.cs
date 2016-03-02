using FluentValidation;
using Geocaching.App_GlobalResources;
using Geocaching.ViewModels;

namespace Geocaching.Validators
{
    public class PassRecoveryViewModelValidator : AbstractValidator<PassRecoveryViewModel>
    {
        public PassRecoveryViewModelValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty)
                .EmailAddress().WithLocalizedMessage(() => Resource.WrongFormatEmail);
        }
    }
}