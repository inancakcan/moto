using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace moto.Models
{
    public class KategoriAltKategori:IKategoriAltKategori
    {
        private motobulvarEntities db = new motobulvarEntities();
        public IList<Kategori> GetAllKategoris()
        {
            var query = from kategoris in db.Kategori
                        select kategoris;
            var content = query.ToList<Kategori>();
            return content;
        }

        public IList<AltKategori> GetAllAltKategorisByKategoriId(int KategoriId)
        {
            var query = from altKategoris in db.AltKategori
                        where altKategoris.KategoriId== KategoriId
                        select altKategoris;
            var content = query.ToList<AltKategori>();
            return content;
        }
    }
}