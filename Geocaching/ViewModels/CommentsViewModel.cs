using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Attributes;
using Geocaching.Validators;

namespace Geocaching.ViewModels
{
    [Validator(typeof(CommentsViewModelValidator))]
    public class CommentsViewModel
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public long IdCache { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}