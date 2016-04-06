using FluentValidation;
using Geocaching.App_GlobalResources;
using Geocaching.Filters;
using Geocaching.ViewModels;

namespace Geocaching.Validators
{
    [Culture]
    class CommentsViewModelValidator : AbstractValidator<CommentsViewModel>
    {
        public CommentsViewModelValidator()
        {
            RuleFor(p => p.Description).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty);
        }
    }
}