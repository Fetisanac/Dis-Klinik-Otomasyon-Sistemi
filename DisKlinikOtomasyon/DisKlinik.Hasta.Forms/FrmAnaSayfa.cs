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
    public partial class FrmAnaSayfa : Form
    {
        private Form aktifForm = null; // Şu anda gösterilen form

        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form'u içerik panelinde gösterir
        /// </summary>
        private void FormGetir(Form frm)
        {
            // Önceki formu temizle
            if (aktifForm != null)
            {
                aktifForm.Hide();
                aktifForm.Dispose();
            }

            // İçerik panelini temizle
            pnlIcerik.Controls.Clear();

            // Yeni formu ayarla
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Visible = true;

            // İçerik paneline ekle
            pnlIcerik.Controls.Add(frm);

            // Başlığı güncelle
            lblBaslik.Text = frm.Text;

            // Geri butonunu göster
            btnGeri.Visible = true;

            // Aktif formu kaydet
            aktifForm = frm;
        }

        /// <summary>
        /// Ana menüye döner
        /// </summary>
        private void AnaMenuyeDon()
        {
            // Aktif formu temizle
            if (aktifForm != null)
            {
                aktifForm.Hide();
                aktifForm.Dispose();
                aktifForm = null;
            }

            // İçerik panelini temizle
            pnlIcerik.Controls.Clear();

            // Ana menü butonlarını tekrar ekle
            pnlIcerik.Controls.Add(tableLayoutPanel1);
            tableLayoutPanel1.BringToFront();

            // Başlığı güncelle
            lblBaslik.Text = "Ana Menü";

            // Geri butonunu gizle
            btnGeri.Visible = false;
        }

        private void btnHasta_Click(object sender, EventArgs e)
        {
            FormGetir(new FrmHastaKayit());
        }

        private void btnDoktor_Click(object sender, EventArgs e)
        {
            FormGetir(new FrmDoktorKayit());
        }

        private void btnRandevu_Click(object sender, EventArgs e)
        {
            FormGetir(new FrmRandevu());
        }

        private void btnTedavi_Click(object sender, EventArgs e)
        {
            FormGetir(new FrmTedavi());
        }

        private void btnRecete_Click(object sender, EventArgs e)
        {
            FormGetir(new FrmRecete());
        }

        private void btnYapayZeka_Click(object sender, EventArgs e)
        {
            FormGetir(new FrmYapayZeka());
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            AnaMenuyeDon();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Uygulamadan çıkmak istediğinize emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {

        }
    }
}
