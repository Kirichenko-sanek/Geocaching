using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocaching.Core
{
    public class Photo : BaseEntity
    {
        public string name { get; set; }
        public DateTime date { get; set; }

        public virtual List<PhotoOfUser> photo_of_user { get; set; }
        public virtual List<PhotoOfListOfVisitedCaches> photo_of_list_of_visited_caches { get; set;}
        public virtual List<PhotoOfCaches> photo_of_caches { get; set; }

        public Photo()
        {
            photo_of_user = new List<PhotoOfUser>();
            photo_of_list_of_visited_caches = new List<PhotoOfListOfVisitedCaches>();
            photo_of_caches = new List<PhotoOfCaches>();
        }
    }
}
