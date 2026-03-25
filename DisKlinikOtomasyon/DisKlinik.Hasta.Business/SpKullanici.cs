using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DisKlinik.Hasta.Business
{
    public class SpKullanici
    {
        // STANDART: Connection burada create edilmez, parametre olarak gelir

        /// <summary>
        /// Kullanıcı giriş kontrolü yapar ve Rol döndürür
        /// </summary>
        public static string KullaniciGiris(SqlConnection conn, string kullaniciAdi, string sifre)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT Rol FROM T_KULLANICI ");
            sql.Append("WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                cmd.Parameters.AddWithValue("@Sifre", sifre);

                object sonuc = cmd.ExecuteScalar();

                if (sonuc != null && sonuc != DBNull.Value)
                {
                    return sonuc.ToString();
                }
            }

            return null; // Giriş başarısız
        }
    }
}





