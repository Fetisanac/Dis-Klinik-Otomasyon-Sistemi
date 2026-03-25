using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisKlinik.Hasta.Business;

namespace DisKlinik.Hasta.Interface
{
    public interface ILog
    {
        string LogEkle(BLog log);
        List<BLog> LogListesiGetir();
        string TumLoglariTemizle();
    }
}





