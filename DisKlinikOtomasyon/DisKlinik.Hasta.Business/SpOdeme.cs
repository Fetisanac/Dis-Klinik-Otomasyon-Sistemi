using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; // SQL Server için gerekli
using System.Text; // StringBuilder için gerekli

namespace DisKlinik.Hasta.Business
{
    public class SpOdeme
    {
        // STANDART: Connection burada create edilmez, parametre olarak gelir [cite: 299, 300]

        /// <summary>
        /// T_ODEME tablosuna kayıt ekler
        /// </summary>
        public static void OdemeEkle(SqlConnection conn, BOdeme odeme)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO T_ODEME (HastaTc, Tarih, Tutar, IslemTuru, Aciklama) ");
            sql.Append("VALUES (@HastaTc, @Tarih, @Tutar, @IslemTuru, @Aciklama)");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                // Standart Parametreler
                cmd.Parameters.AddWithValue("@HastaTc", odeme.HastaTc);
                cmd.Parameters.AddWithValue("@Tarih", odeme.Tarih);
                cmd.Parameters.AddWithValue("@Tutar", odeme.Tutar);
                cmd.Parameters.AddWithValue("@IslemTuru", odeme.IslemTuru);

                // (Null kontrolü yaparak ekliyoruz ki boş bırakılırsa hata vermesin)
                cmd.Parameters.AddWithValue("@Aciklama", odeme.Aciklama ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Hasta TC'ye göre ödeme listesini çeker
        /// </summary>
        public static List<BOdeme> OdemeListesiGetir(SqlConnection conn, long hastaTc)
        {
            List<BOdeme> liste = new List<BOdeme>();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT Id, HastaTc, Tarih, Tutar, IslemTuru, Aciklama FROM T_ODEME ");
            sql.Append("WHERE HastaTc = @HastaTc ");
            sql.Append("ORDER BY Tarih DESC");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                cmd.Parameters.AddWithValue("@HastaTc", hastaTc);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BOdeme odeme = new BOdeme();
                        odeme.Id = Convert.ToInt32(dr["Id"]);
                        odeme.HastaTc = Convert.ToInt64(dr["HastaTc"]);
                        odeme.Tarih = Convert.ToDateTime(dr["Tarih"]);
                        odeme.Tutar = Convert.ToDecimal(dr["Tutar"]);
                        odeme.IslemTuru = Convert.ToInt32(dr["IslemTuru"]);
                        odeme.Aciklama = dr["Aciklama"] != DBNull.Value ? dr["Aciklama"].ToString() : "";

                        liste.Add(odeme);
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// Tüm ödeme listesini çeker (Kasa için)
        /// </summary>
        public static List<BOdeme> OdemeListesiGetir(SqlConnection conn)
        {
            List<BOdeme> liste = new List<BOdeme>();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT Id, HastaTc, Tarih, Tutar, IslemTuru, Aciklama FROM T_ODEME ");
            sql.Append("ORDER BY Tarih DESC");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BOdeme odeme = new BOdeme();
                        odeme.Id = Convert.ToInt32(dr["Id"]);
                        odeme.HastaTc = Convert.ToInt64(dr["HastaTc"]);
                        odeme.Tarih = Convert.ToDateTime(dr["Tarih"]);
                        odeme.Tutar = Convert.ToDecimal(dr["Tutar"]);
                        odeme.IslemTuru = Convert.ToInt32(dr["IslemTuru"]);
                        odeme.Aciklama = dr["Aciklama"] != DBNull.Value ? dr["Aciklama"].ToString() : "";

                        liste.Add(odeme);
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// Kasa özetini getirir (Toplam Tahsilat ve Toplam Alacak)
        /// </summary>
        public static BKasaOzet KasaOzetGetir(SqlConnection conn)
        {
            BKasaOzet ozet = new BKasaOzet();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT ");
            sql.Append("ISNULL(SUM(CASE WHEN IslemTuru = 1 THEN Tutar ELSE 0 END), 0) AS ToplamTahsilat, ");
            sql.Append("ISNULL(SUM(CASE WHEN IslemTuru = 0 THEN Tutar ELSE 0 END), 0) - ");
            sql.Append("ISNULL(SUM(CASE WHEN IslemTuru = 1 THEN Tutar ELSE 0 END), 0) AS ToplamAlacak ");
            sql.Append("FROM T_ODEME");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        ozet.ToplamTahsilat = Convert.ToDecimal(dr["ToplamTahsilat"]);
                        ozet.ToplamAlacak = Convert.ToDecimal(dr["ToplamAlacak"]);
                    }
                }
            }
            return ozet;
        }

        /// <summary>
        /// Id'ye göre kaydı siler
        /// </summary>
        public static void OdemeSil(SqlConnection conn, int id)
        {
            string sql = "DELETE FROM T_ODEME WHERE Id = @Id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

