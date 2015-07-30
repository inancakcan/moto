using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using moto.Models;
using moto.App_Start;

namespace moto.Controllers
{
    public class MotMarkaModelController : Controller
    {
        // GET: MotMarkaModel
        public ActionResult Index(int? ModelId)
        {

            if (ModelId != null)
            {
                Query q = new Query();
                ViewBag.MotosikletModelId = q.Mot_MotorIddenMotModelIdDon(ModelId.Value);
                ViewBag.MotosikletMarkaId = q.Mot_ModelIddenMotMarkaIdDon(ViewBag.MotosikletModelId);
            }

            MotMarkaModelViewModel model = new MotMarkaModelViewModel();
            model.AvailableMotMarkas.Add(new SelectListItem { Text = "-Motosiklet markasını seçiniz-", Value = "0" });
            MotorMarkaModel iss = new MotorMarkaModel();
            var Markas = iss.GetAllMarkas();
            foreach (var marka in Markas)
            {
                model.AvailableMotMarkas.Add(new SelectListItem() { Text = marka.Marka, Value = marka.Id.ToString() });
            }

            if (ViewBag.MotosikletMarkaId != null )
            {
                model.MotMarkaId = ViewBag.MotosikletMarkaId;
                var MotModels=iss.GetAllModelsByMarkaId(model.MotMarkaId);
                foreach (var motModel in MotModels)
                {
                    model.AvailableMotModels.Add(new SelectListItem() { Text = motModel.Model, Value = motModel.Id.ToString() });
                }
                model.MotModelId = ViewBag.MotosikletModelId;
            }
            return View(model);
        }


        public IList<mot_Model> MotMarkasininModelleriniDon(int MarkaId)
        {
            MotorMarkaModel iss = new MotorMarkaModel();
                var models = iss.GetAllModelsByMarkaId(MarkaId);
             
                return models;
            
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetMotModelsByMarkaId(string MotMarkaId)
        {
            if (String.IsNullOrEmpty(MotMarkaId))
            {
                throw new ArgumentNullException("MotMarkaId");
            }
            int id = 0;
            bool isValid = Int32.TryParse(MotMarkaId, out id);
            MotorMarkaModel iss = new MotorMarkaModel();
            using (motobulvarEntities ent = new motobulvarEntities())
            {
                var models = iss.GetAllModelsByMarkaId(id);
                var result = (from i in models
                              select new
                              {
                                  id = i.Id,
                                  name = i.Model
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


    }


    
}