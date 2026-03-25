using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Bağlantısı için
using DisKlinik.Hasta.Interface;
using DisKlinik.Hasta.Business;

namespace DisKlinik.Hasta.Service
{
    public class SHasta : IHasta
    {
        public string HastaEkle(BHasta hasta)
        {
            string hata = null;

            // STANDART: using bloğu kullanımı (Otomatik kapatma sağlar)
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    // Validasyonlar
                    if (string.IsNullOrEmpty(hasta.Ad)) return "Ad boş olamaz!";
                    if (hasta.TcKimlikNo.ToString().Length != 11) return "TC 11 hane olmalı!";

                    conn.Open();

                   // STANDART: SP/Query çalıştırma işi Business katmanındaki metoda devredilir [cite: 270, 298]
                    SpHasta.HastaEkle(conn, hasta);

                    // Log kaydı ekle (işlem başarılı ise)
                    if (hata == null && !string.IsNullOrEmpty(Oturum.GuncelKullaniciAdi))
                    {
                        BLog log = new BLog();
                        log.KullaniciAdi = Oturum.GuncelKullaniciAdi;
                        log.IslemTuru = "Hasta Ekleme";
                        log.Aciklama = $"Yeni hasta eklendi (TC: {hasta.TcKimlikNo}, Ad: {hasta.Ad} {hasta.Soyad}). Ekleyen: {Oturum.GuncelKullaniciAdi}";
                        log.Tarih = DateTime.Now;
                        SpLog.LogEkle(conn, log);
                    }
                }
                catch (Exception ex)
                {
                    hata = ex.Message; // Hata mesajını yakala [cite: 350]
                }
            } // Connection burada otomatik kapanır

            return hata;
        }

        public List<BHasta> HastaListesiGetir()
        {
            List<BHasta> sonuc = new List<BHasta>();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    // Business katmanından veriyi çek
                    sonuc = SpHasta.HastaListesiGetir(conn);
                }
                catch (Exception)
                {
                    // Hata durumunda boş liste döner
                }
            }
            return sonuc;
        }
        public string HastaSil(long tcKimlikNo)
        {
            string hata = null;
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    SpHasta.HastaSil(conn, tcKimlikNo);

                    // Log kaydı ekle (işlem başarılı ise)
                    if (hata == null && !string.IsNullOrEmpty(Oturum.GuncelKullaniciAdi))
                    {
                        BLog log = new BLog();
                        log.KullaniciAdi = Oturum.GuncelKullaniciAdi;
                        log.IslemTuru = "Hasta Silme";
                        log.Aciklama = $"Hasta silindi (TC: {tcKimlikNo}). Silen: {Oturum.GuncelKullaniciAdi}";
                        log.Tarih = DateTime.Now;
                        SpLog.LogEkle(conn, log);
                    }
                }
                catch (Exception ex)
                {
                    hata = ex.Message;
                }
            }
            return hata;
        }

        public string HastaGuncelle(BHasta hasta)
        {
            string hata = null;
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    SpHasta.HastaGuncelle(conn, hasta);

                    // Log kaydı ekle (işlem başarılı ise)
                    if (hata == null && !string.IsNullOrEmpty(Oturum.GuncelKullaniciAdi))
                    {
                        BLog log = new BLog();
                        log.KullaniciAdi = Oturum.GuncelKullaniciAdi;
                        log.IslemTuru = "Hasta Güncelleme";
                        log.Aciklama = $"Hasta güncellendi (TC: {hasta.TcKimlikNo}, Ad: {hasta.Ad} {hasta.Soyad}). Güncelleyen: {Oturum.GuncelKullaniciAdi}";
                        log.Tarih = DateTime.Now;
                        SpLog.LogEkle(conn, log);
                    }
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