using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL Bağlantısı için
using DisKlinik.Hasta.Interface;
using DisKlinik.Hasta.Business;

namespace DisKlinik.Hasta.Service
{
    public class SDoktor : IDoktor
    {
        public string DoktorEkle(BDoktor doktor)
        {
            string hata = null;

            // STANDART: using bloğu kullanımı (Otomatik kapatma sağlar)
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    // Validasyonlar
                    if (string.IsNullOrEmpty(doktor.Ad)) return "Ad boş olamaz!";
                    if (doktor.TcKimlikNo.ToString().Length != 11) return "TC 11 hane olmalı!";

                    conn.Open();

                    // STANDART: SP/Query çalıştırma işi Business katmanındaki metoda devredilir [cite: 270, 298]
                    SpDoktor.DoktorEkle(conn, doktor);

                    // Log kaydı ekle (işlem başarılı ise)
                    if (hata == null && !string.IsNullOrEmpty(Oturum.GuncelKullaniciAdi))
                    {
                        BLog log = new BLog();
                        log.KullaniciAdi = Oturum.GuncelKullaniciAdi;
                        log.IslemTuru = "Doktor Ekleme";
                        log.Aciklama = $"Yeni doktor eklendi (TC: {doktor.TcKimlikNo}, Ad: {doktor.Ad} {doktor.Soyad}). Ekleyen: {Oturum.GuncelKullaniciAdi}";
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

        public List<BDoktor> DoktorListesiGetir()
        {
            List<BDoktor> sonuc = new List<BDoktor>();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    // Business katmanından veriyi çek
                    sonuc = SpDoktor.DoktorListesiGetir(conn);
                }
                catch (Exception)
                {
                    // Hata durumunda boş liste döner
                }
            }
            return sonuc;
        }

        public string DoktorSil(long tcKimlikNo)
        {
            string hata = null;
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    SpDoktor.DoktorSil(conn, tcKimlikNo);

                    // Log kaydı ekle (işlem başarılı ise)
                    if (hata == null && !string.IsNullOrEmpty(Oturum.GuncelKullaniciAdi))
                    {
                        BLog log = new BLog();
                        log.KullaniciAdi = Oturum.GuncelKullaniciAdi;
                        log.IslemTuru = "Doktor Silme";
                        log.Aciklama = $"Doktor silindi (TC: {tcKimlikNo}). Silen: {Oturum.GuncelKullaniciAdi}";
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

        public string DoktorGuncelle(BDoktor doktor)
        {
            string hata = null;
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    SpDoktor.DoktorGuncelle(conn, doktor);

                    // Log kaydı ekle (işlem başarılı ise)
                    if (hata == null && !string.IsNullOrEmpty(Oturum.GuncelKullaniciAdi))
                    {
                        BLog log = new BLog();
                        log.KullaniciAdi = Oturum.GuncelKullaniciAdi;
                        log.IslemTuru = "Doktor Güncelleme";
                        log.Aciklama = $"Doktor güncellendi (TC: {doktor.TcKimlikNo}, Ad: {doktor.Ad} {doktor.Soyad}). Güncelleyen: {Oturum.GuncelKullaniciAdi}";
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

