using System;
using System.Linq;
using System.Web.Security;
using MVCCRUDSHOP.Models;

namespace MVCCRUDSHOP.Infrastructure
{
    public class CustomRoleProvider : RoleProvider
    {
        private MVCCRUDSHOPEntities db = new MVCCRUDSHOPEntities();

        public override bool IsUserInRole(string username, string roleName)
        {
           
                var user = db.Users.SingleOrDefault(u => u.UserName == username);
                if (user == null)
                    return false;

                return user.UserRoles != null && user.UserRoles.Select(u => u.Role).Any(r => r.RoleName == roleName);            
        }

        public override string[] GetRolesForUser(string username)
        {  
                var user = db.Users.SingleOrDefault(u => u.UserName == username);
                if (user == null)
                    return new string[]{};

                return user.UserRoles == null ? new string[] { } : user.UserRoles.Select(u => u.Role).Select(u => u.RoleName).ToArray();            
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {           
                return db.Roles.Select(r => r.RoleName).ToArray();           
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}