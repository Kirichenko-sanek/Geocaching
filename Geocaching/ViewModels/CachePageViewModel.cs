using System;
using System.Collections.Generic;

namespace Geocaching.ViewModels
{
    public class CachePageViewModel
    {
        public long IdUserInSystem { get; set; }
        public long IdCache { get; set; }
        public long IdUserCache { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfApperance { get; set; }
        public DateTime DateOfLastVisit { get; set; }
        public string UserName { get; set; }
        public List<PhotoViewModel> Photos { get; set; } 
        public string MainPhoto { get; set; }
        public List<CommentsViewModel> Comments { get; set; }
        public string NewComment { get; set; }
        public string NewPhoto { get; set; }
        public CacheViewModel Visit { get; set; }
        


        public AddressViewModel Address { get; set; }


    }
}