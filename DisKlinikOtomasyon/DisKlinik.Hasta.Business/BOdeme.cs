using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKlinik.Hasta.Business
{
    public class BOdeme
    {
        // KURALLAR:
        // 1. Private değişkenler en başta tanımlanır [Kaynak: 321]
        // 2. Property değişkenleri '_' ile başlar [Kaynak: 322]
        // 3. Sayısal kimlik değerleri 'long' olmalı [Kaynak: 168]

        private int _id;
        private long _hastaTc;
        private DateTime _tarih;
        private decimal _tutar;
        private int _islemTuru; // 0: Borç, 1: Tahsilat
        private string _aciklama;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public long HastaTc
        {
            get { return _hastaTc; }
            set { _hastaTc = value; }
        }

        public DateTime Tarih
        {
            get { return _tarih; }
            set { _tarih = value; }
        }

        public decimal Tutar
        {
            get { return _tutar; }
            set { _tutar = value; }
        }

        public int IslemTuru
        {
            get { return _islemTuru; }
            set { _islemTuru = value; }
        }

        public string Aciklama
        {
            get { return _aciklama; }
            set { _aciklama = value; }
        }
    }
}





