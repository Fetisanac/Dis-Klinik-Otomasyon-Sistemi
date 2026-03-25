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
    public partial class FrmTedavi : Form
    {
        public FrmTedavi()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Single-Window Navigation için
        }

        private void FrmTedavi_Load(object sender, EventArgs e)
        {
            ListeyiYenile();
        }

        private void ListeyiYenile()
        {
            // Servis katmanından örneği oluştur
            DisKlinik.Hasta.Service.STedavi servis = new DisKlinik.Hasta.Service.STedavi();

            // Tabloyu önce temizle
            grdTedaviListesi.DataSource = null;

            // Servisten gelen listeyi tabloya bağla
            grdTedaviListesi.DataSource = servis.TedaviListesiGetir();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. Veri Nesnesini Oluştur
            DisKlinik.Hasta.Business.BTedavi yeniTedavi = new DisKlinik.Hasta.Business.BTedavi();

            yeniTedavi.TedaviAdi = txtTedaviAdi.Text;
            yeniTedavi.BirimFiyat = numFiyat.Value;

            // Servise Gönder
            DisKlinik.Hasta.Service.STedavi servis = new DisKlinik.Hasta.Service.STedavi();
            string sonuc = servis.TedaviEkle(yeniTedavi);

            if (sonuc != null)
            {
                MessageBox.Show("Hata: " + sonuc);
            }
            else
            {
                MessageBox.Show("Tedavi başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Temizlik
                txtTedaviAdi.Text = "";
                numFiyat.Value = 0;

                // Listeyi Yenile
                ListeyiYenile();
            }
        }

        private void grdTedaviListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Başlığa tıklarsa işlem yapma
            if (e.RowIndex < 0) return;

            // Seçili satırı al
            DataGridViewRow satir = grdTedaviListesi.Rows[e.RowIndex];

            // Kutuları doldur
            txtTedaviAdi.Text = satir.Cells["TedaviAdi"].Value.ToString();
            numFiyat.Value = Convert.ToDecimal(satir.Cells["BirimFiyat"].Value);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu tedaviyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Seçili satırdan Id'yi al
                if (grdTedaviListesi.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(grdTedaviListesi.SelectedRows[0].Cells["Id"].Value);

                    DisKlinik.Hasta.Service.STedavi servis = new DisKlinik.Hasta.Service.STedavi();
                    string sonuc = servis.TedaviSil(id);

                    if (sonuc == null)
                    {
                        MessageBox.Show("Tedavi Silindi.");
                        ListeyiYenile();
                        // Kutuları temizle
                        txtTedaviAdi.Text = "";
                        numFiyat.Value = 0;
                    }
                    else
                    {
                        MessageBox.Show("Hata: " + sonuc);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz tedaviyi seçiniz.");
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // 1. Önce bir Id seçili mi kontrol et
            if (grdTedaviListesi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz tedaviyi tablodan seçiniz.");
                return;
            }

            DisKlinik.Hasta.Business.BTedavi guncelTedavi = new DisKlinik.Hasta.Business.BTedavi();

            // Id'yi al
            guncelTedavi.Id = Convert.ToInt32(grdTedaviListesi.SelectedRows[0].Cells["Id"].Value);

            guncelTedavi.TedaviAdi = txtTedaviAdi.Text;
            guncelTedavi.BirimFiyat = numFiyat.Value;

            // Servise Gönder
            DisKlinik.Hasta.Service.STedavi servis = new DisKlinik.Hasta.Service.STedavi();
            string sonuc = servis.TedaviGuncelle(guncelTedavi);

            if (sonuc == null)
            {
                MessageBox.Show("Tedavi başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DisKlinik.Hasta.Service.STedavi servis = new DisKlinik.Hasta.Service.STedavi();
            var tumListe = servis.TedaviListesiGetir();

            if (tumListe == null) return;

            // Filtrele
            var filtrelenmisListe = tumListe.Where(t =>
                (t.TedaviAdi != null && t.TedaviAdi.ToLower().Contains(aramaMetni)) ||
                (t.BirimFiyat.ToString().Contains(aramaMetni))
            ).ToList();

            grdTedaviListesi.DataSource = null;
            grdTedaviListesi.DataSource = filtrelenmisListe;
        }
    }
}

