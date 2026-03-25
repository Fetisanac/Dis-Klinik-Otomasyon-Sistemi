using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisKlinik.Hasta.Business;

namespace DisKlinik.Hasta.Interface
{
    public interface IRecete
    {
        string ReceteEkle(BRecete recete);
        List<BRecete> ReceteListesiGetir();
        string ReceteSil(int id);
        List<BRandevu> RandevuListesiGetir();
    }
}





