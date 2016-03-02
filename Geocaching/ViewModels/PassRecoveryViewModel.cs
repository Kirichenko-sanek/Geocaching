using FluentValidation.Attributes;
using Geocaching.Validators;

namespace Geocaching.ViewModels
{
    [Validator(typeof(PassRecoveryViewModelValidator))]
    public class PassRecoveryViewModel
    {
        public string Email { get; set; }
        public string Error { get; set; }
    }
}