using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;

namespace Geocaching.Interfases.Manager
{
    public interface ICacheManager<T> : IManager<T> where T : Cache
    {
        IQueryable<Cache> GetCachesByIdUser(long id);
    }
}
