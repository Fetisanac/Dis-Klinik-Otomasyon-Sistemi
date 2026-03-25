using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKlinik.Hasta.Business
{
    public class BLog
    {
        // KURALLAR:
        // 1. Private değişkenler en başta tanımlanır
        // 2. Property değişkenleri '_' ile başlar

        private int _id;
        private string _kullaniciAdi;
        private string _islemTuru;
        private string _aciklama;
        private DateTime _tarih;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string KullaniciAdi
        {
            get { return _kullaniciAdi; }
            set { _kullaniciAdi = value; }
        }

        public string IslemTuru
        {
            get { return _islemTuru; }
            set { _islemTuru = value; }
        }

        public string Aciklama
        {
            get { return _aciklama; }
            set { _aciklama = value; }
        }

        public DateTime Tarih
        {
            get { return _tarih; }
            set { _tarih = value; }
        }
    }
}





