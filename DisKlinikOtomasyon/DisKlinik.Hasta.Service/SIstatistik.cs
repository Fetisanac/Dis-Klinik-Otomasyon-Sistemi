using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DisKlinik.Hasta.Interface;
using DisKlinik.Hasta.Business;

namespace DisKlinik.Hasta.Service
{
    public class SIstatistik : IIstatistik
    {
        public List<Bİstatistik> EnCokYapilanTedaviler()
        {
            List<Bİstatistik> sonuc = new List<Bİstatistik>();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    // Business katmanından veriyi çek
                    sonuc = SpIstatistik.EnCokYapilanTedaviler(conn);
                }
                catch (Exception)
                {
                    // Hata durumunda boş liste döner
                }
            }
            return sonuc;
        }

        public List<Bİstatistik> GunlukKazancGrafigi()
        {
            List<Bİstatistik> sonuc = new List<Bİstatistik>();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    // Business katmanından veriyi çek
                    sonuc = SpIstatistik.GunlukKazancGrafigi(conn);
                }
                catch (Exception)
                {
                    // Hata durumunda boş liste döner
                }
            }
            return sonuc;
        }
    }
}





