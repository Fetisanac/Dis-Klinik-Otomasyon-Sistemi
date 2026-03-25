using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKlinik.Hasta.Business
{
    /// <summary>
    /// İstatistik verilerini tutmak için DTO sınıfı
    /// </summary>
    public class Bİstatistik
    {
        private string _etiket;
        private decimal _deger;

        public string Etiket
        {
            get { return _etiket; }
            set { _etiket = value; }
        }

        public decimal Deger
        {
            get { return _deger; }
            set { _deger = value; }
        }
    }
}





