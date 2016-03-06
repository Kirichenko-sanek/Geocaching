using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Geocaching.Core;
using Geocaching.Filters;
using Geocaching.Interfases.Manager;
using Geocaching.ViewModels;
using WebGrease;

namespace Geocaching.Controllers
{
    [Culture]
    public class CacheController : Controller
    {
        private readonly ICacheManager<Cache> _managerCache;
        private readonly IPhotoOfCachesManager<PhotoOfCaches> _managerPhotoOfCaches; 
        

        public CacheController(ICacheManager<Cache> managerCache, IPhotoOfCachesManager<PhotoOfCaches> managerPhotoOfCaches)
        {
            _managerCache = managerCache;
            _managerPhotoOfCaches = managerPhotoOfCaches;
        }

        [AllowAnonymous]
        public ActionResult CachePage(CachePageViewModel model, long id)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                var cache = _managerCache.GetById(id);
                model = Mapper.Map<Cache, CachePageViewModel>(cache);

                var photos_cache = _managerPhotoOfCaches.GetPhotoOfCachesByCacheId(cache.id);
                List<PhotoOfCachesViewModel> photos = new List<PhotoOfCachesViewModel>();
                foreach (var photo in photos_cache)
                {                  
                    photos.Add(Mapper.Map<PhotoOfCaches, PhotoOfCachesViewModel>(photo));
                }
                model.Photos = photos;

                return View(model);
            }
            catch (Exception)
            {

                return View();
            }
           
        }


    }
}