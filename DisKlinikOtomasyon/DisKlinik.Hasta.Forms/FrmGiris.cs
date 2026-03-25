using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DisKlinik.Hasta.Business; // Oturum için
using DevExpress.XtraEditors; // DevExpress kontrolleri için

namespace DisKlinik.Hasta.Forms
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            // Validasyon
            if (string.IsNullOrEmpty(kullaniciAdi))
            {
                MessageBox.Show("Lütfen kullanıcı adınızı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciAdi.Focus();
                return;
            }

            if (string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen şifrenizi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSifre.Focus();
                return;
            }

            // Servis katmanından giriş kontrolü
            DisKlinik.Hasta.Service.SKullanici kullaniciServis = new DisKlinik.Hasta.Service.SKullanici();
            string rol = kullaniciServis.KullaniciGiris(kullaniciAdi, sifre);

            if (rol == null)
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKullaniciAdi.Text = "";
                txtSifre.Text = "";
                txtKullaniciAdi.Focus();
            }
            else
            {
                // Session Management - Güncel kullanıcı adını ve rolünü set et
                Oturum.GuncelKullaniciAdi = kullaniciAdi;
                Oturum.GuncelKullaniciRolu = rol;

                if (rol == "Yonetici")
                {
                    // Yönetici panelini aç
                    this.Hide();
                    FrmYonetici frmYonetici = new FrmYonetici();
                    frmYonetici.ShowDialog();
                    this.Close();
                }
                else if (rol == "Personel")
                {
                    // Ana sayfayı aç
                    this.Hide();
                    FrmAnaSayfa frmAnaSayfa = new FrmAnaSayfa();
                    frmAnaSayfa.ShowDialog();
                    this.Close();
                }
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Uygulamadan çıkmak istediğinize emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

