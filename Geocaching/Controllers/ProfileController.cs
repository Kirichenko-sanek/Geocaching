using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Geocaching.Core;
using Geocaching.Filters;
using Geocaching.Interfases.Manager;
using Geocaching.ViewModels;

namespace Geocaching.Controllers
{
    [Culture]
    public class ProfileController : Controller
    {
        private readonly IUserManager<User> _managerUser;
        private readonly IPhotoOfUserManager<PhotoOfUser> _managerPhotoOfUser;
        private readonly IListOfVisitedCachesManager<ListOfVisitedCaches> _managerListOfVisitedCaches;
        private readonly ICacheManager<Cache> _managerCache;
        private readonly IPhotoOfCachesManager<PhotoOfCaches> _managerPhotoOfCaches;

        public ProfileController(IUserManager<User> managerUser, IPhotoOfUserManager<PhotoOfUser> managerPhotoOfUser,
            IListOfVisitedCachesManager<ListOfVisitedCaches> managerListOfVisitedCaches,
            ICacheManager<Cache> managerCache, IPhotoOfCachesManager<PhotoOfCaches> managerPhotoOfCaches)
        {
            _managerUser = managerUser;
            _managerPhotoOfUser = managerPhotoOfUser;
            _managerListOfVisitedCaches = managerListOfVisitedCaches;
            _managerCache = managerCache;
            _managerPhotoOfCaches = managerPhotoOfCaches;
        }

        public ActionResult UserPage(long? id)
        {
            if (id != null) return UserPage(new UserPageViewModel(), id);
            var user = _managerUser.GetUserByEmail(User.Identity.Name);
            Session["UserId"] = user.id;
            return UserPage(new UserPageViewModel(), user.id);           
        }
        
        [HttpPost]
        public ActionResult UserPage(UserPageViewModel model, long? id)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                var user = _managerUser.GetById((long)id);
                var photo_user = _managerPhotoOfUser.GetPhotoUserByUserId(user.id);
                model = Mapper.Map<User, UserPageViewModel>(user);
                model.Photo = photo_user.photo.name;
                return View(model);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult VisitedCache(ListVisitedCachesViewModel model, long id)
        {
            
                var visited_caches = _managerListOfVisitedCaches.GetCacheByIdUser(id).OrderByDescending(x => x.date);
                List<CacheViewModel> caches = new List<CacheViewModel>();
                List<PhotoOfCachesViewModel> photos = new List<PhotoOfCachesViewModel>();

                foreach (var cache in visited_caches)
                {
                    var photos_cache = _managerPhotoOfCaches.GetPhotoOfCachesByCacheId(cache.id);
                    //photos.Clear();
                    foreach (var photo in photos_cache)
                    {
                        photos.Add(Mapper.Map<PhotoOfCaches, PhotoOfCachesViewModel>(photo));

                    }

                    var a = Mapper.Map<ListOfVisitedCaches, CacheViewModel>(cache);
                    a.Photo = photos[0].Name;

                    caches.Add(a);
                }
                model.VisitedCache = caches;
                return View(model);
            
        }

        [AllowAnonymous]
        public ActionResult MyCaches(MyCachesVievModel model, long id)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                var my_caches = _managerCache.GetCachesByIdUser(id).OrderByDescending(x => x.date_of_apperance);
                List<CacheViewModel> caches = new List<CacheViewModel>();
                List<PhotoOfCachesViewModel> photos = new List<PhotoOfCachesViewModel>();

                foreach (var cache in my_caches)
                {
                    var photos_cache = _managerPhotoOfCaches.GetPhotoOfCachesByCacheId(cache.id);
                    photos.Clear();
                    foreach (var photo in photos_cache)
                    {
                        photos.Add(Mapper.Map<PhotoOfCaches, PhotoOfCachesViewModel>(photo));

                    }

                    var a = Mapper.Map<Cache, CacheViewModel>(cache);
                    a.Photo = photos[0].Name;

                    caches.Add(a);
                }
                model.MyCache = caches;
                return View(model);
            }
            catch (Exception)
            {
                return View();
            }
        }

    }
}