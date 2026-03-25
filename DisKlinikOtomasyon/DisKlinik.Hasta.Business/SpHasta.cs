using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; // SQL Server için gerekli
using System.Text; // StringBuilder için gerekli

namespace DisKlinik.Hasta.Business
{
    public class SpHasta
    {
        // STANDART: Connection burada create edilmez, parametre olarak gelir [cite: 299, 300]

        /// <summary>
        /// T_HASTA tablosuna kayıt ekler
        /// </summary>
       
           public static void HastaEkle(SqlConnection conn, BHasta hasta)
        {
            StringBuilder sql = new StringBuilder();

       
            sql.Append("INSERT INTO T_HASTA (Ad, Soyad, TcKimlikNo, Telefon, Adres, DogumTarihi) ");
            sql.Append("VALUES (@Ad, @Soyad, @TcKimlikNo, @Telefon, @Adres, @DogumTarihi)");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                // Standart Parametreler
                cmd.Parameters.AddWithValue("@Ad", hasta.Ad);
                cmd.Parameters.AddWithValue("@Soyad", hasta.Soyad);
                cmd.Parameters.AddWithValue("@TcKimlikNo", hasta.TcKimlikNo);

                
                // (Null kontrolü yaparak ekliyoruz ki boş bırakılırsa hata vermesin)
                cmd.Parameters.AddWithValue("@Telefon", hasta.Telefon ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Adres", hasta.Adres ?? (object)DBNull.Value);

                // Tarih seçilmediyse veritabanına null gitsin
                cmd.Parameters.AddWithValue("@DogumTarihi", hasta.DogumTarihi == DateTime.MinValue ? DBNull.Value : (object)hasta.DogumTarihi);

                cmd.ExecuteNonQuery();
            }
        }
        

        /// <summary>
        /// Tüm hasta listesini çeker
        /// </summary>
        public static List<BHasta> HastaListesiGetir(SqlConnection conn)
        {
            List<BHasta> liste = new List<BHasta>();

            StringBuilder sql = new StringBuilder();

          
            sql.Append("SELECT TcKimlikNo, Ad, Soyad, Telefon, Adres, DogumTarihi FROM T_HASTA");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BHasta hasta = new BHasta();
                        // Eski alanlar
                        hasta.TcKimlikNo = Convert.ToInt64(dr["TcKimlikNo"]);
                        hasta.Ad = dr["Ad"].ToString();
                        hasta.Soyad = dr["Soyad"].ToString();

                        // --- YENİ ALANLARI OKUMA KISMI ---
                        // Veritabanında boş (NULL) olabilir diye kontrol ederek alıyoruz
                        hasta.Telefon = dr["Telefon"] != DBNull.Value ? dr["Telefon"].ToString() : "";
                        hasta.Adres = dr["Adres"] != DBNull.Value ? dr["Adres"].ToString() : "";

                        if (dr["DogumTarihi"] != DBNull.Value)
                        {
                            hasta.DogumTarihi = Convert.ToDateTime(dr["DogumTarihi"]);
                        }
                        // ---------------------------------

                        liste.Add(hasta);
                    }
                }
            }
            return liste;
        }
        /// <summary>
        /// TC Kimlik Numarasına göre kaydı siler
        /// </summary>
        public static void HastaSil(SqlConnection conn, long tcNo)
        {
            // Kaydı TC'sine göre bulup siliyoruz
            string sql = "DELETE FROM T_HASTA WHERE TcKimlikNo = @TcKimlikNo";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TcKimlikNo", tcNo);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// TC Kimlik Numarasına göre bilgileri günceller
        /// </summary>
        public static void HastaGuncelle(SqlConnection conn, BHasta hasta)
        {
            StringBuilder sql = new StringBuilder();

            // GÜNCELLEME SORGUSU
            // Hangi alanların değişeceğini burada belirtiyoruz.
            sql.Append("UPDATE T_HASTA SET ");
            sql.Append("Ad = @Ad, ");
            sql.Append("Soyad = @Soyad, ");
            sql.Append("Telefon = @Telefon, ");
            sql.Append("Adres = @Adres, ");
            sql.Append("DogumTarihi = @DogumTarihi ");

          
            sql.Append("WHERE TcKimlikNo = @TcKimlikNo");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                // Kimlik (Değişmeyen Anahtar)
                cmd.Parameters.AddWithValue("@TcKimlikNo", hasta.TcKimlikNo);

                // Değişecek Bilgiler
                cmd.Parameters.AddWithValue("@Ad", hasta.Ad);
                cmd.Parameters.AddWithValue("@Soyad", hasta.Soyad);
                cmd.Parameters.AddWithValue("@Telefon", hasta.Telefon ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Adres", hasta.Adres ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DogumTarihi", hasta.DogumTarihi == DateTime.MinValue ? DBNull.Value : (object)hasta.DogumTarihi);

                cmd.ExecuteNonQuery();
            }
        }
    }
}