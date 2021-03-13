using MVCCRUDSHOP.Models;
using MVCCRUDSHOP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCCRUDSHOP.Controllers
{
   
    public class AccountController : Controller
    {
        private MVCCRUDSHOPEntities db = new MVCCRUDSHOPEntities();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        //GET
        public ActionResult Register()
        {
            UserViewModel userviewmodel = new UserViewModel();

            return View();
        }

        [HttpPost]
        public ActionResult Register(UserViewModel userViewModel)
        {
            if(ModelState.IsValid)
            {
                User user = new User();
                user.UserName = userViewModel.UserName;
                user.Password = userViewModel.Password;
                user.UserEmailAddress = userViewModel.UserEmailAddress;
                db.Users.Add(user);
                db.SaveChanges();
            }
            return View(userViewModel);
        }

        //GET
        public ActionResult LogOn()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(UserViewModel user)
        {
            string Message = string.Empty;
            bool IsValidUser = db.Users.Any(u => u.UserName.ToLower() == user.UserName.ToLower() && u.Password == user.Password);

            if(IsValidUser)
            {
                Session["UserId"] = user.UserId.ToString();
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Message = "Failed to LogOn";
            }
            return View(new { Message = Message });
        }

        // GET: /Account/LogOff
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //GET
        public ActionResult changepassword()
        {
            //User user = new User();
            //var uid = user.UserId;
            return View();
        }

        [HttpPost]
        public ActionResult changepassword(UserViewModel model)
        {                     
            bool IsValidUser = db.Users.Any(u => u.Password == model.Password);

            if (IsValidUser)
            {
                User user = new User();
                //MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true);
                //changepass = currentUser.ChangePassword(model.Password, model.NewPassword);
                //FormsAuthentication.Authenticate(model.UserName, model.Password);
                //var updatepass = db.Users.Find(user.UserId);
                FormsIdentity formsIdentity = System.Web.HttpContext.Current.User.Identity  as FormsIdentity;
                FormsAuthenticationTicket ticket = formsIdentity.Ticket;
                var uname = ticket.Name;
                var updatepass = db.Users.Find(user.UserId);
                updatepass.Password = model.Password;
                user.Password = model.NewPassword;
                db.Entry(updatepass).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return View();
        }

        public User GetUser(string userName)
        {
            var user =db.Users.SingleOrDefault(u => u.UserName == userName);
            return user;
        }
        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
    }
}