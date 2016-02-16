using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocaching.Core
{
    public class Cache : BaseEntity
    {
        public long id_user { get; set; }
        public long id_address { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime date_of_apperance { get; set; }
        public DateTime date_of_last_visit { get; set; }
       
        public virtual User user { get; set; }
        public virtual Address address { get; set; }

        public virtual List<PhotoOfCaches> photo_of_caches { get; set; }
        public virtual List<ListOfVisitedCaches> list_of_visited_caches { get; set; }
        public virtual List<Comment> comments { get; set; }

        public Cache()
        {
            photo_of_caches = new List<PhotoOfCaches>();
            list_of_visited_caches = new List<ListOfVisitedCaches>();
            comments = new List<Comment>();
        }
    }
}
