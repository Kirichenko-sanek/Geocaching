using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocaching.Core
{
    public class ListOfVisitedCaches : BaseEntity
    {
        public long id_user { get; set; }
        public long id_cache { get; set; }
        public DateTime date { get; set; }
        public string discription { get; set; }

        public virtual User user { get; set; }
        public virtual Cache cache { get; set; }

    }
}
