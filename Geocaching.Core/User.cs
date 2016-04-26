using System.Collections.Generic;

namespace Geocaching.Core
{
    public class User : BaseEntity
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string password_salt { get; set; }
        public bool is_activated { get; set; }
        public bool is_deleted { get; set; }

        public virtual List<UserInRoles> users { get; set; }
        public virtual List<Cache> caches { get; set; }
        public virtual List<Comment> comments { get; set; }
        public virtual List<PhotoOfUser> photos_of_user { get; set; }
        public virtual List<ListOfVisitedCaches> list_of_visited_cache { get; set; } 


        public User()
        {
            users = new List<UserInRoles>();
            caches = new List<Cache>();
            comments = new List<Comment>();
            photos_of_user = new List<PhotoOfUser>();
            list_of_visited_cache = new List<ListOfVisitedCaches>();            
        }
    }
}
