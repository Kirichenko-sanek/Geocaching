﻿using System;
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
    public class ListOfVisitedCachesManager<T> : Manager<T>,IListOfVisitedCachesManager<T> where T : ListOfVisitedCaches
    {
        private readonly IListOfVisitedCachesRepository<ListOfVisitedCaches> _listOfVisitedCachesRepository;

        public ListOfVisitedCachesManager(
            IListOfVisitedCachesRepository<ListOfVisitedCaches> listOfVisitedCachesRepository, IRepository<T> repository,
            IValidator<T> validator) : base(repository, validator)
        {
            _listOfVisitedCachesRepository = listOfVisitedCachesRepository;
        }

        public IQueryable<ListOfVisitedCaches> GetCacheByIdUser(long id)
        {
            return _listOfVisitedCachesRepository.GetCacheByIdUser(id);
        }
    }
}