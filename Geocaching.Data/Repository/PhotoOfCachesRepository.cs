using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;
using Geocaching.Interfases.Repository;

namespace Geocaching.Data.Repository
{
    public class PhotoOfCachesRepository<T> : Repository<T>, IPhotoOfCachesRepository<T> where T : PhotoOfCaches
    {
        public PhotoOfCachesRepository(DataContext context) : base(context)
        {
            
        } 
    }
}
