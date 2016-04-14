using FluentValidation;
using Geocaching.App_GlobalResources;
using Geocaching.Filters;
using Geocaching.ViewModels;

namespace Geocaching.Validators
{
    [Culture]
    public class EditPassViewModelValidator : AbstractValidator<EditPassViewModel>
    {
        public EditPassViewModelValidator()
        {
            RuleFor(p => p.Password).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty);
            RuleFor(p => p.NewPassword).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty)
                .Length(6, 20).WithMessage(Resource.PasswordLenght);
            RuleFor(p => p.ConfirmNewPassword).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty)
                .Equal(p => p.NewPassword).WithMessage(Resource.PassMismatch);
        }
    }
}