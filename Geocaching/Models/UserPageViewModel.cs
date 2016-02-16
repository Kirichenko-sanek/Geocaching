using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geocaching.Models
{
    public class UserPageViewModel
    {
        public long IdUserInSystem { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }

    }
}