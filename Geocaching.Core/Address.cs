using System.Collections.Generic;

namespace Geocaching.Core
{
    public class Address : BaseEntity
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string city { get; set; }

        public virtual List<Cache> caches { get; set; }

        public Address()
        {
            caches = new List<Cache>();
        }
    }
}
