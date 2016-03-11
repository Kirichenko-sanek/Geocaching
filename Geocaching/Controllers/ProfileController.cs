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

        public ActionResult VisitedCache(ListVisitedCachesViewModel model, long id)
        {
            var visited_caches = _managerListOfVisitedCaches.GetCacheByIdUser(id).OrderByDescending( x => x.date);
            List<VisitedCacheViewModel> caches = new List<VisitedCacheViewModel>();
            foreach (var cache in visited_caches)
            {
                var photos_cache = _managerPhotoOfCaches.GetPhotoOfCachesByCacheId(cache.id);
                List<PhotoOfCachesViewModel> photos = new List<PhotoOfCachesViewModel>();
                foreach (var photo in photos_cache)
                {
                    photos.Add(Mapper.Map<PhotoOfCaches, PhotoOfCachesViewModel>(photo));
                   
                }

                //caches.Add(Mapper.Map<ListOfVisitedCaches, VisitedCacheViewModel>(cache));
                caches.Add(new VisitedCacheViewModel()
                {
                    Id = cache.id_cache,
                    Photo = photos[1].Name,
                    UserName = cache.user.first_name + " " + cache.user.last_name,
                    CacheName = cache.cache.name,
                    DateVisit = cache.date
                
                });
            }
            model.VisitedCache = caches;
            return View(model);
        }

    }
}