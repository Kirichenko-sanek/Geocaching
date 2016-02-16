using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocaching.Core
{
    public class PhotoOfCaches : BaseEntity
    {
        public long id_cache { get; set; }
        public long id_photo { get; set; }

        public virtual Cache cache { get; set; }
        public virtual Photo photo { get; set; }
    }
}
