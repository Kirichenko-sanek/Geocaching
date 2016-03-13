using FluentValidation;
using Geocaching.App_GlobalResources;
using Geocaching.ViewModels;

namespace Geocaching.Validators
{
    public class EditProfileViewModelValidator : AbstractValidator<EditProfileViewModel>
    {
        public EditProfileViewModelValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty)
               .Length(1, 20).WithLocalizedMessage(() => Resource.Length);
            RuleFor(p => p.LastName).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty)
                .Length(1, 20).WithLocalizedMessage(() => Resource.Length);
            RuleFor(p => p.Email).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty)
                .EmailAddress().WithLocalizedMessage(() => Resource.WrongFormatEmail);
        }
    }
}