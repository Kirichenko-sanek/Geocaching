using FluentValidation;
using Geocaching.App_GlobalResources;
using Geocaching.Filters;
using Geocaching.ViewModels;

namespace Geocaching.Validators
{
    [Culture]
    public class LogInViewModelValidator : AbstractValidator<LogInViewModel>
    {
        public LogInViewModelValidator()
        {
            RuleFor(p => p.EmailLogin).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty)
                .EmailAddress().WithMessage(Resource.WrongFormatEmail);
            RuleFor(p => p.PasswordLogin).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty);
        }
    }
}