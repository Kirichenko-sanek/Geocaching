using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geocaching.ViewModels
{
    public class PhotoViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public long IDUserAdded { get; set; }
    }
}