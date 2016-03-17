using FluentValidation;
using Geocaching.App_GlobalResources;
using Geocaching.ViewModels;

namespace Geocaching.Validators
{
    public class EditPassViewModelValidator : AbstractValidator<EditPassViewModel>
    {
        public EditPassViewModelValidator()
        {
            RuleFor(p => p.Password).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty);
            RuleFor(p => p.NewPassword).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty)
                .Length(6, 20).WithLocalizedMessage(() => Resource.PasswordLenght);
            RuleFor(p => p.ConfirmNewPassword).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty)
                .Equal(p => p.NewPassword).WithLocalizedMessage(() => Resource.PassMismatch);
        }
    }
}