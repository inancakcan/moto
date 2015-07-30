using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace moto
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute("GetAllIlcesByIlId",
                            "IlIlce/GetIlcesByIlId/",
                            new { controller = "IlIlce", action = "GetIlcesByIlId" },
                            new[] { "moto.Controllers" });

            routes.MapRoute("GetSemtsByIlceId",
                           "IlIlce/GetSemtsByIlceId/",
                           new { controller = "IlIlce", action = "GetSemtsByIlceId" },
                           new[] { "moto.Controllers" });

            routes.MapRoute("GetMahallesBySemtId",
                          "IlIlce/GetMahallesBySemtId/",
                          new { controller = "IlIlce", action = "GetMahallesBySemtId" },
                          new[] { "moto.Controllers" });


            routes.MapRoute("GetPostaKodsByMahalleId",
                        "IlIlce/GetPostaKodsByMahalleId/",
                        new { controller = "IlIlce", action = "GetPostaKodsByMahalleId" },
                        new[] { "moto.Controllers" });



            routes.MapRoute("GetMotModelsByMarkaId",
                          "MotMarkaModel/GetMotModelsByMarkaId/",
                          new { controller = "MotMarkaModel", action = "GetMotModelsByMarkaId" },
                          new[] { "moto.Controllers" });


            routes.MapRoute("GetAltKategorisByKategoriId",
                         "KategoriAltKategori/GetAltKategorisByKategoriId/",
                         new { controller = "KategoriAltKategori", action = "GetAltKategorisByKategoriId" },
                         new[] { "moto.Controllers" });

           
        }
    }
}
