using FluentValidation.Attributes;
using Geocaching.Filters;
using Geocaching.Validators;

namespace Geocaching.ViewModels
{
    [Culture]
    [Validator(typeof(PassRecoveryViewModelValidator))]
    public class PassRecoveryViewModel
    {
        public string Email { get; set; }
        public string Error { get; set; }
    }
}