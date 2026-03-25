using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DisKlinik.Hasta.Business
{
    public class SpRecete
    {
        // STANDART: Connection burada create edilmez, parametre olarak gelir

        /// <summary>
        /// T_RECETE tablosuna reçete kaydı ekler
        /// </summary>
        public static void ReceteEkle(SqlConnection conn, BRecete recete)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO T_RECETE (RandevuId, Tani, Ilaclar, Tarih) ");
            sql.Append("VALUES (@RandevuId, @Tani, @Ilaclar, @Tarih)");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                cmd.Parameters.AddWithValue("@RandevuId", recete.RandevuId);
                cmd.Parameters.AddWithValue("@Tani", recete.Tani);
                cmd.Parameters.AddWithValue("@Ilaclar", recete.Ilaclar ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Tarih", recete.Tarih);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tüm reçete listesini çeker (Hasta bilgileri ile birlikte)
        /// </summary>
        public static List<BRecete> ReceteListesiGetir(SqlConnection conn)
        {
            List<BRecete> liste = new List<BRecete>();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT r.Id, r.RandevuId, r.Tani, r.Ilaclar, r.Tarih, ");
            sql.Append("h.Ad + ' ' + h.Soyad AS HastaAdi ");
            sql.Append("FROM T_RECETE r ");
            sql.Append("INNER JOIN T_RANDEVU rand ON r.RandevuId = rand.Id ");
            sql.Append("INNER JOIN T_HASTA h ON rand.HastaTc = h.TcKimlikNo ");
            sql.Append("ORDER BY r.Tarih DESC");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BRecete recete = new BRecete();
                        recete.Id = Convert.ToInt32(dr["Id"]);
                        recete.RandevuId = Convert.ToInt32(dr["RandevuId"]);
                        recete.Tani = dr["Tani"].ToString();
                        recete.Ilaclar = dr["Ilaclar"] != DBNull.Value ? dr["Ilaclar"].ToString() : "";
                        recete.Tarih = Convert.ToDateTime(dr["Tarih"]);
                        recete.HastaAdi = dr["HastaAdi"].ToString();
                        liste.Add(recete);
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// Id'ye göre reçete kaydını siler
        /// </summary>
        public static void ReceteSil(SqlConnection conn, int id)
        {
            string sql = "DELETE FROM T_RECETE WHERE Id = @Id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Randevu listesini reçete yazma için getirir (Bugün ve gelecek randevular, aktif olanlar)
        /// </summary>
        public static List<BRandevu> RandevuListesiGetir(SqlConnection conn)
        {
            List<BRandevu> liste = new List<BRandevu>();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT r.Id, r.RandevuTarihi, ");
            sql.Append("h.Ad + ' ' + h.Soyad AS HastaAdi ");
            sql.Append("FROM T_RANDEVU r ");
            sql.Append("INNER JOIN T_HASTA h ON r.HastaTc = h.TcKimlikNo ");
            sql.Append("WHERE r.Durum = 1 AND CAST(r.RandevuTarihi AS DATE) >= CAST(GETDATE() AS DATE) ");
            sql.Append("ORDER BY r.RandevuTarihi ASC");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BRandevu randevu = new BRandevu();
                        randevu.Id = Convert.ToInt32(dr["Id"]);
                        randevu.RandevuTarihi = Convert.ToDateTime(dr["RandevuTarihi"]);
                        randevu.HastaAdi = dr["HastaAdi"].ToString();
                        liste.Add(randevu);
                    }
                }
            }
            return liste;
        }
    }
}





