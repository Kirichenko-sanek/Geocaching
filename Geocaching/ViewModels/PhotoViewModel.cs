using System;

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