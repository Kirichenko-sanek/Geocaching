using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;
using Geocaching.Interfases.Repository;

namespace Geocaching.Data.Repository
{
    public class PhotoOfListOfVisitedCachesRepository<T> : Repository<T>, IPhotoOfListOfVisitedCachesRepository<T> where T : PhotoOfListOfVisitedCaches
    {
        public PhotoOfListOfVisitedCachesRepository(DataContext context) : base(context)
        {
            
        } 
    }
}
