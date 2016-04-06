using FluentValidation;
using Geocaching.App_GlobalResources;
using Geocaching.Filters;
using Geocaching.ViewModels;

namespace Geocaching.Validators
{
    [Culture]
    public class MessageForUserViewModelValidator : AbstractValidator<MessageForUserViewModel>
    {
        public MessageForUserViewModelValidator()
        {
            RuleFor(p => p.EmailUser).EmailAddress().WithMessage(Resource.WrongFormatEmail);
        }
    }
}