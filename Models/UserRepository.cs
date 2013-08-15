using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EyeDropsDev.Models
{
    public class UserRepository : IUserRepository
    {

        private eyeDropsDbDataContext db;

        public UserRepository(eyeDropsDbDataContext context)
        {
            db = context;
        }

        public List<User> getAllUsers()
        {
            var Users = from a in db.Users
                        select
                         a;
            return Users.ToList();

        }

        public User getUser(int id)
        {
            var User = from a in db.Users
                       where a.UserId == id
                       select a;
            List<User> la = User.ToList();

            User acc = new User();
            acc.UserId = la[0].UserId;
            acc.Username = la[0].Username;
            acc.Email = la[0].Email;
            acc.Password = la[0].Password;

            return acc;
        }

        public User getUser(string uname)
        {
            var User = from a in db.Users
                       where a.Username == uname
                       select a;
            List<User> la = User.ToList();
            return la[0];
        }

        public User getUser(string uname, string pwd)
        {
            var User = from a in db.Users
                       where (a.Username == uname
                       || a.Email == uname)
                       && a.Password == pwd
                       select a;
            List<User> la = User.ToList();

            User acc = new User();
            if (la.Count > 0)
                return la[0];
            else
            {
                acc.UserId = -1;
            }
            return acc;
        }

        public int addUser(string uname, string email, string pwd)
        {
            User a = new User();
            a.Username = uname;
            a.Email = email;
            a.Password = pwd;

            db.Users.InsertOnSubmit(a);
            db.SubmitChanges();
            return a.UserId;
        }

        public bool updateUser(int id, string uname, string email, string pwd)
        {
            User a = getUser(id);
            if (a != null)
            {
                a.Username = uname;
                a.Email = email;
                a.Password = pwd;
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool updateUserRemember(int id, bool remember)
        {
            User a = getUser(id);
            if (a != null)
            {
                // a.RememberMe = remember;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
        public User userFromList(List<User> list)
        {
            User acc = new User();
            if (list.Count > 0)
            {
                acc.UserId = list[0].UserId;
                acc.Username = list[0].Username;
                acc.Email = list[0].Email;
                acc.Password = list[0].Password;
                acc.FirstName = list[0].FirstName;
                acc.LastName = list[0].LastName;
                acc.Gender = list[0].Gender;
            }
            return acc;
        }

        public UserInfoModel login(LoginModel model)
        {
            UserInfoModel info = new UserInfoModel();
            var ac = from a in db.Users
                     where ((a.Username == model.Username
                     || a.Email == model.Username) &&
                           a.Password == model.Password)
                     select a;
            info.count = 0;

            List<User> la = ac.ToList();
             if (la.Count > 0)
            {
                if (model.RememberMe == true)
                    info.Remember = "1";
                else
                    info.Remember = "0";

               /* if (int.Parse(ac.FirstOrDefault().UserId) > 0)
                {
                    info.User = ac.FirstOrDefault().UserId;
                }*/
                info.count++;
                info.userData = userFromList(la);
            }
            else
            {
                User acc = new User();
                acc.UserId = -1;
                info.userData = acc;
                /*info.User =*/ info.Administrator = info.Employee = "-1";
            }

            return info;
        }


        public bool usernameAvailable(string username)
        {
            var User = from a in db.Users
                       where a.Username == username
                       select a;

            if (User.ToList().Count > 0)
                return false;
            else
                return true;
        }

        public bool emailAvailable(string email)
        {
            var User = from a in db.Users
                       where a.Email == email
                       select a;

            if (User.ToList().Count > 0)
                return false;
            else
                return true;
        }
    }
}