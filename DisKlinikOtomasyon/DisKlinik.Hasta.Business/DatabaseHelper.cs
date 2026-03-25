using System;

namespace DisKlinik.Hasta.Business
{
    /// <summary>
    /// Veritabanı bağlantı string'ini dinamik olarak oluşturan static helper sınıfı
    /// </summary>
    public static class DatabaseHelper
    {
        /// <summary>
        /// |DataDirectory| kullanarak DisKlinikDB.mdf dosyasına bağlanan connection string oluşturur.
        /// |DataDirectory| değişkeni Program.cs'de AppDomain.SetData ile ayarlanmalıdır.
        /// </summary>
        /// <returns>Dinamik olarak oluşturulmuş connection string</returns>
        public static string GetConnectionString()
        {
            // Connection string'i oluştur (AttachDbFilename ile |DataDirectory| kullanarak)
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DisKlinikDB.mdf;Integrated Security=True;";
            
            return connectionString;
        }
    }
}

