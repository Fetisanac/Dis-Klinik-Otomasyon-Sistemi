using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; // SQL Server için gerekli
using System.Text; // StringBuilder için gerekli

namespace DisKlinik.Hasta.Business
{
    public class SpRandevu
    {
        // STANDART: Connection burada create edilmez, parametre olarak gelir [cite: 299, 300]

        /// <summary>
        /// T_RANDEVU tablosuna kayıt ekler
        /// </summary>
        public static void RandevuEkle(SqlConnection conn, BRandevu randevu)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO T_RANDEVU (HastaTc, DoktorSicil, RandevuTarihi, Notlar, Durum, TedaviId) ");
            sql.Append("VALUES (@HastaTc, @DoktorSicil, @RandevuTarihi, @Notlar, @Durum, @TedaviId)");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                // Standart Parametreler
                cmd.Parameters.AddWithValue("@HastaTc", randevu.HastaTc);
                cmd.Parameters.AddWithValue("@DoktorSicil", randevu.DoktorSicil);
                cmd.Parameters.AddWithValue("@RandevuTarihi", randevu.RandevuTarihi);

                // (Null kontrolü yaparak ekliyoruz ki boş bırakılırsa hata vermesin)
                cmd.Parameters.AddWithValue("@Notlar", randevu.Notlar ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Durum", randevu.Durum);
                cmd.Parameters.AddWithValue("@TedaviId", randevu.TedaviId.HasValue ? (object)randevu.TedaviId.Value : DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tüm randevu listesini çeker (INNER JOIN ile Hasta ve Doktor isimleri dahil)
        /// </summary>
        public static List<BRandevu> RandevuListesiGetir(SqlConnection conn)
        {
            List<BRandevu> liste = new List<BRandevu>();

            StringBuilder sql = new StringBuilder();

            // INNER JOIN ile Hasta ve Doktor bilgilerini çekiyoruz, LEFT JOIN ile Tedavi bilgisi
            sql.Append("SELECT r.Id, r.HastaTc, r.DoktorSicil, r.RandevuTarihi, r.Notlar, r.Durum, r.TedaviId, ");
            sql.Append("h.Ad + ' ' + h.Soyad AS HastaAdi, ");
            sql.Append("d.Ad + ' ' + d.Soyad AS DoktorAdi, ");
            sql.Append("t.TedaviAdi ");
            sql.Append("FROM T_RANDEVU r ");
            sql.Append("INNER JOIN T_HASTA h ON r.HastaTc = h.TcKimlikNo ");
            sql.Append("LEFT JOIN T_DOKTOR d ON r.DoktorSicil = d.TcKimlikNo ");
            sql.Append("LEFT JOIN T_TEDAVI t ON r.TedaviId = t.Id ");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BRandevu randevu = new BRandevu();
                        randevu.Id = Convert.ToInt32(dr["Id"]);
                        randevu.HastaTc = Convert.ToInt64(dr["HastaTc"]);
                        randevu.DoktorSicil = dr["DoktorSicil"] != DBNull.Value ? Convert.ToInt64(dr["DoktorSicil"]) : 0;
                        randevu.RandevuTarihi = Convert.ToDateTime(dr["RandevuTarihi"]);
                        randevu.Notlar = dr["Notlar"] != DBNull.Value ? dr["Notlar"].ToString() : "";
                        randevu.Durum = Convert.ToBoolean(dr["Durum"]);
                        randevu.HastaAdi = dr["HastaAdi"] != DBNull.Value ? dr["HastaAdi"].ToString() : "";
                        randevu.DoktorAdi = dr["DoktorAdi"] != DBNull.Value ? dr["DoktorAdi"].ToString() : "";
                        randevu.TedaviId = dr["TedaviId"] != DBNull.Value ? (int?)Convert.ToInt32(dr["TedaviId"]) : null;
                        randevu.TedaviAdi = dr["TedaviAdi"] != DBNull.Value ? dr["TedaviAdi"].ToString() : "";

                        liste.Add(randevu);
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// Id'ye göre kaydı siler
        /// </summary>
        public static void RandevuSil(SqlConnection conn, int id)
        {
            string sql = "DELETE FROM T_RANDEVU WHERE Id = @Id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Id'ye göre bilgileri günceller
        /// </summary>
        public static void RandevuGuncelle(SqlConnection conn, BRandevu randevu)
        {
            StringBuilder sql = new StringBuilder();

            // GÜNCELLEME SORGUSU
            sql.Append("UPDATE T_RANDEVU SET ");
            sql.Append("HastaTc = @HastaTc, ");
            sql.Append("DoktorSicil = @DoktorSicil, ");
            sql.Append("RandevuTarihi = @RandevuTarihi, ");
            sql.Append("Notlar = @Notlar, ");
            sql.Append("Durum = @Durum, ");
            sql.Append("TedaviId = @TedaviId ");

            sql.Append("WHERE Id = @Id");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                // Kimlik (Değişmeyen Anahtar)
                cmd.Parameters.AddWithValue("@Id", randevu.Id);

                // Değişecek Bilgiler
                cmd.Parameters.AddWithValue("@HastaTc", randevu.HastaTc);
                cmd.Parameters.AddWithValue("@DoktorSicil", randevu.DoktorSicil);
                cmd.Parameters.AddWithValue("@RandevuTarihi", randevu.RandevuTarihi);
                cmd.Parameters.AddWithValue("@Notlar", randevu.Notlar ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Durum", randevu.Durum);
                cmd.Parameters.AddWithValue("@TedaviId", randevu.TedaviId.HasValue ? (object)randevu.TedaviId.Value : DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }
    }
}

