using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;
using Geocaching.Interfases.Repository;

namespace Geocaching.Data.Repository
{
    public class PhotoRepository<T> : Repository<T>, IPhotoRepository<T> where T : Photo
    {
        public PhotoRepository(DataContext context) : base(context)
        {
            
        } 
    }
}
