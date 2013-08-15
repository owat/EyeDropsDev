using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace EyeDropsDev.Models
{
    public class EyeDropsRoleProvider : RoleProvider
    {
        IUserRepository _repository;
        public EyeDropsRoleProvider()
            : this(new UserRepository(new eyeDropsDbDataContext()))
        {

        }

        public EyeDropsRoleProvider(IUserRepository repository)
            : base()
        {
            _repository = repository;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["edrpa"];
            if (roleName == "employee")
            {
                //replace
                if (int.Parse(cookie["employee"]) > 0)
                    return true;
                else
                    return false;

            }
            if (roleName == "administrator")
            {
                //replace
                if (int.Parse(cookie["administrator"]) > 0)
                    return true;
                else
                    return false;

            }
            return false;
        }
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
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
        public override string[] GetRolesForUser(string username)
        {
            UserInfoModel model = new UserInfoModel();
            LoginModel li = new LoginModel();
            User acc = _repository.getUser(username);
            li.Password = acc.Password;
            li.Username = acc.Username;
            //  li.RememberMe = acc.RememberMe;
            model = _repository.login(li);
            string[] roles = new string[model.count];
            roles[0] = "user";
            int idx = 0;
            if (int.Parse(model.Administrator) > 0)
                roles[++idx] = "administrator";
            if (int.Parse(model.Employee) > 0)
                roles[++idx] = "employee";


            return roles;
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
    }
}