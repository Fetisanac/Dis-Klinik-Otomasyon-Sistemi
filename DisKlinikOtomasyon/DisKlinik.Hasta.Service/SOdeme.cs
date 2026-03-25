using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Bağlantısı için
using DisKlinik.Hasta.Interface;
using DisKlinik.Hasta.Business;

namespace DisKlinik.Hasta.Service
{
    public class SOdeme : IOdeme
    {
        public string OdemeEkle(BOdeme odeme)
        {
            string hata = null;

            // STANDART: using bloğu kullanımı (Otomatik kapatma sağlar)
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    // Validasyonlar
                    if (odeme.HastaTc <= 0) return "Hasta seçilmelidir!";
                    if (odeme.Tutar <= 0) return "Tutar sıfırdan büyük olmalıdır!";
                    if (odeme.Tarih == DateTime.MinValue) return "Tarih seçilmelidir!";

                    conn.Open();

                    // STANDART: SP/Query çalıştırma işi Business katmanındaki metoda devredilir [cite: 270, 298]
                    SpOdeme.OdemeEkle(conn, odeme);
                }
                catch (Exception ex)
                {
                    hata = ex.Message; // Hata mesajını yakala [cite: 350]
                }
            } // Connection burada otomatik kapanır

            return hata;
        }

        public List<BOdeme> OdemeListesiGetir(long hastaTc)
        {
            List<BOdeme> sonuc = new List<BOdeme>();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    // Business katmanından veriyi çek
                    sonuc = SpOdeme.OdemeListesiGetir(conn, hastaTc);
                }
                catch (Exception)
                {
                    // Hata durumunda boş liste döner
                }
            }
            return sonuc;
        }

        public List<BOdeme> OdemeListesiGetir()
        {
            List<BOdeme> sonuc = new List<BOdeme>();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    // Business katmanından tüm veriyi çek
                    sonuc = SpOdeme.OdemeListesiGetir(conn);
                }
                catch (Exception)
                {
                    // Hata durumunda boş liste döner
                }
            }
            return sonuc;
        }

        public BKasaOzet KasaOzetGetir()
        {
            BKasaOzet ozet = new BKasaOzet();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    // Business katmanından özeti çek
                    ozet = SpOdeme.KasaOzetGetir(conn);
                }
                catch (Exception)
                {
                    // Hata durumunda sıfır değerler döner
                }
            }
            return ozet;
        }

        public string OdemeSil(int id)
        {
            string hata = null;
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    SpOdeme.OdemeSil(conn, id);
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

