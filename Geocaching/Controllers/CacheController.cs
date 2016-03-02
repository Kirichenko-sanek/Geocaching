using System;
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

        public CacheController(ICacheManager<Cache> managerCache)
        {
            _managerCache = managerCache;
        }

        [AllowAnonymous]
        public ActionResult CachePage(CachePageViewModel model, long id)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                var cache = _managerCache.GetById(id);
                model = Mapper.Map<Cache, CachePageViewModel>(cache);
                return View(model);
            }
            catch (Exception)
            {

                return View();
            }
           
        }


    }
}