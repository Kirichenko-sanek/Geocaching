using System;
using System.Collections.Generic;
using System.Linq;
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
                model.MainPhoto =  photos[1].Name;

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
            var entity = Mapper.Map<CachePageViewModel, Comment>(model);
            _managerComments.Add(entity);
            return RedirectToAction("CachePage", new { id = model.IdCache });
        }

        [AllowAnonymous]
        public ActionResult Visit(CachePageViewModel model)
        {
            var entity = Mapper.Map<CachePageViewModel, ListOfVisitedCaches>(model);
            _managerListOfVisitedCaches.Add(entity);

            entity.cache.date_of_last_visit = DateTime.Now;
            _managerListOfVisitedCaches.Update(entity);

            return RedirectToAction("CachePage", new {id = model.IdCache});
        }

    }
}