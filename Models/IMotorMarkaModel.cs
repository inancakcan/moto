using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moto.Models
{
    interface IMotorMarkaModel
    {
        IList<mot_Marka> GetAllMarkas();
        IList<mot_Model> GetAllModelsByMarkaId(int MarkaId);
    }
}
