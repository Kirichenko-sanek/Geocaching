using FluentValidation;
using Geocaching.App_GlobalResources;
using Geocaching.Filters;
using Geocaching.ViewModels;

namespace Geocaching.Validators
{
    [Culture]
    class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty)
                .Length(1, 20).WithMessage(Resource.Length);
            RuleFor(p => p.LastName).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty)
                .Length(1, 20).WithMessage(Resource.Length);
            RuleFor(p => p.Email).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty)
                .EmailAddress().WithMessage(Resource.WrongFormatEmail);
            RuleFor(p => p.Password).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty)
                .Length(6, 20).WithMessage(Resource.PasswordLenght);
            RuleFor(p => p.ConfirmPassword).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty)
                .Equal(p => p.Password).WithMessage(Resource.PassMismatch);
        }
    }
}
