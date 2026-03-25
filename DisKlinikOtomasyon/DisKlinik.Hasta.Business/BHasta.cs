using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKlinik.Hasta.Business
{
    public class BHasta
    {
        // KURALLAR:
        // 1. Private değişkenler en başta tanımlanır [Kaynak: 321]
        // 2. Property değişkenleri '_' ile başlar [Kaynak: 322]
        // 3. Sayısal kimlik değerleri 'long' olmalı [Kaynak: 168]

        private long _tcKimlikNo;
        private string _ad;
        private string _soyad;
        private string _telefon;
        private string _adres;
        private DateTime _dogumTarihi;

        public long TcKimlikNo
        {
            get { return _tcKimlikNo; }
            set { _tcKimlikNo = value; }
        }

        public string Ad
        {
            get { return _ad; }
            set { _ad = value; }
        }

        public string Soyad
        {
            get { return _soyad; }
            set { _soyad = value; }
        }

        public string Telefon
        {
            get { return _telefon; }
            set { _telefon = value; }
        }

        public string Adres
        {
            get { return _adres; }
            set { _adres = value; }
        }

        public DateTime DogumTarihi
        {
            get { return _dogumTarihi; }
            set { _dogumTarihi = value; }
        }

        // Read-only property for ComboBox display
        public string AdSoyad
        {
            get { return $"{_ad} {_soyad}"; }
        }
    }
}