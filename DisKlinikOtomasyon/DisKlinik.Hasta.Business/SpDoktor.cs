using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; // SQL Server için gerekli
using System.Text; // StringBuilder için gerekli

namespace DisKlinik.Hasta.Business
{
    public class SpDoktor
    {
        // STANDART: Connection burada create edilmez, parametre olarak gelir [cite: 299, 300]

        /// <summary>
        /// T_DOKTOR tablosuna kayıt ekler
        /// </summary>
        public static void DoktorEkle(SqlConnection conn, BDoktor doktor)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO T_DOKTOR (Ad, Soyad, TcKimlikNo, Telefon, Adres, DogumTarihi, Brans, SicilNo) ");
            sql.Append("VALUES (@Ad, @Soyad, @TcKimlikNo, @Telefon, @Adres, @DogumTarihi, @Brans, @SicilNo)");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                // Standart Parametreler
                cmd.Parameters.AddWithValue("@Ad", doktor.Ad);
                cmd.Parameters.AddWithValue("@Soyad", doktor.Soyad);
                cmd.Parameters.AddWithValue("@TcKimlikNo", doktor.TcKimlikNo);

                // (Null kontrolü yaparak ekliyoruz ki boş bırakılırsa hata vermesin)
                cmd.Parameters.AddWithValue("@Telefon", doktor.Telefon ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Adres", doktor.Adres ?? (object)DBNull.Value);

                // Tarih seçilmediyse veritabanına null gitsin
                cmd.Parameters.AddWithValue("@DogumTarihi", doktor.DogumTarihi == DateTime.MinValue ? DBNull.Value : (object)doktor.DogumTarihi);

                // Doktor özel alanları
                cmd.Parameters.AddWithValue("@Brans", doktor.Brans ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SicilNo", doktor.SicilNo ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tüm doktor listesini çeker
        /// </summary>
        public static List<BDoktor> DoktorListesiGetir(SqlConnection conn)
        {
            List<BDoktor> liste = new List<BDoktor>();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT TcKimlikNo, Ad, Soyad, Telefon, Adres, DogumTarihi, Brans, SicilNo FROM T_DOKTOR");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BDoktor doktor = new BDoktor();
                        // Temel alanlar
                        doktor.TcKimlikNo = Convert.ToInt64(dr["TcKimlikNo"]);
                        doktor.Ad = dr["Ad"].ToString();
                        doktor.Soyad = dr["Soyad"].ToString();

                        // Veritabanında boş (NULL) olabilir diye kontrol ederek alıyoruz
                        doktor.Telefon = dr["Telefon"] != DBNull.Value ? dr["Telefon"].ToString() : "";
                        doktor.Adres = dr["Adres"] != DBNull.Value ? dr["Adres"].ToString() : "";

                        if (dr["DogumTarihi"] != DBNull.Value)
                        {
                            doktor.DogumTarihi = Convert.ToDateTime(dr["DogumTarihi"]);
                        }

                        // Doktor özel alanları
                        doktor.Brans = dr["Brans"] != DBNull.Value ? dr["Brans"].ToString() : "";
                        doktor.SicilNo = dr["SicilNo"] != DBNull.Value ? dr["SicilNo"].ToString() : "";

                        liste.Add(doktor);
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// TC Kimlik Numarasına göre kaydı siler
        /// </summary>
        public static void DoktorSil(SqlConnection conn, long tcNo)
        {
            // Kaydı TC'sine göre bulup siliyoruz
            string sql = "DELETE FROM T_DOKTOR WHERE TcKimlikNo = @TcKimlikNo";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TcKimlikNo", tcNo);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// TC Kimlik Numarasına göre bilgileri günceller
        /// </summary>
        public static void DoktorGuncelle(SqlConnection conn, BDoktor doktor)
        {
            StringBuilder sql = new StringBuilder();

            // GÜNCELLEME SORGUSU
            // Hangi alanların değişeceğini burada belirtiyoruz.
            sql.Append("UPDATE T_DOKTOR SET ");
            sql.Append("Ad = @Ad, ");
            sql.Append("Soyad = @Soyad, ");
            sql.Append("Telefon = @Telefon, ");
            sql.Append("Adres = @Adres, ");
            sql.Append("DogumTarihi = @DogumTarihi, ");
            sql.Append("Brans = @Brans, ");
            sql.Append("SicilNo = @SicilNo ");

            sql.Append("WHERE TcKimlikNo = @TcKimlikNo");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                // Kimlik (Değişmeyen Anahtar)
                cmd.Parameters.AddWithValue("@TcKimlikNo", doktor.TcKimlikNo);

                // Değişecek Bilgiler
                cmd.Parameters.AddWithValue("@Ad", doktor.Ad);
                cmd.Parameters.AddWithValue("@Soyad", doktor.Soyad);
                cmd.Parameters.AddWithValue("@Telefon", doktor.Telefon ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Adres", doktor.Adres ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DogumTarihi", doktor.DogumTarihi == DateTime.MinValue ? DBNull.Value : (object)doktor.DogumTarihi);
                cmd.Parameters.AddWithValue("@Brans", doktor.Brans ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SicilNo", doktor.SicilNo ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }
    }
}





