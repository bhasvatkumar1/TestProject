using MVCCRUDSHOP.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUDSHOP.Controllers
{
    public class ManageController : Controller
    {
        //private readonly MVCCRUDSHOPEntities _usersContext;

        //public ManageController()
        //{
        //    _usersContext = new MVCCRUDSHOPEntities();
        //}

        MVCCRUDSHOPEntities CrudShop = new MVCCRUDSHOPEntities();

        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Index()
        {
            return View(CrudShop.Users.Where(u => u.UserId > 1).ToList());
        }

        [Authorize(Roles = "SuperAdmin")]
        public JsonResult UpdateRole(UserRole userRole)
        {            
            var roleEntry = CrudShop.UserRoles.FirstOrDefault(r => r.UserId == userRole.UserId);
            if (roleEntry != null)
            {
                CrudShop.UserRoles.Remove(roleEntry);
                CrudShop.SaveChanges();
            }
            CrudShop.UserRoles.Add(userRole);
            CrudShop.SaveChanges();
            
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }

    public static class ListProvider
    {
        public static List<SelectListItem> Roles = new List<SelectListItem>
                                                   {
                                                       new SelectListItem { Text = "Super Admin", Value = "0" },
                                                       new SelectListItem { Text = "Admin", Value = "1" },
                                                       new SelectListItem { Text = "Author", Value = "2" }
                                                   };

        public static List<SelectListItem> GetRoles(short roleId)
        {
            Roles.ForEach(r => r.Selected = false);
            var role = Roles.Single(r => r.Value == roleId.ToString(CultureInfo.InvariantCulture));
            role.Selected = true;
            return Roles;
        }
    }
}
