using FluentValidation.Attributes;
using Geocaching.Filters;
using Geocaching.Validators;

namespace Geocaching.ViewModels
{
    [Culture]
    [Validator(typeof(EditPassViewModelValidator))]
    public class EditPassViewModel
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public string Error { get; set; }
    }
}