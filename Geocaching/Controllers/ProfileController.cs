using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Geocaching.Core;
using Geocaching.Filters;
using Geocaching.Interfases.Manager;
using Geocaching.Models;

namespace Geocaching.Controllers
{
    [Culture]
    public class ProfileController : Controller
    {
        private readonly IUserManager<User> _managerUser;
        private readonly IPhotoOfUserManager<PhotoOfUser> _managerPhotoOfUser; 

        public ProfileController(IUserManager<User> managerUser, IPhotoOfUserManager<PhotoOfUser> managerPhotoOfUser )
        {
            _managerUser = managerUser;
            _managerPhotoOfUser = managerPhotoOfUser;
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
    }
}