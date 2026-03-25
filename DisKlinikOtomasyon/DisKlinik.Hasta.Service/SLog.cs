using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DisKlinik.Hasta.Interface;
using DisKlinik.Hasta.Business;

namespace DisKlinik.Hasta.Service
{
    public class SLog : ILog
    {
        public string LogEkle(BLog log)
        {
            string hata = null;

            // STANDART: using bloğu kullanımı (Otomatik kapatma sağlar)
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    // Validasyonlar
                    if (string.IsNullOrEmpty(log.KullaniciAdi)) return "Kullanıcı adı boş olamaz!";
                    if (string.IsNullOrEmpty(log.IslemTuru)) return "İşlem türü boş olamaz!";

                    conn.Open();

                    // STANDART: SP/Query çalıştırma işi Business katmanındaki metoda devredilir
                    SpLog.LogEkle(conn, log);
                }
                catch (Exception ex)
                {
                    hata = ex.Message;
                }
            } // Connection burada otomatik kapanır

            return hata;
        }

        public List<BLog> LogListesiGetir()
        {
            List<BLog> sonuc = new List<BLog>();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    // Business katmanından veriyi çek
                    sonuc = SpLog.LogListesiGetir(conn);
                }
                catch (Exception)
                {
                    // Hata durumunda boş liste döner
                }
            }
            return sonuc;
        }

        public string TumLoglariTemizle()
        {
            string hata = null;

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    SpLog.TumLoglariTemizle(conn);
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





