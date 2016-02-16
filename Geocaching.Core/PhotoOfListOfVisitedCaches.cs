using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocaching.Core
{
    public class PhotoOfListOfVisitedCaches : BaseEntity
    {
        public long id_list { get; set; }
        public long id_photo { get; set; }

        public virtual ListOfVisitedCaches list { get; set; }
        public virtual Photo photo { get; set; }
    }
}
