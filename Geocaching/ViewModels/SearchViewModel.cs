using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geocaching.ViewModels
{

    public class SearchViewModel
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public List<CacheViewModel> Cache { get; set; }
    }
}