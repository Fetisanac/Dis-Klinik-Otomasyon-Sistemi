using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Bağlantısı için
using DisKlinik.Hasta.Interface;
using DisKlinik.Hasta.Business;

namespace DisKlinik.Hasta.Service
{
    public class SRandevu : IRandevu
    {
        public string RandevuEkle(BRandevu randevu)
        {
            string hata = null;

            // STANDART: using bloğu kullanımı (Otomatik kapatma sağlar)
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    // Validasyonlar
                    if (randevu.HastaTc <= 0) return "Hasta TC Kimlik No boş olamaz!";
                    if (randevu.RandevuTarihi == DateTime.MinValue) return "Randevu tarihi seçilmelidir!";

                    conn.Open();

                    // STANDART: SP/Query çalıştırma işi Business katmanındaki metoda devredilir [cite: 270, 298]
                    SpRandevu.RandevuEkle(conn, randevu);
                }
                catch (Exception ex)
                {
                    hata = ex.Message; // Hata mesajını yakala [cite: 350]
                }
            } // Connection burada otomatik kapanır

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
                    sonuc = SpRandevu.RandevuListesiGetir(conn);
                }
                catch (Exception)
                {
                    // Hata durumunda boş liste döner
                }
            }
            return sonuc;
        }

        public string RandevuSil(int id)
        {
            string hata = null;
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    SpRandevu.RandevuSil(conn, id);
                }
                catch (Exception ex)
                {
                    hata = ex.Message;
                }
            }
            return hata;
        }

        public string RandevuGuncelle(BRandevu randevu)
        {
            string hata = null;
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    SpRandevu.RandevuGuncelle(conn, randevu);
                }
                catch (Exception ex)
                {
                    hata = ex.Message;
                }
            }
            return hata;
        }
    }
}





