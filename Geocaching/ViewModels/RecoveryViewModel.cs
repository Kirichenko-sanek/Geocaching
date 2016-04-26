using FluentValidation.Attributes;
using Geocaching.Filters;
using Geocaching.Validators;

namespace Geocaching.ViewModels
{
    [Culture]
    [Validator(typeof(RecoveryViewModelValidator))]
    public class RecoveryViewModel
    {
        public string Email { get; set; }
        public string Error { get; set; }
    }
}