using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EyeDropsDev.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
    public class UserInfoModel
    {
        public User userData { get; set; }
        public string Administrator { get; set; }
        public string Employee { get; set; }
        public string Remember { get; set; }
        public int count { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public interface IUserRepository
    {


        List<User> getAllUsers();
        User getUser(int id);
        User getUser(string uname);
        User getUser(string uname, string pwd);

        int addUser(string uname, string email, string pwd);
        bool updateUser(int id, string uname, string email, string pwd);
        UserInfoModel login(LoginModel model);
        bool usernameAvailable(string username);
        bool emailAvailable(string email);

        bool updateUserRemember(int id, bool remember);

    }
}