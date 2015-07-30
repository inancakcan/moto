using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace moto.Models
{
    public class MotorMarkaModel:IMotorMarkaModel
    {
        private motobulvarEntities db = new motobulvarEntities();
        public IList<mot_Marka> GetAllMarkas()
        {
            var query = from mot_Markas in db.mot_Marka
                        select mot_Markas;
            var content = query.ToList<mot_Marka>();
            return content;   
        }

        public IList<mot_Model> GetAllModelsByMarkaId(int MarkaId)
        {
            var query = from mot_models in db.mot_Model
                        where mot_models.MarkaId == MarkaId
                        select mot_models;
            var content = query.ToList<mot_Model>();
            return content;
        }
    }
}