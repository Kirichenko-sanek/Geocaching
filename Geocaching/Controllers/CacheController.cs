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

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AddComment(CachePageViewModel model)
        {
            if (model.NewComment == null)
            {
                return RedirectToAction("CachePage", new { id = model.IdCache });
            }
            var entity = Mapper.Map<CachePageViewModel, Comment>(model);
            _managerComments.Add(entity);
            return RedirectToAction("CachePage", new {id = model.IdCache});
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

        [HttpPost]
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

        
        [AllowAnonymous]
        public ActionResult Search(SearchViewModel model)
        {
            try
            {
                List<CacheViewModel> caches = new List<CacheViewModel>();
                List<PhotoViewModel> photos = new List<PhotoViewModel>();
                if (model.Address != null)
                {
                    var search_caches = _managerCache.Search(model.Name, model.Address.Longitude, model.Address.Latitude,
                        model.Address.Country, model.Address.Region, model.Address.City);

                    foreach (var cache in search_caches)
                    {
                        var photos_cache = _managerPhotoOfCaches.GetPhotoOfCachesByCacheId(cache.id);
                        photos.Clear();
                        foreach (var photo in photos_cache)
                        {
                            photos.Add(Mapper.Map<PhotoOfCaches, PhotoViewModel>(photo));

                        }

                        var a = Mapper.Map<Cache, CacheViewModel>(cache);
                        a.Photo = photos[0].Name;

                        caches.Add(a);
                    }

                }
                model.Cache = caches;

                return View(model);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult DeleteCache(long idCache)
        {
            List<ListOfVisitedCaches> listCaches = new List<ListOfVisitedCaches>();
            List<PhotoOfCaches> listPhoto = new List<PhotoOfCaches>();
            List<Comment> listComments = new List<Comment>();

            var visited_caches = _managerListOfVisitedCaches.GetCacheByIdCache(idCache);
            foreach (var visit_cache in visited_caches)
            {
                listCaches.Add(visit_cache);
            }
            foreach (var visit_cache in listCaches)
            {
                _managerListOfVisitedCaches.Delete(visit_cache);
            }

            var photo_cache = _managerPhotoOfCaches.GetPhotoOfCachesByCacheId(idCache);
            foreach (var photo in photo_cache)
            {
                listPhoto.Add(photo);
            }
            foreach (var photo in listPhoto)
            {
                _managerPhotoOfCaches.Delete(photo);
            }

            var comments_cache = _managerComments.GetCommentsByCacheId(idCache);
            foreach (var comment in comments_cache)
            {
                listComments.Add(comment);
            }
            foreach (var comment in listComments)
            {
                _managerComments.Delete(comment);
            }
            var cache = _managerCache.GetById(idCache);
            _managerCache.Delete(cache);
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult DeleteComment(long id)
        {
            var comment = _managerComments.GetById(id);
            _managerComments.Delete(comment);
            return RedirectToRoute("CachePage", new { id = comment.id_cache });
        }
    }
}