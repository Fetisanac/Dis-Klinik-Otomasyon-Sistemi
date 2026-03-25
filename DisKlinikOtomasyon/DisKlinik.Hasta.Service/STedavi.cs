using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Bağlantısı için
using DisKlinik.Hasta.Interface;
using DisKlinik.Hasta.Business;

namespace DisKlinik.Hasta.Service
{
    public class STedavi : ITedavi
    {
        public string TedaviEkle(BTedavi tedavi)
        {
            string hata = null;

            // STANDART: using bloğu kullanımı (Otomatik kapatma sağlar)
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    // Validasyonlar
                    if (string.IsNullOrEmpty(tedavi.TedaviAdi)) return "Tedavi adı boş olamaz!";
                    if (tedavi.BirimFiyat < 0) return "Fiyat negatif olamaz!";

                    conn.Open();

                    // STANDART: SP/Query çalıştırma işi Business katmanındaki metoda devredilir [cite: 270, 298]
                    SpTedavi.TedaviEkle(conn, tedavi);
                }
                catch (Exception ex)
                {
                    hata = ex.Message; // Hata mesajını yakala [cite: 350]
                }
            } // Connection burada otomatik kapanır

            return hata;
        }

        public List<BTedavi> TedaviListesiGetir()
        {
            List<BTedavi> sonuc = new List<BTedavi>();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    // Business katmanından veriyi çek
                    sonuc = SpTedavi.TedaviListesiGetir(conn);
                }
                catch (Exception)
                {
                    // Hata durumunda boş liste döner
                }
            }
            return sonuc;
        }

        public string TedaviSil(int id)
        {
            string hata = null;
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    SpTedavi.TedaviSil(conn, id);
                }
                catch (Exception ex)
                {
                    hata = ex.Message;
                }
            }
            return hata;
        }

        public string TedaviGuncelle(BTedavi tedavi)
        {
            string hata = null;
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    SpTedavi.TedaviGuncelle(conn, tedavi);
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





