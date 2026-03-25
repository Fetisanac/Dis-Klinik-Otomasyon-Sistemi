using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DisKlinik.Hasta.Business
{
    public class SpLog
    {
        // STANDART: Connection burada create edilmez, parametre olarak gelir

        /// <summary>
        /// T_LOG tablosuna log kaydı ekler
        /// </summary>
        public static void LogEkle(SqlConnection conn, BLog log)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO T_LOG (KullaniciAdi, IslemTuru, Aciklama, Tarih) ");
            sql.Append("VALUES (@KullaniciAdi, @IslemTuru, @Aciklama, @Tarih)");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                cmd.Parameters.AddWithValue("@KullaniciAdi", log.KullaniciAdi);
                cmd.Parameters.AddWithValue("@IslemTuru", log.IslemTuru);
                cmd.Parameters.AddWithValue("@Aciklama", log.Aciklama ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Tarih", log.Tarih);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tüm log listesini çeker (Tarihe göre azalan sırada)
        /// </summary>
        public static List<BLog> LogListesiGetir(SqlConnection conn)
        {
            List<BLog> liste = new List<BLog>();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT Id, KullaniciAdi, IslemTuru, Aciklama, Tarih FROM T_LOG ");
            sql.Append("ORDER BY Tarih DESC");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BLog log = new BLog();
                        log.Id = Convert.ToInt32(dr["Id"]);
                        log.KullaniciAdi = dr["KullaniciAdi"].ToString();
                        log.IslemTuru = dr["IslemTuru"].ToString();
                        log.Aciklama = dr["Aciklama"] != DBNull.Value ? dr["Aciklama"].ToString() : "";
                        log.Tarih = Convert.ToDateTime(dr["Tarih"]);

                        liste.Add(log);
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// Tüm log kayıtlarını siler
        /// </summary>
        public static void TumLoglariTemizle(SqlConnection conn)
        {
            string sql = "DELETE FROM T_LOG";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}





