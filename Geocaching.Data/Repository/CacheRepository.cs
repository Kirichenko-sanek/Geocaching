using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;
using Geocaching.Interfases.Repository;


namespace Geocaching.Data.Repository
{
    public class CacheRepository<T> : Repository<T>, ICacheRepository<T> where T : Cache
    {
        public CacheRepository(DataContext context) : base(context)
        {
            
        }

    }
}
