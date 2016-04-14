using System;

namespace Geocaching.Core
{
    public class ListOfVisitedCaches : BaseEntity
    {
        public long id_user { get; set; }
        public long id_cache { get; set; }
        public DateTime date { get; set; }

        public virtual User user { get; set; }
        public virtual Cache cache { get; set; }

    }
}
