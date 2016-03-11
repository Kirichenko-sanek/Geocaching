using System;

namespace Geocaching.ViewModels
{
    public class VisitedCacheViewModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string CacheName { get; set; }
        public string Photo { get; set; }
        public DateTime DateVisit { get; set; }
    }
}