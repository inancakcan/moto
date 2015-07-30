using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace moto.Models
{
    
    public class IlceSemt:IIlceSemt
    {
        private motobulvarEntities db = new motobulvarEntities();
        public IList<il> GetAllIls()
        {
            var query = from ils in db.il
                        select ils;
            var content = query.ToList<il>();
            return content;    
        }

        public IList<ilce> GetAllIlcesByIlId(int IlId)
        {
            var query = from ilces in db.ilce where ilces.ilID==IlId
                        select ilces;
            var content = query.ToList<ilce>();
            return content;
        }

        public IList<semt> GetAllSemtsByIlceId(int IlceId)
        {
            var query = from semts in db.semt
                        where semts.ilceID == IlceId
                        select semts;
            var content = query.ToList<semt>();
            return content;
        }

        public IList<mahalle> GetAllMahallesByBySemtId(int SemtId)
        {
            var query = from mahalles in db.mahalle
                        where mahalles.semtID == SemtId
                        select mahalles;
            var content = query.ToList<mahalle>();
            return content;
        }

        public IList<postakodu> GetAllPostaKodsByByMahalleId(int MahalleId)
        {
            var query = from postaKods in db.postakodu
                        where postaKods.mahalleID== MahalleId
                        select postaKods;
            var content = query.ToList<postakodu>();
            return content;
        }
    }
}