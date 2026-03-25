using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKlinik.Hasta.Business
{
    public class BTedavi
    {
        // KURALLAR:
        // 1. Private değişkenler en başta tanımlanır [Kaynak: 321]
        // 2. Property değişkenleri '_' ile başlar [Kaynak: 322]
        // 3. Sayısal kimlik değerleri 'long' olmalı [Kaynak: 168]

        private int _id;
        private string _tedaviAdi;
        private decimal _birimFiyat;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string TedaviAdi
        {
            get { return _tedaviAdi; }
            set { _tedaviAdi = value; }
        }

        public decimal BirimFiyat
        {
            get { return _birimFiyat; }
            set { _birimFiyat = value; }
        }
    }
}





