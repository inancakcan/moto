using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace moto.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GoogleMap(string Lat,string Lon)
        {
            ViewBag.Lat = Lat;
            ViewBag.Lon = Lon;
            //ViewBag.Zoom = Zoom;
            return PartialView("GoogleMap");
        }


        public ActionResult Map()
        {
            //ViewBag.Lat = Lat;
            //ViewBag.Lon = Lon;
            //ViewBag.Zoom = Zoom;
            return PartialView("Map");
        }


        public ActionResult _EnlemBoylamAciklamasi()
        {
            return PartialView("_EnlemBoylamAciklamasi");
        }
    }
}