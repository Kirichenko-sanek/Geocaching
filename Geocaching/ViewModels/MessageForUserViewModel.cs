using FluentValidation.Attributes;
using Geocaching.Validators;

namespace Geocaching.ViewModels
{
    [Validator(typeof(MessageForUserViewModelValidator))]
    public class MessageForUserViewModel
    {
        public string EmailUser { get; set; }
        public string Message { get; set; }
    }
}