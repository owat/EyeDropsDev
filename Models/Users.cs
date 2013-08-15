using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace EyeDropsDev.Models
{
 public class Role
    {
        protected Role() { }
        public Role(int roleid, string roleDescription)
        {
            RoleId = roleid;
            Description = roleDescription;
        }
        public virtual int RoleId { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<Right> Rights { get; set; }
    }
    public class Right
    {
        protected Right() { }
        public Right(int rightId, string description)
        {
            RightId = rightId;
            Description = description;
        }
        public virtual int RightId { get; set; }
        public virtual string Description { get; set; }
    }
    public class Users : IPrincipal
    {
        protected Users() { }
        public Users(int userId, string userName, string email, string password)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            Password = password;
        }
        public virtual int UserId { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual IIdentity Identity
        {
            get;
            set;
        }
        public virtual Role Role { get; set; }
        public virtual bool IsInRole(string role)
        {
            if (Role.Description.ToLower() == role.ToLower())
                return true;
            foreach (Right right in Role.Rights)
            {
                if (right.Description.ToLower() == role.ToLower())
                    return true;
            }
            return false;
        }
    }
}