using FluentValidation;
using Geocaching.App_GlobalResources;
using Geocaching.Filters;
using Geocaching.ViewModels;

namespace Geocaching.Validators
{
    [Culture]
    public class RecoveryViewModelValidator : AbstractValidator<RecoveryViewModel>
    {
        public RecoveryViewModelValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty)
                .EmailAddress().WithMessage(Resource.WrongFormatEmail);
        }
    }
}