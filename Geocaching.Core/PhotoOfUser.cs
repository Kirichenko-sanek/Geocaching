using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocaching.Core
{
    public class PhotoOfUser : BaseEntity
    {
        public long id_user { get; set; }
        public long id_photo { get; set; }

        public virtual User user { get; set; }
        public virtual Photo photo { get; set; }
    }
}
