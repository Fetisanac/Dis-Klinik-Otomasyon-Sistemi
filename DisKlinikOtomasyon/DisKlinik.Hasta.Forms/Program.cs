using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisKlinik.Hasta.Forms
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // |DataDirectory| değişkenini ayarla (Connection String'de kullanılacak)
            // Uygulamanın çalıştığı klasörü DataDirectory olarak ayarla
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Splash screen'i göster
            using (FrmSplash splash = new FrmSplash())
            {
                splash.ShowDialog();
            }

            // Splash kapandıktan sonra giriş ekranını aç
            Application.Run(new FrmGiris());
        }
    }
}
