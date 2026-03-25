using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKlinik.Hasta.Business
{
    public class BKullanici
    {
        // KURALLAR:
        // 1. Private değişkenler en başta tanımlanır
        // 2. Property değişkenleri '_' ile başlar

        private int _id;
        private string _kullaniciAdi;
        private string _sifre;
        private string _rol;

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

        public string Sifre
        {
            get { return _sifre; }
            set { _sifre = value; }
        }

        public string Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }
    }
}





