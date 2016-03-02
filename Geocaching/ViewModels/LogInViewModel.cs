using FluentValidation.Attributes;
using Geocaching.Validators;

namespace Geocaching.ViewModels
{
    [Validator(typeof(LogInViewModelValidator))]
    public class LogInViewModel
    {
        public string EmailLogin { get; set; }
        public string PasswordLogin { get; set; }
        public string Error { get; set; }
    }
}