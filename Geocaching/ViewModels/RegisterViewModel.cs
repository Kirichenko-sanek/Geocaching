using FluentValidation.Attributes;
using Geocaching.Validators;

namespace Geocaching.ViewModels
{
    [Validator(typeof(RegisterViewModelValidator))]
    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Photo { get; set; }
        public string Error { get; set; }
    }
}