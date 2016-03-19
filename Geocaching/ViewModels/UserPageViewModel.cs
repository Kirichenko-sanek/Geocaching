using System.Collections.Generic;
using FluentValidation.Attributes;
using Geocaching.Validators;

namespace Geocaching.ViewModels
{
    public class UserPageViewModel
    {
        public long IdUserPage { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string NewPhoto { get; set; }
        public List<PhotoViewModel> LastUserPhoto { get; set; }
        public List<CacheViewModel> LastVisitedCache { get; set; }
        public List<CacheViewModel> LastMyCache { get; set; }        
    }
}