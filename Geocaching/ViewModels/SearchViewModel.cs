using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geocaching.ViewModels
{

    public class SearchViewModel
    {
        public string Name { get; set; }
        public AddressViewModel Address { get; set; }
        public List<CacheViewModel> Cache { get; set; }
    }
}