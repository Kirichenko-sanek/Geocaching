using FluentValidation;
using Geocaching.App_GlobalResources;
using Geocaching.Filters;
using Geocaching.ViewModels;

namespace Geocaching.Validators
{
    public class LogInViewModelValidator : AbstractValidator<LogInViewModel>
    {
        public LogInViewModelValidator()
        {
            RuleFor(p => p.EmailLogin).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty)
                .EmailAddress().WithLocalizedMessage(() => Resource.WrongFormatEmail);
            RuleFor(p => p.PasswordLogin).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty);
        }
    }
}