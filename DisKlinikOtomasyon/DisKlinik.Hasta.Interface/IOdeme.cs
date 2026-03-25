using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Business katmanını tanıması için using ekliyoruz (Referans vermiştik)
using DisKlinik.Hasta.Business;

namespace DisKlinik.Hasta.Interface
{
    public interface IOdeme
    {
        // KURALLAR:
        // 1. Tüm metodlar geriye 'string' döndürmeli (Hata yönetimi için) 
        // 2. Parametreler camelCase (küçük harfle başlar) 
        // 3. Metod isimleri PascalCase (Büyük harfle başlar) 

        string OdemeEkle(BOdeme odeme);
        string OdemeSil(int id);
    }
}





