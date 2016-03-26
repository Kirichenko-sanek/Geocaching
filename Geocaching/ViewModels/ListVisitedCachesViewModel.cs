using System.Collections.Generic;

namespace Geocaching.ViewModels
{
    public class ListVisitedCachesViewModel
    {
        public List<CacheViewModel> VisitedCache { get; set; }
        public AddressViewModel Address { get; set; }
        public string Name { get; set; }
    }
}