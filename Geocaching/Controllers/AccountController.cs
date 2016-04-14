using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
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
    public class AccountController : Controller
    {
        private readonly IUserManager<User> _manager;


        public AccountController(IUserManager<User> manager)
        {
            _manager = manager;
        }

        [AllowAnonymous]
        public ActionResult EndRegistration()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegisterViewModel model)
        {
            try
            {
                var entity = Mapper.Map<RegisterViewModel, User>(model);
                var user = _manager.GetUserByEmail(model.Email);
                if (user != null) throw new Exception(Resource.EmailExist);

                var salt = PasswordHashing.GenerateSaltValue();
                var pass = PasswordHashing.HashPassword(entity.password, salt);
                entity.password_salt = salt;
                entity.password = pass;
                _manager.Add(entity);

                entity.users = new List<UserInRoles>() {new UserInRoles() {id_roles = 2, id_user = entity.id} };
                _manager.Update(entity);

                entity.photos_of_user = new List<PhotoOfUser>()
                {
                    new PhotoOfUser()
                    {
                        id_user = entity.id,
                        id_photo = 1,
                        main_photo = true
                    } };
                _manager.Update(entity);

                var url = Url.Action("ConfirmEmail", "Account", new {token = entity.id, email = entity.email},
                    Request.Url.Scheme);
                _manager.SentConfirmMail(entity,url);


                return RedirectToRoute("AfterRegistration");

            }
            catch (Exception e)
            {
                model.Error = e.Message;
                return View(model);
            }

            

        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ConfirmEmail(long token, string email)
        {
            try
            {
                var user = _manager.GetById(token);
                _manager.ActivateUser(user);
                return View();
            }
            catch
            {
                return RedirectToRoute("Default");
            }
        }

        [AllowAnonymous]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LogInViewModel model)
        {
            try
            {
                var user = _manager.GetUserByEmail(model.EmailLogin);
                if(user == null) throw new Exception(Resource.EmailNotRegistered);
                var passLogin = PasswordHashing.HashPassword(model.PasswordLogin, user.password_salt);
                if (user.password != passLogin) throw new Exception(Resource.WrongPassword);
                if (!user.is_activated) throw new Exception(Resource.NotActivated);
                FormsAuthentication.SetAuthCookie(user.email,false);
                return RedirectToAction("UserPage", "Profile", user.id);
            }
            catch (Exception e)
            {
                model.Error = e.Message;
                return View(model);
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult PassRecovery()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult PassRecovery(PassRecoveryViewModel model)
        {
            try
            {
                var user = _manager.GetUserByEmail(model.Email);
                if (user == null) throw new Exception(Resource.EmailNotRegistered);
                var rand = new Random();
                var newPass = Convert.ToString(rand.Next(100000, 999999));
                var salt = PasswordHashing.GenerateSaltValue();
                var pass = PasswordHashing.HashPassword(newPass, salt);
                user.password_salt = salt;
                user.password = pass;
                _manager.Update(user);
                _manager.SendPassRecovery(user, newPass);
                return RedirectToRoute("EndPassRecovery");
            }
            catch (Exception e)
            {
                model.Error = e.Message;
                return View(model);
            }
        }

        [AllowAnonymous]
        public ActionResult EndPassRecovery()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult SendMessage(MessageForUserViewModel model)
        {
            if (model.Message == null)
            {
                return RedirectToAction("Index", "Home");
            }
            _manager.SendMessageForUser(model.EmailUser, model.Message);
            return RedirectToAction("Index", "Home");
        }
        

    }
}