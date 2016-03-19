using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Geocaching.BL;
using Geocaching.Core;
using Geocaching.Filters;
using Geocaching.Interfases.Manager;
using Geocaching.ViewModels;

namespace Geocaching.Controllers
{
    [Culture]
    public class CacheController : Controller
    {
        private readonly ICacheManager<Cache> _managerCache;
        private readonly IPhotoOfCachesManager<PhotoOfCaches> _managerPhotoOfCaches;
        private readonly ICommentsManager<Comment> _managerComments;
        private readonly IListOfVisitedCachesManager<ListOfVisitedCaches> _managerListOfVisitedCaches;


        public CacheController(ICacheManager<Cache> managerCache,
            IPhotoOfCachesManager<PhotoOfCaches> managerPhotoOfCaches, ICommentsManager<Comment> managerComments,
            IListOfVisitedCachesManager<ListOfVisitedCaches> managerListOfVisitedCaches)
        {
            _managerCache = managerCache;
            _managerPhotoOfCaches = managerPhotoOfCaches;
            _managerComments = managerComments;
            _managerListOfVisitedCaches = managerListOfVisitedCaches;
        }

        [AllowAnonymous]
        public ActionResult CachePage(CachePageViewModel model, long id)
        {
           
            try
            {
                if (!ModelState.IsValid) return View();
                var cache = _managerCache.GetById(id);
                model = Mapper.Map<Cache, CachePageViewModel>(cache);
                model.IdUserInSystem = Convert.ToInt64(Session["UserId"]);
                var photos_cache = _managerPhotoOfCaches.GetPhotoOfCachesByCacheId(cache.id);
                List<PhotoViewModel> photos = new List<PhotoViewModel>();
                foreach (var photo in photos_cache)
                {                  
                    photos.Add(Mapper.Map<PhotoOfCaches, PhotoViewModel>(photo));
                }
                model.Photos = photos;
                model.MainPhoto =  photos[0].Name;

                var comments_cache = _managerComments.GetCommentsByCacheId(cache.id).OrderByDescending(x => x.date);
                List<CommentsViewModel> comments = new List<CommentsViewModel>();
                foreach (var comment in comments_cache)
                {
                    comments.Add(Mapper.Map<Comment, CommentsViewModel>(comment));
                }
                model.Comments = comments;

                return View(model);
            }
            catch (Exception)
            {

                return View();
            }
           
        }

        [AllowAnonymous]
        public ActionResult AddComment(CachePageViewModel model)
        {
            try
            {
                var entity = Mapper.Map<CachePageViewModel, Comment>(model);
                _managerComments.Add(entity);
                return RedirectToAction("CachePage", new { id = model.IdCache });
            }
            catch (Exception)
            {
                return RedirectToAction("CachePage", new { id = model.IdCache });
            }
           
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Visit(CachePageViewModel model)
        {
            var entity = Mapper.Map<CachePageViewModel, ListOfVisitedCaches>(model);
            entity.id_user = Convert.ToInt64(Session["UserId"]);
            var entityCache = _managerCache.GetById(entity.id_cache);


            _managerListOfVisitedCaches.Add(entity);

            entity.cache.date_of_last_visit = DateTime.Now;
            entityCache.date_of_last_visit = DateTime.Now;

            _managerListOfVisitedCaches.Update(entity);
            _managerCache.Update(entityCache);

            return RedirectToAction("CachePage", new {id = model.IdCache});
        }

        [AllowAnonymous]
        public ActionResult AddCache()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult AddCache(AddCacheViewModel model, HttpPostedFileBase upload)
        {
            try
            {

                var pic = new AddPhotos();
                var patPic = pic.AddImage(upload, Server.MapPath("/Images/Cache/"), "/Images/Cache/");

                var entity = Mapper.Map<AddCacheViewModel, Cache>(model);
                entity.id_user = Convert.ToInt64(Session["UserId"]);

                entity.photo_of_caches = new List<PhotoOfCaches>()
                {
                    new PhotoOfCaches
                    {
                        photo = new Photo
                        {
                            name = patPic,
                            date = DateTime.Now
                        }
                    }
                };
                _managerCache.Add(entity);

                return RedirectToRoute("UserPage");
            }
            catch (Exception)
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult AddPhotoCache(CachePageViewModel model, HttpPostedFileBase upload)
        {
            try
            {
                var pic = new AddPhotos();
                var patPic = pic.AddImage(upload, Server.MapPath("/Images/Cache/"), "/Images/Cache/");
                var entity = new PhotoOfCaches()
                {
                    id_cache = model.IdCache,
                    photo = new Photo()
                    {
                        name = patPic,
                        date = DateTime.Now
                    }
                };
                _managerPhotoOfCaches.Add(entity);
                return RedirectToAction("CachePage", new { id = model.IdCache });
            }
            catch (Exception)
            {
                return RedirectToAction("CachePage", new { id = model.IdCache });
            }
            
        }
    }
}