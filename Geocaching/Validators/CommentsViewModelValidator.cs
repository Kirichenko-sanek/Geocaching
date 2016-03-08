using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Geocaching.App_GlobalResources;
using Geocaching.ViewModels;

namespace Geocaching.Validators
{
    class CommentsViewModelValidator : AbstractValidator<CommentsViewModel>
    {
        public CommentsViewModelValidator()
        {
            RuleFor(p => p.Description).NotEmpty().WithLocalizedMessage(() => Resource.FieldCannotBeEmpty);
        }
    }
}