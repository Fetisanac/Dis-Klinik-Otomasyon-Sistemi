using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DisKlinik.Hasta.Business
{
    public class SpIstatistik
    {
        // STANDART: Connection burada create edilmez, parametre olarak gelir

        /// <summary>
        /// En çok yapılan tedavileri getirir (TOP 5)
        /// </summary>
        public static List<Bİstatistik> EnCokYapilanTedaviler(SqlConnection conn)
        {
            List<Bİstatistik> liste = new List<Bİstatistik>();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT TOP 5 t.TedaviAdi AS Etiket, COUNT(*) AS Deger ");
            sql.Append("FROM T_RANDEVU r ");
            sql.Append("INNER JOIN T_TEDAVI t ON r.TedaviId = t.Id ");
            sql.Append("WHERE r.TedaviId IS NOT NULL ");
            sql.Append("GROUP BY t.TedaviAdi ");
            sql.Append("ORDER BY Deger DESC");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Bİstatistik istatistik = new Bİstatistik();
                        istatistik.Etiket = dr["Etiket"].ToString();
                        istatistik.Deger = Convert.ToDecimal(dr["Deger"]);
                        liste.Add(istatistik);
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// Son 7 günün günlük kazanç grafiğini getirir
        /// </summary>
        public static List<Bİstatistik> GunlukKazancGrafigi(SqlConnection conn)
        {
            List<Bİstatistik> liste = new List<Bİstatistik>();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT CAST(Tarih AS DATE) AS Etiket, SUM(Tutar) AS Deger ");
            sql.Append("FROM T_ODEME ");
            sql.Append("WHERE IslemTuru = 1 AND Tarih >= DATEADD(DAY, -6, CAST(GETDATE() AS DATE)) ");
            sql.Append("GROUP BY CAST(Tarih AS DATE) ");
            sql.Append("ORDER BY Etiket ASC");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Bİstatistik istatistik = new Bİstatistik();
                        // Tarihi string formatına çevir
                        DateTime tarih = Convert.ToDateTime(dr["Etiket"]);
                        istatistik.Etiket = tarih.ToString("dd.MM.yyyy");
                        istatistik.Deger = Convert.ToDecimal(dr["Deger"]);
                        liste.Add(istatistik);
                    }
                }
            }
            return liste;
        }
    }
}





