using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Geocaching.App_GlobalResources;
using Geocaching.BL;
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
        private readonly IPhotoManager<Photo> _managerPhoto;

        public ProfileController(IUserManager<User> managerUser, IPhotoOfUserManager<PhotoOfUser> managerPhotoOfUser,
            IListOfVisitedCachesManager<ListOfVisitedCaches> managerListOfVisitedCaches,
            ICacheManager<Cache> managerCache, IPhotoOfCachesManager<PhotoOfCaches> managerPhotoOfCaches,
            IPhotoManager<Photo> managerPhoto)
        {
            _managerUser = managerUser;
            _managerPhotoOfUser = managerPhotoOfUser;
            _managerListOfVisitedCaches = managerListOfVisitedCaches;
            _managerCache = managerCache;
            _managerPhotoOfCaches = managerPhotoOfCaches;
            _managerPhoto = managerPhoto;
        }

        [AllowAnonymous]
        public ActionResult UserPage(long? id)
        {
            if (id != null) return UserPage(new UserPageViewModel(), id);
            var user = _managerUser.GetUserByEmail(User.Identity.Name);
            Session["UserId"] = user.id;
            return UserPage(new UserPageViewModel(), user.id);           
        }
        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult UserPage(UserPageViewModel model, long? id)
        {            
            try
            {
                if (!ModelState.IsValid) return View();
                var user = _managerUser.GetById((long)id);
                var photo_user = _managerPhotoOfUser.GetPhotoUserByUserId(user.id);
                model = Mapper.Map<User, UserPageViewModel>(user);
                model.Photo = photo_user.photo.name;
                int count = 0;

                
                List<CacheViewModel> caches = new List<CacheViewModel>();
                List<CacheViewModel> caches_my = new List<CacheViewModel>();
                List<PhotoViewModel> photos = new List<PhotoViewModel>();
                List<PhotoViewModel> photos_user = new List<PhotoViewModel>();

                var photos_added_user = _managerPhotoOfUser.GetPhotoUser(user.id).OrderByDescending(x => x.photo.date);
                foreach (var photo in photos_added_user)
                {
                    photos_user.Add(Mapper.Map<PhotoOfUser,PhotoViewModel>(photo));
                    if (count == 3) break;
                    count++;
                }
                model.LastUserPhoto = photos_user;

                var visited_caches = _managerListOfVisitedCaches.GetCacheByIdUser(user.id).OrderByDescending(x => x.date);
                count = 0;
                foreach (var cache in visited_caches)
                {
                    var photos_cache = _managerPhotoOfCaches.GetPhotoOfCachesByCacheId(cache.id_cache);
                    photos.Clear();
                    foreach (var photo in photos_cache)
                    {
                        photos.Add(Mapper.Map<PhotoOfCaches, PhotoViewModel>(photo));

                    }

                    var a = Mapper.Map<ListOfVisitedCaches, CacheViewModel>(cache);
                    a.Photo = photos[0].Name;

                    caches.Add(a);
                    

                    if (count == 2) break;
                    count++;

                }
                model.LastVisitedCache = caches;

                var my_caches = _managerCache.GetCachesByIdUser(user.id).OrderByDescending(x => x.date_of_apperance);
                count = 0;
                foreach (var cache in my_caches)
                {
                    var photos_cache = _managerPhotoOfCaches.GetPhotoOfCachesByCacheId(cache.id);
                    photos.Clear();
                    foreach (var photo in photos_cache)
                    {
                        photos.Add(Mapper.Map<PhotoOfCaches, PhotoViewModel>(photo));

                    }

                    var a = Mapper.Map<Cache, CacheViewModel>(cache);
                    a.Photo = photos[0].Name;

                    caches_my.Add(a);

                    
                    if (count == 2) break;
                    count++;
                }
                model.LastMyCache = caches_my;

                return View(model);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult EditProfile(EditProfileViewModel model, long id)
        {
            var user = _managerUser.GetById(id);
            model = Mapper.Map<User, EditProfileViewModel>(user);
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(EditProfileViewModel model, HttpPostedFileBase upload)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                var user = _managerUser.GetById(model.Id);
                var photo_user = _managerPhotoOfUser.GetPhotoUserByUserId(user.id);

                string pathPic = photo_user.photo.name;
                if (upload != null && upload.ContentLength > 0)
                {
                    var pic = new AddPhotos();
                    pathPic = pic.AddImage(upload, Server.MapPath("~/Images/Account/"), "~/Images/Account/");
                }

                
                photo_user.photo = new Photo
                {
                    name = pathPic,
                    date = DateTime.Now
                };
                _managerPhotoOfUser.Update(photo_user);
                user = Mapper.Map<EditProfileViewModel, User>(model, user);
                _managerUser.Update(user);

                return RedirectToRoute("UserPage");

            }
            catch (Exception)
            {

                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult EditPass()
        {          
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult EditPass(EditPassViewModel model, long id)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                var user = _managerUser.GetById(id);
                if (user.password != PasswordHashing.HashPassword
                    (model.Password, user.password_salt))
                    throw new Exception(Resource.WrongPassword);

                var newSalt = PasswordHashing.GenerateSaltValue();
                user.password_salt = newSalt;
                user.password = PasswordHashing.HashPassword(model.NewPassword, newSalt);
                _managerUser.Update(user);
                return RedirectToRoute("UserPage");
            }
            catch (Exception e)
            {
                model.Error = e.Message;
                return View(model);
            }
        }
   
        [AllowAnonymous]
        public ActionResult VisitedCache(ListVisitedCachesViewModel model, long id)
        {

            try
            {
                List<CacheViewModel> caches = new List<CacheViewModel>();
                List<PhotoViewModel> photos = new List<PhotoViewModel>();
                IQueryable<ListOfVisitedCaches> visited_caches;

                if (model.Address != null || model.Name != null)
                {
                    visited_caches = _managerListOfVisitedCaches.SearchCache(id, model.Name,
                        model.Address.Longitude,
                        model.Address.Latitude, model.Address.Country,
                        model.Address.Region, model.Address.City);
                }
                else
                {
                    visited_caches = _managerListOfVisitedCaches.GetCacheByIdUser(id).OrderByDescending(x => x.date);
                }

                foreach (var cache in visited_caches)
                {
                    var photos_cache = _managerPhotoOfCaches.GetPhotoOfCachesByCacheId(cache.id_cache);
                    photos.Clear();
                    foreach (var photo in photos_cache)
                    {
                        photos.Add(Mapper.Map<PhotoOfCaches, PhotoViewModel>(photo));

                    }

                    var a = Mapper.Map<ListOfVisitedCaches, CacheViewModel>(cache);
                    a.Photo = photos[0].Name;

                    caches.Add(a);
                }
                model.VisitedCache = caches;
                return View(model);
            }
            catch (Exception)
            {
                return View();
            }
        }        

        [AllowAnonymous]
        public ActionResult MyCaches(MyCachesViewModel model, long id)
        {
            
            try
            {
                List<CacheViewModel> caches = new List<CacheViewModel>();
                List<PhotoViewModel> photos = new List<PhotoViewModel>();
                IQueryable<Cache> my_caches;

                if (model.Address != null || model.Name != null)
                {
                    my_caches = _managerCache.SearchCacheUser(id, model.Name,
                        model.Address.Longitude,
                        model.Address.Latitude, model.Address.Country,
                        model.Address.Region, model.Address.City);
                }
                else
                {
                    my_caches = _managerCache.GetCachesByIdUser(id).OrderByDescending(x => x.date_of_apperance);
                }
 
                foreach (var cache in my_caches)
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
                model.MyCache = caches;
                return View(model);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult MyPhotos(MyPhotosViewModel model, long id)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                var photos_added_user = _managerPhotoOfUser.GetPhotoUser(id).OrderByDescending(x => x.photo.date);
                List<PhotoViewModel> photos = new List<PhotoViewModel>();
                
                foreach (var photo in photos_added_user)
                {
                    photos.Add(Mapper.Map<PhotoOfUser, PhotoViewModel>(photo));               
                }
                model.MyPhoto = photos;
                return View(model);
            }
            catch (Exception)
            {

                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult AddPhotoUser(UserPageViewModel model, HttpPostedFileBase upload)
        {
            try
            {
                var pic = new AddPhotos();
                var patPic = pic.AddImage(upload, Server.MapPath("/Images/Account/"), "/Images/Account/");
                var entity = new PhotoOfUser()
                {
                    id_user = model.IdUserPage,
                    photo = new Photo()
                    {
                        name = patPic,
                        date = DateTime.Now
                    }
                };
                _managerPhotoOfUser.Add(entity);
                return RedirectToAction("UserPage", new { id = model.IdUserPage });
            }
            catch (Exception)
            {
                return RedirectToAction("UserPage", new { id = model.IdUserPage });
            }           
        }

        [AllowAnonymous]
        public ActionResult DeletePhoto(long idPhoto)
        {
            try
            {
                var photoCache = _managerPhotoOfCaches.GetPhootOfCachesByPhoto(idPhoto);
                var photoUser = _managerPhotoOfUser.GetPhootOfUserByPhoto(idPhoto);
                if (photoCache != null)
                {
                    _managerPhotoOfCaches.Delete(photoCache);
                    return RedirectToRoute("CachePage", new { id = photoCache.id_cache });
                }
                else if (photoUser != null)
                {
                    _managerPhotoOfUser.Delete(photoUser);
                    return RedirectToAction("UserPage", new { id = photoUser.id_user});
                }

                return RedirectToAction("Index", "Home");

            }
            catch (Exception)
            {
                return RedirectToAction("Index","Home");
            }
        }
    }
}