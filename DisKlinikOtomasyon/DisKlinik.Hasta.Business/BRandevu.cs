using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKlinik.Hasta.Business
{
    public class BRandevu
    {
        // KURALLAR:
        // 1. Private değişkenler en başta tanımlanır [Kaynak: 321]
        // 2. Property değişkenleri '_' ile başlar [Kaynak: 322]
        // 3. Sayısal kimlik değerleri 'long' olmalı [Kaynak: 168]

        private int _id;
        private long _hastaTc;
        private long _doktorSicil;
        private DateTime _randevuTarihi;
        private string _notlar;
        private bool _durum;
        private string _hastaAdi; // INNER JOIN ile gelen
        private string _doktorAdi; // INNER JOIN ile gelen
        private int? _tedaviId; // Tedavi ID (Nullable)
        private string _tedaviAdi; // LEFT JOIN ile gelen

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

        public long DoktorSicil
        {
            get { return _doktorSicil; }
            set { _doktorSicil = value; }
        }

        public DateTime RandevuTarihi
        {
            get { return _randevuTarihi; }
            set { _randevuTarihi = value; }
        }

        public string Notlar
        {
            get { return _notlar; }
            set { _notlar = value; }
        }

        public bool Durum
        {
            get { return _durum; }
            set { _durum = value; }
        }

        public string HastaAdi
        {
            get { return _hastaAdi; }
            set { _hastaAdi = value; }
        }

        public string DoktorAdi
        {
            get { return _doktorAdi; }
            set { _doktorAdi = value; }
        }

        public int? TedaviId
        {
            get { return _tedaviId; }
            set { _tedaviId = value; }
        }

        public string TedaviAdi
        {
            get { return _tedaviAdi; }
            set { _tedaviAdi = value; }
        }

        /// <summary>
        /// ComboBox'ta gösterim için formatlanmış metin
        /// </summary>
        public string DisplayText
        {
            get { return $"{HastaAdi} - {RandevuTarihi:dd.MM.yyyy HH:mm}"; }
        }
    }
}

