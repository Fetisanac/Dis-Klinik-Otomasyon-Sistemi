using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKlinik.Hasta.Business
{
    public class BRecete
    {
        // KURALLAR:
        // 1. Private değişkenler en başta tanımlanır
        // 2. Property değişkenleri '_' ile başlar

        private int _id;
        private int _randevuId;
        private string _tani;
        private string _ilaclar;
        private DateTime _tarih;
        private string _hastaAdi; // JOIN ile gelen

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int RandevuId
        {
            get { return _randevuId; }
            set { _randevuId = value; }
        }

        public string Tani
        {
            get { return _tani; }
            set { _tani = value; }
        }

        public string Ilaclar
        {
            get { return _ilaclar; }
            set { _ilaclar = value; }
        }

        public DateTime Tarih
        {
            get { return _tarih; }
            set { _tarih = value; }
        }

        public string HastaAdi
        {
            get { return _hastaAdi; }
            set { _hastaAdi = value; }
        }
    }
}





