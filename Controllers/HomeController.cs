using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Moto.App_Start;

namespace moto.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                string bak = User.Identity.Name;
                bool bBak = User.Identity.IsAuthenticated;


                //MembershipUser user = Membership.GetUser(User.Identity.Name);
                //Guid guid = (Guid) user.ProviderUserKey;


                // Guid userGuid=  (User as CustomPrincipal).UserGuid;
                //string Ad=(User as CustomPrincipal).FirstName;
                //string SoyAd = (User as CustomPrincipal).LastName;

                var Userr = HttpContext.User as CustomPrincipal;
            }

            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                string cookiePath = ticket.CookiePath;
                DateTime expiration = ticket.Expiration;
                bool expired = ticket.Expired;
                bool isPersistent = ticket.IsPersistent;
                DateTime issueDate = ticket.IssueDate;
                string name = ticket.Name;
                string userData = ticket.UserData;
                int version = ticket.Version;
            }

            //EGER url DEN BİLGİ GELECEKSE
            //if (Request[".MonoX2"] != null)
            //{
            //    string EncryptedTicket = Request[".MonoX2"].ToString();
            //    var authenticationTicket = FormsAuthentication.Decrypt(EncryptedTicket);
            //}








            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}