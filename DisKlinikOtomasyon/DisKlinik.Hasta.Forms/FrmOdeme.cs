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
    public partial class FrmOdeme : Form
    {
        public FrmOdeme()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Single-Window Navigation için
        }

        private void FrmOdeme_Load(object sender, EventArgs e)
        {
            ComboBoxlariDoldur();
            KasaYenile();
        }

        private void ComboBoxlariDoldur()
        {
            // Hasta listesini doldur (Tab 1 - Borç)
            DisKlinik.Hasta.Service.SHasta hastaServis = new DisKlinik.Hasta.Service.SHasta();
            List<DisKlinik.Hasta.Business.BHasta> hastaListesi = hastaServis.HastaListesiGetir();
            cmbHasta_Borc.DataSource = hastaListesi;
            cmbHasta_Borc.DisplayMember = "AdSoyad";
            cmbHasta_Borc.ValueMember = "TcKimlikNo";

            // Hasta listesini doldur (Tab 2 - Ödeme)
            cmbHasta_Odeme.DataSource = hastaListesi;
            cmbHasta_Odeme.DisplayMember = "AdSoyad";
            cmbHasta_Odeme.ValueMember = "TcKimlikNo";

            // Tedavi listesini doldur (Tab 1 - Borç)
            DisKlinik.Hasta.Service.STedavi tedaviServis = new DisKlinik.Hasta.Service.STedavi();
            List<DisKlinik.Hasta.Business.BTedavi> tedaviListesi = tedaviServis.TedaviListesiGetir();
            cmbTedavi.DataSource = tedaviListesi;
            cmbTedavi.DisplayMember = "TedaviAdi";
            cmbTedavi.ValueMember = "BirimFiyat";
        }

        // ========== TAB 1: TEDAVİ & BORÇ EKLE ==========

        private void cmbTedavi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTedavi.SelectedItem != null)
            {
                DisKlinik.Hasta.Business.BTedavi seciliTedavi = (DisKlinik.Hasta.Business.BTedavi)cmbTedavi.SelectedItem;
                numTutar_Borc.Value = seciliTedavi.BirimFiyat;
            }
        }

        private void btnBorcKaydet_Click(object sender, EventArgs e)
        {
            // Validasyonlar
            if (cmbHasta_Borc.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir hasta seçiniz.");
                return;
            }

            if (cmbTedavi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir tedavi seçiniz.");
                return;
            }

            // Veri Nesnesini Oluştur
            DisKlinik.Hasta.Business.BOdeme yeniBorc = new DisKlinik.Hasta.Business.BOdeme();

            DisKlinik.Hasta.Business.BHasta seciliHasta = (DisKlinik.Hasta.Business.BHasta)cmbHasta_Borc.SelectedItem;
            yeniBorc.HastaTc = seciliHasta.TcKimlikNo;

            DisKlinik.Hasta.Business.BTedavi seciliTedavi = (DisKlinik.Hasta.Business.BTedavi)cmbTedavi.SelectedItem;
            yeniBorc.Tutar = numTutar_Borc.Value;
            yeniBorc.Aciklama = seciliTedavi.TedaviAdi; // Tedavi adı otomatik açıklama olarak kaydedilir
            yeniBorc.Tarih = dtpTarih_Borc.Value;
            yeniBorc.IslemTuru = 0; // Borç

            // Servise Gönder
            DisKlinik.Hasta.Service.SOdeme servis = new DisKlinik.Hasta.Service.SOdeme();
            string sonuc = servis.OdemeEkle(yeniBorc);

            if (sonuc != null)
            {
                MessageBox.Show("Hata: " + sonuc);
            }
            else
            {
                MessageBox.Show("Borç başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Temizlik
                cmbHasta_Borc.SelectedIndex = -1;
                cmbTedavi.SelectedIndex = -1;
                numTutar_Borc.Value = 0;

                // Kasa'yı yenile
                KasaYenile();
            }
        }

        // ========== TAB 2: ÖDEME AL ==========

        private void cmbHasta_Odeme_SelectedIndexChanged(object sender, EventArgs e)
        {
            BakiyeyiGoster();
        }

        private void BakiyeyiGoster()
        {
            if (cmbHasta_Odeme.SelectedItem == null)
            {
                lblGuncelBakiye.Text = "Kalan Borç: 0 TL";
                return;
            }

            DisKlinik.Hasta.Business.BHasta seciliHasta = (DisKlinik.Hasta.Business.BHasta)cmbHasta_Odeme.SelectedItem;
            long hastaTc = seciliHasta.TcKimlikNo;

            // Hasta işlemlerini getir
            DisKlinik.Hasta.Service.SOdeme servis = new DisKlinik.Hasta.Service.SOdeme();
            List<DisKlinik.Hasta.Business.BOdeme> liste = servis.OdemeListesiGetir(hastaTc);

            decimal toplamBorc = 0;
            decimal toplamOdeme = 0;

            foreach (var odeme in liste)
            {
                if (odeme.IslemTuru == 0) // Borç
                {
                    toplamBorc += odeme.Tutar;
                }
                else if (odeme.IslemTuru == 1) // Ödeme
                {
                    toplamOdeme += odeme.Tutar;
                }
            }

            decimal bakiye = toplamBorc - toplamOdeme;

            if (bakiye > 0)
            {
                lblGuncelBakiye.Text = $"Kalan Borç: {bakiye:N2} TL";
                lblGuncelBakiye.ForeColor = Color.DarkRed;
            }
            else if (bakiye < 0)
            {
                lblGuncelBakiye.Text = $"Alacak: {Math.Abs(bakiye):N2} TL";
                lblGuncelBakiye.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblGuncelBakiye.Text = "Bakiye: 0 TL";
                lblGuncelBakiye.ForeColor = Color.Black;
            }
        }

        private void btnOdemeKaydet_Click(object sender, EventArgs e)
        {
            // Validasyonlar
            if (cmbHasta_Odeme.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir hasta seçiniz.");
                return;
            }

            if (numOdemeTutari.Value <= 0)
            {
                MessageBox.Show("Ödeme tutarı sıfırdan büyük olmalıdır.");
                return;
            }

            // Veri Nesnesini Oluştur
            DisKlinik.Hasta.Business.BOdeme yeniOdeme = new DisKlinik.Hasta.Business.BOdeme();

            DisKlinik.Hasta.Business.BHasta seciliHasta = (DisKlinik.Hasta.Business.BHasta)cmbHasta_Odeme.SelectedItem;
            yeniOdeme.HastaTc = seciliHasta.TcKimlikNo;
            yeniOdeme.Tutar = numOdemeTutari.Value;
            yeniOdeme.Tarih = dtpTarih_Odeme.Value;
            yeniOdeme.Aciklama = "Nakit Ödeme";
            yeniOdeme.IslemTuru = 1; // Ödeme

            // Servise Gönder
            DisKlinik.Hasta.Service.SOdeme servis = new DisKlinik.Hasta.Service.SOdeme();
            string sonuc = servis.OdemeEkle(yeniOdeme);

            if (sonuc != null)
            {
                MessageBox.Show("Hata: " + sonuc);
            }
            else
            {
                MessageBox.Show("Ödeme başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Temizlik
                numOdemeTutari.Value = 0;

                // Bakiyeyi yenile
                BakiyeyiGoster();

                // Kasa'yı yenile
                KasaYenile();
            }
        }

        // ========== TAB 3: KASA & RAPOR ==========

        private void btnKasaYenile_Click(object sender, EventArgs e)
        {
            KasaYenile();
        }

        private void KasaYenile()
        {
            // Kasa özetini getir
            DisKlinik.Hasta.Service.SOdeme servis = new DisKlinik.Hasta.Service.SOdeme();
            DisKlinik.Hasta.Business.BKasaOzet ozet = servis.KasaOzetGetir();

            // Toplam Ciro (Tahsilat)
            lblToplamCiro.Text = $"Toplam Ciro: {ozet.ToplamTahsilat:N2} TL";
            lblToplamCiro.ForeColor = Color.DarkGreen;

            // Toplam Alacak
            if (ozet.ToplamAlacak > 0)
            {
                lblToplamAlacak.Text = $"Toplam Alacak: {ozet.ToplamAlacak:N2} TL";
                lblToplamAlacak.ForeColor = Color.DarkRed;
            }
            else if (ozet.ToplamAlacak < 0)
            {
                lblToplamAlacak.Text = $"Toplam Fazla Ödeme: {Math.Abs(ozet.ToplamAlacak):N2} TL";
                lblToplamAlacak.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblToplamAlacak.Text = "Toplam Alacak: 0 TL";
                lblToplamAlacak.ForeColor = Color.Black;
            }

            // Tüm işlemleri getir
            grdTumIslemler.DataSource = null;
            grdTumIslemler.DataSource = servis.OdemeListesiGetir();
        }
    }
}
