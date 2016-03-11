using System;

namespace Geocaching.ViewModels
{
    public class CacheViewModel
    {
        public long Id { get; set; }
        public long IdUserCache { get; set; }
        public string UserName { get; set; }
        public string CacheName { get; set; }
        public string Photo { get; set; }
        public DateTime DateVisit { get; set; }
        public DateTime DateAdded { get; set; }
    }
}