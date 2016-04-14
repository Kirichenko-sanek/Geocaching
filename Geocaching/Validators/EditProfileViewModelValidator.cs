using FluentValidation;
using Geocaching.App_GlobalResources;
using Geocaching.Filters;
using Geocaching.ViewModels;

namespace Geocaching.Validators
{

    [Culture]
    public class EditProfileViewModelValidator : AbstractValidator<EditProfileViewModel>
    {
        public EditProfileViewModelValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty)
               .Length(1, 20).WithMessage(Resource.Length);
            RuleFor(p => p.LastName).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty)
                .Length(1, 20).WithMessage(Resource.Length);
            RuleFor(p => p.Email).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty)
                .EmailAddress().WithMessage(Resource.WrongFormatEmail);
        }
    }
}