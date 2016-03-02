using System;

namespace Geocaching.ViewModels
{
    public class CachePageViewModel
    {
        public long IdCache { get; set; }
        public long IdUserCache { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfApperance { get; set; }
        public DateTime DateOfLastVisit { get; set; }
        public string UserName { get; set; }

        public string Map { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }


    }
}