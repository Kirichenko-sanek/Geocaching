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

        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
    }
}