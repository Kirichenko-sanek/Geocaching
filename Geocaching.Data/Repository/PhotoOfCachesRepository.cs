﻿using System;
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

        public IQueryable<PhotoOfCaches> GetPhotoOfCachesByCacheId(long idCache)
        {
            return _context.PhotoOfCaches.Where(x => x.id_cache == idCache);
        }

        public PhotoOfCaches GetPhootOfCachesByPhoto(long idPhoto)
        {
            return _context.PhotoOfCaches.FirstOrDefault(x => x.id_photo == idPhoto);
        }
    }
}
