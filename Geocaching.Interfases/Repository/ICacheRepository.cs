﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Geocaching.Core;



namespace Geocaching.Interfases.Repository
{
    public interface ICacheRepository<T> : IRepository<T> where T : Cache
    {
        IQueryable<Cache> GetCachesByIdUser(long id);

        IQueryable<Cache> Search(string name, double longitude, double latityde, string country, string region,
            string city);

        IQueryable<Cache> SearchCacheUser(long id, string name, double longitude, double latityde,
            string country, string region,
            string city);
    }
}
