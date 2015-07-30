using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moto.Models
{
    interface IKategoriAltKategori
    {
        IList<Kategori> GetAllKategoris();
        IList<AltKategori> GetAllAltKategorisByKategoriId(int KategoriId);
        
    }
}
