using EyeDropsDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace EyeDropsDev.Controllers
{
    public class MAccountController : ApiController
    {

        // GET api/maccount
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/maccount/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/maccount
        public void Post([FromBody]string value)
        {

        }

        // PUT api/maccount/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/maccount/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        public HttpResponseMessage Ison(string ion)
        {
            if (User.Identity.IsAuthenticated)
                return Request.CreateResponse(HttpStatusCode.OK, "on");
            else
                return Request.CreateResponse(HttpStatusCode.OK, "off");

        }


        [HttpGet]
        public HttpResponseMessage Logout(string lout)
        {
            FormsAuthentication.SignOut();
            return Request.CreateResponse(HttpStatusCode.OK, "loggedout");

        }
        [HttpGet]
        public HttpResponseMessage Login(string username, string password)
        {
 
            if (User.Identity.IsAuthenticated)
            {

                return new HttpResponseMessage() { Content = new StringContent("authenticated") };

            }
            else
            {
                IUserRepository repository = new UserRepository(new eyeDropsDbDataContext());
                LoginModel model = new LoginModel();
                model.Username = username;
                model.Password = password;
                HttpResponseMessage res = new HttpResponseMessage();
                UserInfoModel lin = repository.login(model);
                if (lin.userData.UserId > 0)
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
        model.Username,
        DateTime.Now,
        DateTime.Now.AddDays(30),
        true,
        null,
        FormsAuthentication.FormsCookiePath);

                    // Encrypt the ticket.
                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);

                    return Request.CreateResponse(HttpStatusCode.OK, "loggedin");
                }
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "failedlogin");
            }

        }
    }
}
