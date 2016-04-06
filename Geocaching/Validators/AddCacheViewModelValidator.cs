using FluentValidation;
using Geocaching.App_GlobalResources;
using Geocaching.Filters;
using Geocaching.ViewModels;

namespace Geocaching.Validators
{
    [Culture]
    public class AddCacheViewModelValidator : AbstractValidator<AddCacheViewModel>
    {
        public AddCacheViewModelValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage(Resource.FieldCannotBeEmpty)
                .Length(1, 50)
                .WithMessage(Resource.LengthCacheName);
            RuleFor(p => p.Description).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty);
            RuleFor(p => p.Address.Longitude).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty);
            RuleFor(p => p.Address.Latitude).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty);
        }
    }
}