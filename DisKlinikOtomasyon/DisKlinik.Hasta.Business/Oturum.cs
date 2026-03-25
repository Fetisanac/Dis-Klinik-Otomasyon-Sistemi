using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKlinik.Hasta.Business
{
    /// <summary>
    /// Session Management - Global kullanıcı bilgilerini tutar
    /// </summary>
    public static class Oturum
    {
        /// <summary>
        /// Güncel oturum açmış kullanıcının adı
        /// </summary>
        public static string GuncelKullaniciAdi { get; set; }
        
        /// <summary>
        /// Güncel oturum açmış kullanıcının rolü (Yonetici veya Personel)
        /// </summary>
        public static string GuncelKullaniciRolu { get; set; }
    }
}





