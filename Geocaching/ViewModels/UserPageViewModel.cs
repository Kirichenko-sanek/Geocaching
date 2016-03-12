using System.Collections.Generic;

namespace Geocaching.ViewModels
{
    public class UserPageViewModel
    {
        public long IdUserInSystem { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }

        public List<CacheViewModel> LastVisitedCache { get; set; }
        public List<CacheViewModel> LastMyCache { get; set; }
    }
}