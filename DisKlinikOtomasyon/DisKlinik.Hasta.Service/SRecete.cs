using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DisKlinik.Hasta.Interface;
using DisKlinik.Hasta.Business;

namespace DisKlinik.Hasta.Service
{
    public class SRecete : IRecete
    {
        public string ReceteEkle(BRecete recete)
        {
            string hata = null;

            // STANDART: using bloğu kullanımı (Otomatik kapatma sağlar)
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    // Validasyonlar
                    if (recete.RandevuId <= 0) return "Randevu seçilmelidir!";
                    if (string.IsNullOrEmpty(recete.Tani)) return "Tanı boş olamaz!";

                    conn.Open();

                    // STANDART: SP/Query çalıştırma işi Business katmanındaki metoda devredilir
                    SpRecete.ReceteEkle(conn, recete);
                }
                catch (Exception ex)
                {
                    hata = ex.Message;
                }
            } // Connection burada otomatik kapanır

            return hata;
        }

        public List<BRecete> ReceteListesiGetir()
        {
            List<BRecete> sonuc = new List<BRecete>();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    // Business katmanından veriyi çek
                    sonuc = SpRecete.ReceteListesiGetir(conn);
                }
                catch (Exception)
                {
                    // Hata durumunda boş liste döner
                }
            }
            return sonuc;
        }

        public string ReceteSil(int id)
        {
            string hata = null;

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    SpRecete.ReceteSil(conn, id);
                }
                catch (Exception ex)
                {
                    hata = ex.Message;
                }
            }
            return hata;
        }

        public List<BRandevu> RandevuListesiGetir()
        {
            List<BRandevu> sonuc = new List<BRandevu>();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    // Business katmanından veriyi çek
                    sonuc = SpRecete.RandevuListesiGetir(conn);
                }
                catch (Exception)
                {
                    // Hata durumunda boş liste döner
                }
            }
            return sonuc;
        }
    }
}





