using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using Moto.App_Start;
using moto.Models;

namespace moto
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                CustomPrincipalSerializeModel serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);
                CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);

                ////newUser.UserGuid = serializeModel.UserGuid;
                ////newUser.FirstName = serializeModel.FirstName;
                ////newUser.LastName = serializeModel.LastName;



                //newUser.UserGuid = Guid.Parse("67C919E2-8DF4-476A-B312-C26F82A36CFB");
                //newUser.FirstName = "Can";
                //newUser.LastName = "Akcan";


                HttpContext.Current.User = newUser;
            }

        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                CustomPrincipalSerializeModel serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);

                CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);

                //newUser.UserGuid = serializeModel.UserGuid;
                //newUser.FirstName = serializeModel.FirstName;
                //newUser.LastName = serializeModel.LastName;


                using (KrankEntities ent = new KrankEntities())
                {
                    //User.Identity.Name
                    Guid userGuid = Guid.Parse(User.Identity.Name);
                  aspnet_Users user=  ent.aspnet_Users.First(i => i.UserId ==userGuid );
                  newUser.UserGuid = user.UserId;
                  newUser.FirstName = "Can";
                  newUser.LastName = "Akcan";
                }
                //newUser.UserGuid = Guid.Parse("67C919E2-8DF4-476A-B312-C26F82A36CFB");
                //newUser.FirstName = "Can";
                //newUser.LastName = "Akcan";


                HttpContext.Current.User = newUser;
            }
        }
    }
}
