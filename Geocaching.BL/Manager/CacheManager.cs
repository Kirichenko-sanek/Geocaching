using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;
using Geocaching.Interfases.Manager;
using Geocaching.Interfases.Repository;
using Geocaching.Interfases.Validator;

namespace Geocaching.BL.Manager
{
    public class CacheManager<T> : Manager<T>, ICacheManager<T> where T : Cache
    {
        private readonly ICacheRepository<Cache> _cacheRepository; 

        public CacheManager(ICacheRepository<Cache> cacheRepository,IRepository<T> repository,IValidator<T> validator) : base(repository, validator)
        {
            _cacheRepository = cacheRepository;
        }
    }
}
