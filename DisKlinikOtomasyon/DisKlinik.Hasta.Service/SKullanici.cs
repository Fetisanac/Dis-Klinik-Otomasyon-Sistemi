using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DisKlinik.Hasta.Interface;
using DisKlinik.Hasta.Business;

namespace DisKlinik.Hasta.Service
{
    public class SKullanici : IKullanici
    {
        public string KullaniciGiris(string kullaniciAdi, string sifre)
        {
            string rol = null;

            // STANDART: using bloğu kullanımı (Otomatik kapatma sağlar)
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    // Validasyonlar
                    if (string.IsNullOrEmpty(kullaniciAdi)) return null;
                    if (string.IsNullOrEmpty(sifre)) return null;

                    conn.Open();

                    // STANDART: SP/Query çalıştırma işi Business katmanındaki metoda devredilir
                    rol = SpKullanici.KullaniciGiris(conn, kullaniciAdi, sifre);

                    // Giriş başarılı ise log kaydı ekle
                    if (rol != null)
                    {
                        BLog log = new BLog();
                        log.KullaniciAdi = kullaniciAdi;
                        log.IslemTuru = "Giriş";
                        log.Aciklama = "Sisteme giriş yapıldı.";
                        log.Tarih = DateTime.Now;

                        SpLog.LogEkle(conn, log);
                    }
                }
                catch (Exception)
                {
                    // Hata durumunda null döner
                    rol = null;
                }
            } // Connection burada otomatik kapanır

            return rol;
        }
    }
}

