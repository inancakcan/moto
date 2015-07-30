using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moto.Models
{
    interface IIlceSemt
    {
        IList<il> GetAllIls();
        IList<ilce> GetAllIlcesByIlId(int IlId);
        IList<semt>GetAllSemtsByIlceId(int IlceId);
        IList<mahalle> GetAllMahallesByBySemtId(int SemtId);
        IList<postakodu> GetAllPostaKodsByByMahalleId(int MahalleId);
    }
}
