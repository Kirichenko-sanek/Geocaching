using FluentValidation.Attributes;
using Geocaching.Filters;
using Geocaching.Validators;

namespace Geocaching.ViewModels
{
    [Culture]
    [Validator(typeof(EditProfileViewModelValidator))]
    public class EditProfileViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}