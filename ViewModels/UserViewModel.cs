using MVCCRUDSHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.Entity;

namespace MVCCRUDSHOP.ViewModels
{
    public class UserViewModel
    {
       
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserEmailAddress { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }       
    }
}
