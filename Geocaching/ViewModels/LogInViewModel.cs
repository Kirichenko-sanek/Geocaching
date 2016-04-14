using FluentValidation.Attributes;
using Geocaching.Filters;
using Geocaching.Validators;

namespace Geocaching.ViewModels
{
    [Culture]
    [Validator(typeof(LogInViewModelValidator))]
    public class LogInViewModel
    {
        public string EmailLogin { get; set; }
        public string PasswordLogin { get; set; }
        public string Error { get; set; }
    }
}