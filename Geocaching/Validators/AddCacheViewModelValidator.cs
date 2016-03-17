using FluentValidation;
using Geocaching.App_GlobalResources;
using Geocaching.ViewModels;

namespace Geocaching.Validators
{
    
    public class AddCacheViewModelValidator : AbstractValidator<AddCacheViewModel>
    {
        public AddCacheViewModelValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithLocalizedMessage(() => Resource.FieldCannotBeEmpty)
                .Length(1, 50)
                .WithLocalizedMessage(() => Resource.LengthCacheName);
            RuleFor(p => p.Description).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty);
            RuleFor(p => p.Longitude).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty);
            RuleFor(p => p.Latitude).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty);
        }
    }
}