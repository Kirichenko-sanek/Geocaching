using System;
using FluentValidation.Attributes;
using Geocaching.Validators;

namespace Geocaching.ViewModels
{
    [Validator(typeof(AddCacheViewModelValidator))]
    public class AddCacheViewModel
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfApperance { get; set; }
        public DateTime DateOfLastVisit { get; set; }
        public string Photo { get; set; }

        public AddressViewModel Address { get; set; }
    }
}