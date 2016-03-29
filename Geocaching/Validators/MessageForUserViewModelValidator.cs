using FluentValidation;
using Geocaching.App_GlobalResources;
using Geocaching.ViewModels;

namespace Geocaching.Validators
{
    public class MessageForUserViewModelValidator : AbstractValidator<MessageForUserViewModel>
    {
        public MessageForUserViewModelValidator()
        {
            RuleFor(p => p.EmailUser).EmailAddress().WithLocalizedMessage(() => Resource.WrongFormatEmail);
        }
    }
}