using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; // SQL Server için gerekli
using System.Text; // StringBuilder için gerekli

namespace DisKlinik.Hasta.Business
{
    public class SpTedavi
    {
        // STANDART: Connection burada create edilmez, parametre olarak gelir [cite: 299, 300]

        /// <summary>
        /// T_TEDAVI tablosuna kayıt ekler
        /// </summary>
        public static void TedaviEkle(SqlConnection conn, BTedavi tedavi)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO T_TEDAVI (TedaviAdi, BirimFiyat) ");
            sql.Append("VALUES (@TedaviAdi, @BirimFiyat)");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                // Standart Parametreler
                cmd.Parameters.AddWithValue("@TedaviAdi", tedavi.TedaviAdi);
                cmd.Parameters.AddWithValue("@BirimFiyat", tedavi.BirimFiyat);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tüm tedavi listesini çeker
        /// </summary>
        public static List<BTedavi> TedaviListesiGetir(SqlConnection conn)
        {
            List<BTedavi> liste = new List<BTedavi>();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT Id, TedaviAdi, BirimFiyat FROM T_TEDAVI ORDER BY TedaviAdi");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BTedavi tedavi = new BTedavi();
                        tedavi.Id = Convert.ToInt32(dr["Id"]);
                        tedavi.TedaviAdi = dr["TedaviAdi"].ToString();
                        tedavi.BirimFiyat = Convert.ToDecimal(dr["BirimFiyat"]);

                        liste.Add(tedavi);
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// Id'ye göre kaydı siler
        /// </summary>
        public static void TedaviSil(SqlConnection conn, int id)
        {
            string sql = "DELETE FROM T_TEDAVI WHERE Id = @Id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Id'ye göre bilgileri günceller
        /// </summary>
        public static void TedaviGuncelle(SqlConnection conn, BTedavi tedavi)
        {
            StringBuilder sql = new StringBuilder();

            // GÜNCELLEME SORGUSU
            sql.Append("UPDATE T_TEDAVI SET ");
            sql.Append("TedaviAdi = @TedaviAdi, ");
            sql.Append("BirimFiyat = @BirimFiyat ");

            sql.Append("WHERE Id = @Id");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                // Kimlik (Değişmeyen Anahtar)
                cmd.Parameters.AddWithValue("@Id", tedavi.Id);

                // Değişecek Bilgiler
                cmd.Parameters.AddWithValue("@TedaviAdi", tedavi.TedaviAdi);
                cmd.Parameters.AddWithValue("@BirimFiyat", tedavi.BirimFiyat);

                cmd.ExecuteNonQuery();
            }
        }
    }
}





