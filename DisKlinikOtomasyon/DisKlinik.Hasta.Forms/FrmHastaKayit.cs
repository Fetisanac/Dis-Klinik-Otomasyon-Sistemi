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
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Single-Window Navigation için
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. Veri Nesnesini Oluştur
            DisKlinik.Hasta.Business.BHasta yeniHasta = new DisKlinik.Hasta.Business.BHasta();


            yeniHasta.Ad = txtAd.Text;
            yeniHasta.Soyad = txtSoyad.Text;
            yeniHasta.Telefon = txtTelefon.Text;
            yeniHasta.Adres = txtAdres.Text;
            yeniHasta.DogumTarihi = dtpDogumTarihi.Value;
            // --------------------------------------------------------

            // TC Kimlik Çevirimi
            if (long.TryParse(txtTcKimlik.Text, out long tcNo))
            {
                yeniHasta.TcKimlikNo = tcNo;
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir TC giriniz.");
                return;
            }

            // Servise Gönder
            DisKlinik.Hasta.Service.SHasta servis = new DisKlinik.Hasta.Service.SHasta();
            string sonuc = servis.HastaEkle(yeniHasta);

            if (sonuc != null)
            {
                MessageBox.Show("Hata: " + sonuc);
            }
            else
            {
                MessageBox.Show("Hasta başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Temizlik
                txtAd.Text = ""; txtSoyad.Text = ""; txtTcKimlik.Text = "";
                txtTelefon.Text = ""; txtAdres.Text = ""; 

                // Listeyi Yenile
                ListeyiYenile();
            }
        }
        private void ListeyiYenile()
        {
            // Servis katmanından örneği oluştur
            DisKlinik.Hasta.Service.SHasta servis = new DisKlinik.Hasta.Service.SHasta();

            // Tabloyu önce temizle
            grdHastaListesi.DataSource = null;

            // Servisten gelen listeyi tabloya bağla
            grdHastaListesi.DataSource = servis.HastaListesiGetir();
        }

        private void FrmHastaKayit_Load(object sender, EventArgs e)
        {
            ListeyiYenile();

        }

       
            private void grdHastaListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Başlığa tıklarsa işlem yapma
            if (e.RowIndex < 0) return;

            // Seçili satırı al
            DataGridViewRow satir = grdHastaListesi.Rows[e.RowIndex];

            // Kutuları doldur
            txtTcKimlik.Text = satir.Cells["TcKimlikNo"].Value.ToString();
            txtAd.Text = satir.Cells["Ad"].Value.ToString();
            txtSoyad.Text = satir.Cells["Soyad"].Value.ToString();
            txtTelefon.Text = satir.Cells["Telefon"].Value != null ? satir.Cells["Telefon"].Value.ToString() : "";
            txtAdres.Text = satir.Cells["Adres"].Value != null ? satir.Cells["Adres"].Value.ToString() : "";

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
                    DisKlinik.Hasta.Service.SHasta servis = new DisKlinik.Hasta.Service.SHasta();
                    string sonuc = servis.HastaSil(tcNo);

                    if (sonuc == null)
                    {
                        MessageBox.Show("Kayıt Silindi.");
                        ListeyiYenile(); // Tabloyu tazele
                                         // Kutuları temizleyebilirsin
                        txtTcKimlik.Text = ""; txtAd.Text = ""; txtSoyad.Text = "";
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

            
            DisKlinik.Hasta.Business.BHasta guncelHasta = new DisKlinik.Hasta.Business.BHasta();

            
            guncelHasta.Ad = txtAd.Text;
            guncelHasta.Soyad = txtSoyad.Text;
            guncelHasta.Telefon = txtTelefon.Text;
            guncelHasta.Adres = txtAdres.Text;
            guncelHasta.DogumTarihi = dtpDogumTarihi.Value;
            // -----------------------------------------------------------

            // TC Kimlik (Değişmez kimlik bilgimiz)
            if (long.TryParse(txtTcKimlik.Text, out long tcNo))
            {
                guncelHasta.TcKimlikNo = tcNo;
            }
            else
            {
                MessageBox.Show("Geçersiz TC Kimlik No.");
                return;
            }

            // 3. Servise Gönder
            DisKlinik.Hasta.Service.SHasta servis = new DisKlinik.Hasta.Service.SHasta();
            string sonuc = servis.HastaGuncelle(guncelHasta);

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
            DisKlinik.Hasta.Service.SHasta servis = new DisKlinik.Hasta.Service.SHasta();
            var tumListe = servis.HastaListesiGetir();

            if (tumListe == null) return;

            // Filtrele
            var filtrelenmisListe = tumListe.Where(h =>
                (h.Ad != null && h.Ad.ToLower().Contains(aramaMetni)) ||
                (h.Soyad != null && h.Soyad.ToLower().Contains(aramaMetni)) ||
                (h.TcKimlikNo.ToString().Contains(aramaMetni)) ||
                (h.Telefon != null && h.Telefon.Contains(aramaMetni))
            ).ToList();

            grdHastaListesi.DataSource = null;
            grdHastaListesi.DataSource = filtrelenmisListe;
        }
    }
}

