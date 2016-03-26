using System.Collections.Generic;

namespace Geocaching.ViewModels
{
    public class MyCachesViewModel
    {
        public List<CacheViewModel> MyCache { get; set; } 
        public AddressViewModel Address { get; set; }
        public string Name { get; set; }
    }
}