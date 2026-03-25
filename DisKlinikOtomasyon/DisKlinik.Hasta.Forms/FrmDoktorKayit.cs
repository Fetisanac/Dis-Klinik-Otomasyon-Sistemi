using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DisKlinik.Hasta.Forms
{
    public partial class FrmDoktorKayit : Form
    {
        public FrmDoktorKayit()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Single-Window Navigation için
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. Veri Nesnesini Oluştur
            DisKlinik.Hasta.Business.BDoktor yeniDoktor = new DisKlinik.Hasta.Business.BDoktor();

            yeniDoktor.Ad = txtAd.Text;
            yeniDoktor.Soyad = txtSoyad.Text;
            yeniDoktor.Telefon = txtTelefon.Text;
            yeniDoktor.Adres = txtAdres.Text;
            yeniDoktor.DogumTarihi = dtpDogumTarihi.Value;
            yeniDoktor.Brans = txtBrans.Text;
            yeniDoktor.SicilNo = txtSicilNo.Text;
            // --------------------------------------------------------

            // TC Kimlik Çevirimi
            if (long.TryParse(txtTcKimlik.Text, out long tcNo))
            {
                yeniDoktor.TcKimlikNo = tcNo;
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir TC giriniz.");
                return;
            }

            // Servise Gönder
            DisKlinik.Hasta.Service.SDoktor servis = new DisKlinik.Hasta.Service.SDoktor();
            string sonuc = servis.DoktorEkle(yeniDoktor);

            if (sonuc != null)
            {
                MessageBox.Show("Hata: " + sonuc);
            }
            else
            {
                MessageBox.Show("Doktor başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Temizlik
                txtAd.Text = ""; txtSoyad.Text = ""; txtTcKimlik.Text = "";
                txtTelefon.Text = ""; txtAdres.Text = "";
                txtBrans.Text = ""; txtSicilNo.Text = "";

                // Listeyi Yenile
                ListeyiYenile();
            }
        }

        private void ListeyiYenile()
        {
            // Servis katmanından örneği oluştur
            DisKlinik.Hasta.Service.SDoktor servis = new DisKlinik.Hasta.Service.SDoktor();

            // Tabloyu önce temizle
            grdDoktorListesi.DataSource = null;

            // Servisten gelen listeyi tabloya bağla
            grdDoktorListesi.DataSource = servis.DoktorListesiGetir();
        }

        private void FrmDoktorKayit_Load(object sender, EventArgs e)
        {
            ListeyiYenile();
        }

        private void grdDoktorListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Başlığa tıklarsa işlem yapma
            if (e.RowIndex < 0) return;

            // Seçili satırı al
            DataGridViewRow satir = grdDoktorListesi.Rows[e.RowIndex];

            // Kutuları doldur
            txtTcKimlik.Text = satir.Cells["TcKimlikNo"].Value.ToString();
            txtAd.Text = satir.Cells["Ad"].Value.ToString();
            txtSoyad.Text = satir.Cells["Soyad"].Value.ToString();
            txtTelefon.Text = satir.Cells["Telefon"].Value != null ? satir.Cells["Telefon"].Value.ToString() : "";
            txtAdres.Text = satir.Cells["Adres"].Value != null ? satir.Cells["Adres"].Value.ToString() : "";
            txtBrans.Text = satir.Cells["Brans"].Value != null ? satir.Cells["Brans"].Value.ToString() : "";
            txtSicilNo.Text = satir.Cells["SicilNo"].Value != null ? satir.Cells["SicilNo"].Value.ToString() : "";

            // Tarih doluysa al
            if (satir.Cells["DogumTarihi"].Value != null && satir.Cells["DogumTarihi"].Value.ToString() != "")
            {
                dtpDogumTarihi.Value = Convert.ToDateTime(satir.Cells["DogumTarihi"].Value);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (long.TryParse(txtTcKimlik.Text, out long tcNo))
                {
                    DisKlinik.Hasta.Service.SDoktor servis = new DisKlinik.Hasta.Service.SDoktor();
                    string sonuc = servis.DoktorSil(tcNo);

                    if (sonuc == null)
                    {
                        MessageBox.Show("Kayıt Silindi.");
                        ListeyiYenile(); // Tabloyu tazele
                        // Kutuları temizleyebilirsin
                        txtTcKimlik.Text = ""; txtAd.Text = ""; txtSoyad.Text = "";
                        txtTelefon.Text = ""; txtAdres.Text = "";
                        txtBrans.Text = ""; txtSicilNo.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Hata: " + sonuc);
                    }
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // 1. Önce bir TC seçili mi kontrol et
            if (string.IsNullOrEmpty(txtTcKimlik.Text))
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz kişiyi tablodan seçiniz.");
                return;
            }

            DisKlinik.Hasta.Business.BDoktor guncelDoktor = new DisKlinik.Hasta.Business.BDoktor();

            guncelDoktor.Ad = txtAd.Text;
            guncelDoktor.Soyad = txtSoyad.Text;
            guncelDoktor.Telefon = txtTelefon.Text;
            guncelDoktor.Adres = txtAdres.Text;
            guncelDoktor.DogumTarihi = dtpDogumTarihi.Value;
            guncelDoktor.Brans = txtBrans.Text;
            guncelDoktor.SicilNo = txtSicilNo.Text;
            // -----------------------------------------------------------

            // TC Kimlik (Değişmez kimlik bilgimiz)
            if (long.TryParse(txtTcKimlik.Text, out long tcNo))
            {
                guncelDoktor.TcKimlikNo = tcNo;
            }
            else
            {
                MessageBox.Show("Geçersiz TC Kimlik No.");
                return;
            }

            // 3. Servise Gönder
            DisKlinik.Hasta.Service.SDoktor servis = new DisKlinik.Hasta.Service.SDoktor();
            string sonuc = servis.DoktorGuncelle(guncelDoktor);

            if (sonuc == null)
            {
                MessageBox.Show("Kayıt başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeyiYenile(); // Tabloyu yenile ki değişikliği görelim
            }
            else
            {
                MessageBox.Show("Hata oluştu: " + sonuc);
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            Ara();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtArama.Text = "";
            ListeyiYenile();
        }

        private void txtArama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Ara();
            }
        }

        private void Ara()
        {
            string aramaMetni = txtArama.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(aramaMetni))
            {
                ListeyiYenile();
                return;
            }

            // Mevcut veriyi al
            DisKlinik.Hasta.Service.SDoktor servis = new DisKlinik.Hasta.Service.SDoktor();
            var tumListe = servis.DoktorListesiGetir();

            if (tumListe == null) return;

            // Filtrele
            var filtrelenmisListe = tumListe.Where(d =>
                (d.Ad != null && d.Ad.ToLower().Contains(aramaMetni)) ||
                (d.Soyad != null && d.Soyad.ToLower().Contains(aramaMetni)) ||
                (d.TcKimlikNo.ToString().Contains(aramaMetni)) ||
                (d.Brans != null && d.Brans.ToLower().Contains(aramaMetni)) ||
                (d.SicilNo != null && d.SicilNo.ToLower().Contains(aramaMetni))
            ).ToList();

            grdDoktorListesi.DataSource = null;
            grdDoktorListesi.DataSource = filtrelenmisListe;
        }
    }
}

