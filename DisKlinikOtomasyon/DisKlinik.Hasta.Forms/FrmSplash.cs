using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisKlinik.Hasta.Forms
{
    public partial class FrmSplash : Form
    {
        private Timer timerProgress;
        private int currentProgress = 0;
        private int maxProgress = 100;
        private int progressStep = 2; // Her tick'te artış miktarı

        public FrmSplash()
        {
            InitializeComponent();
            
            // Logo ikonunu ayarla (Icon'u Image'e dönüştür)
            if (picLogo != null)
            {
                picLogo.Image = Properties.Resources.Gemini_Generated_Image_brv29rbrv;
            }
            
            InitializeProgressBar();
        }

        private void InitializeProgressBar()
        {
            // Progress bar başlangıç ayarları
            pnlProgress.Width = 0;
            currentProgress = 0;
            lblStatus.Text = "Sistem başlatılıyor...";

            // Timer ayarları
            timerProgress = new Timer();
            timerProgress.Interval = 50; // 50ms
            timerProgress.Tick += TimerProgress_Tick;
            timerProgress.Start();
        }

        private void TimerProgress_Tick(object sender, EventArgs e)
        {
            currentProgress += progressStep;

            // Progress bar genişliğini güncelle
            int maxWidth = pnlBackground.Width;
            int newWidth = (int)((currentProgress / (double)maxProgress) * maxWidth);
            
            if (newWidth > maxWidth)
                newWidth = maxWidth;

            pnlProgress.Width = newWidth;

            // Durum mesajlarını güncelle
            UpdateStatusMessage();

            // Progress tamamlandıysa timer'ı durdur ve formu kapat
            if (currentProgress >= maxProgress)
            {
                timerProgress.Stop();
                timerProgress.Dispose();
                
                // Kısa bir gecikme sonrası formu kapat
                System.Threading.Thread.Sleep(300);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void UpdateStatusMessage()
        {
            if (currentProgress < 20)
            {
                lblStatus.Text = "Sistem başlatılıyor...";
            }
            else if (currentProgress < 40)
            {
                lblStatus.Text = "Veritabanına bağlanılıyor...";
            }
            else if (currentProgress < 60)
            {
                lblStatus.Text = "Modüller yükleniyor...";
            }
            else if (currentProgress < 80)
            {
                lblStatus.Text = "Yapay zeka servisi hazırlanıyor...";
            }
            else if (currentProgress < 95)
            {
                lblStatus.Text = "Son kontroller yapılıyor...";
            }
            else
            {
                lblStatus.Text = "Hazır!";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (timerProgress != null && timerProgress.Enabled)
            {
                timerProgress.Stop();
                timerProgress.Dispose();
            }
            base.OnFormClosing(e);
        }

        private void lblBaslik_Click(object sender, EventArgs e)
        {

        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }
    }
}

