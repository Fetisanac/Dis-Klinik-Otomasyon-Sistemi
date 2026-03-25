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
    public partial class FrmRandevu : Form
    {
        public FrmRandevu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Single-Window Navigation için
        }

        private void FrmRandevu_Load(object sender, EventArgs e)
        {
            ComboBoxlariDoldur();
            ListeyiYenile();
        }

        private void ComboBoxlariDoldur()
        {
            // Hasta listesini doldur
            DisKlinik.Hasta.Service.SHasta hastaServis = new DisKlinik.Hasta.Service.SHasta();
            List<DisKlinik.Hasta.Business.BHasta> hastaListesi = hastaServis.HastaListesiGetir();
            cmbHasta.DataSource = hastaListesi;
            cmbHasta.DisplayMember = "AdSoyad";
            cmbHasta.ValueMember = "TcKimlikNo";

            // Doktor listesini doldur
            DisKlinik.Hasta.Service.SDoktor doktorServis = new DisKlinik.Hasta.Service.SDoktor();
            List<DisKlinik.Hasta.Business.BDoktor> doktorListesi = doktorServis.DoktorListesiGetir();
            cmbDoktor.DataSource = doktorListesi;
            cmbDoktor.DisplayMember = "AdSoyad";
            cmbDoktor.ValueMember = "TcKimlikNo"; // DoktorSicil alanı TcKimlikNo ile eşleşiyor

            // Tedavi listesini doldur
            DisKlinik.Hasta.Service.STedavi tedaviServis = new DisKlinik.Hasta.Service.STedavi();
            List<DisKlinik.Hasta.Business.BTedavi> tedaviListesi = tedaviServis.TedaviListesiGetir();
            cmbTedavi.DataSource = tedaviListesi;
            cmbTedavi.DisplayMember = "TedaviAdi";
            cmbTedavi.ValueMember = "Id";
        }

        private void ListeyiYenile()
        {
            // Servis katmanından örneği oluştur
            DisKlinik.Hasta.Service.SRandevu servis = new DisKlinik.Hasta.Service.SRandevu();

            // Tabloyu önce temizle
            grdRandevuListesi.DataSource = null;

            // Servisten gelen listeyi tabloya bağla
            grdRandevuListesi.DataSource = servis.RandevuListesiGetir();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. Veri Nesnesini Oluştur
            DisKlinik.Hasta.Business.BRandevu yeniRandevu = new DisKlinik.Hasta.Business.BRandevu();

            // Hasta seçimi kontrolü
            if (cmbHasta.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir hasta seçiniz.");
                return;
            }
            yeniRandevu.HastaTc = Convert.ToInt64(cmbHasta.SelectedValue);

            // Doktor seçimi (opsiyonel - boş bırakılabilir)
            if (cmbDoktor.SelectedValue != null)
            {
                yeniRandevu.DoktorSicil = Convert.ToInt64(cmbDoktor.SelectedValue);
            }
            else
            {
                yeniRandevu.DoktorSicil = 0;
            }

            // Tedavi seçimi (opsiyonel - boş bırakılabilir)
            if (cmbTedavi.SelectedValue != null)
            {
                yeniRandevu.TedaviId = Convert.ToInt32(cmbTedavi.SelectedValue);
            }
            else
            {
                yeniRandevu.TedaviId = null;
            }

            // Tarih ve Saat birleştirme
            DateTime randevuTarihi = dtpTarih.Value.Date;
            DateTime saat = dtpSaat.Value;
            randevuTarihi = randevuTarihi.AddHours(saat.Hour);
            randevuTarihi = randevuTarihi.AddMinutes(saat.Minute);
            yeniRandevu.RandevuTarihi = randevuTarihi;

            yeniRandevu.Notlar = txtNotlar.Text;
            yeniRandevu.Durum = chkDurum.Checked;

            // Servise Gönder
            DisKlinik.Hasta.Service.SRandevu servis = new DisKlinik.Hasta.Service.SRandevu();
            string sonuc = servis.RandevuEkle(yeniRandevu);

            if (sonuc != null)
            {
                MessageBox.Show("Hata: " + sonuc);
            }
            else
            {
                MessageBox.Show("Randevu başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Temizlik
                cmbHasta.SelectedIndex = -1;
                cmbDoktor.SelectedIndex = -1;
                cmbTedavi.SelectedIndex = -1;
                txtNotlar.Text = "";
                chkDurum.Checked = true;

                // Listeyi Yenile
                ListeyiYenile();
            }
        }

        private void grdRandevuListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Başlığa tıklarsa işlem yapma
            if (e.RowIndex < 0) return;

            // Seçili satırı al
            DataGridViewRow satir = grdRandevuListesi.Rows[e.RowIndex];

            // ComboBox'ları doldur
            long hastaTc = Convert.ToInt64(satir.Cells["HastaTc"].Value);
            cmbHasta.SelectedValue = hastaTc;

            if (satir.Cells["DoktorSicil"].Value != null && satir.Cells["DoktorSicil"].Value.ToString() != "0")
            {
                long doktorTc = Convert.ToInt64(satir.Cells["DoktorSicil"].Value);
                cmbDoktor.SelectedValue = doktorTc;
            }
            else
            {
                cmbDoktor.SelectedIndex = -1;
            }

            // Tedavi seçimi (opsiyonel)
            if (satir.Cells["TedaviId"].Value != null && satir.Cells["TedaviId"].Value != DBNull.Value)
            {
                int tedaviId = Convert.ToInt32(satir.Cells["TedaviId"].Value);
                cmbTedavi.SelectedValue = tedaviId;
            }
            else
            {
                cmbTedavi.SelectedIndex = -1;
            }

            if (satir.Cells["RandevuTarihi"].Value != null)
            {
                DateTime randevuTarihi = Convert.ToDateTime(satir.Cells["RandevuTarihi"].Value);
                dtpTarih.Value = randevuTarihi.Date;
                dtpSaat.Value = randevuTarihi;
            }

            txtNotlar.Text = satir.Cells["Notlar"].Value != null ? satir.Cells["Notlar"].Value.ToString() : "";
            chkDurum.Checked = satir.Cells["Durum"].Value != null ? Convert.ToBoolean(satir.Cells["Durum"].Value) : true;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu randevuyu silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Seçili satırdan Id'yi al
                if (grdRandevuListesi.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(grdRandevuListesi.SelectedRows[0].Cells["Id"].Value);

                    DisKlinik.Hasta.Service.SRandevu servis = new DisKlinik.Hasta.Service.SRandevu();
                    string sonuc = servis.RandevuSil(id);

                    if (sonuc == null)
                    {
                        MessageBox.Show("Randevu Silindi.");
                        ListeyiYenile();
                        // Kutuları temizle
                        cmbHasta.SelectedIndex = -1;
                        cmbDoktor.SelectedIndex = -1;
                        cmbTedavi.SelectedIndex = -1;
                        txtNotlar.Text = "";
                        chkDurum.Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("Hata: " + sonuc);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz randevuyu seçiniz.");
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // 1. Önce bir Id seçili mi kontrol et
            if (grdRandevuListesi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz randevuyu tablodan seçiniz.");
                return;
            }

            DisKlinik.Hasta.Business.BRandevu guncelRandevu = new DisKlinik.Hasta.Business.BRandevu();

            // Id'yi al
            guncelRandevu.Id = Convert.ToInt32(grdRandevuListesi.SelectedRows[0].Cells["Id"].Value);

            // Hasta seçimi kontrolü
            if (cmbHasta.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir hasta seçiniz.");
                return;
            }
            guncelRandevu.HastaTc = Convert.ToInt64(cmbHasta.SelectedValue);

            // Doktor seçimi (opsiyonel - boş bırakılabilir)
            if (cmbDoktor.SelectedValue != null)
            {
                guncelRandevu.DoktorSicil = Convert.ToInt64(cmbDoktor.SelectedValue);
            }
            else
            {
                guncelRandevu.DoktorSicil = 0;
            }

            // Tedavi seçimi (opsiyonel - boş bırakılabilir)
            if (cmbTedavi.SelectedValue != null)
            {
                guncelRandevu.TedaviId = Convert.ToInt32(cmbTedavi.SelectedValue);
            }
            else
            {
                guncelRandevu.TedaviId = null;
            }

            // Tarih ve Saat birleştirme
            DateTime randevuTarihi = dtpTarih.Value.Date;
            DateTime saat = dtpSaat.Value;
            randevuTarihi = randevuTarihi.AddHours(saat.Hour);
            randevuTarihi = randevuTarihi.AddMinutes(saat.Minute);
            guncelRandevu.RandevuTarihi = randevuTarihi;

            guncelRandevu.Notlar = txtNotlar.Text;
            guncelRandevu.Durum = chkDurum.Checked;

            // Servise Gönder
            DisKlinik.Hasta.Service.SRandevu servis = new DisKlinik.Hasta.Service.SRandevu();
            string sonuc = servis.RandevuGuncelle(guncelRandevu);

            if (sonuc == null)
            {
                MessageBox.Show("Randevu başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DisKlinik.Hasta.Service.SRandevu servis = new DisKlinik.Hasta.Service.SRandevu();
            var tumListe = servis.RandevuListesiGetir();

            if (tumListe == null) return;

            // Filtrele
            var filtrelenmisListe = tumListe.Where(r =>
                (r.HastaAdi != null && r.HastaAdi.ToLower().Contains(aramaMetni)) ||
                (r.DoktorAdi != null && r.DoktorAdi.ToLower().Contains(aramaMetni)) ||
                (r.TedaviAdi != null && r.TedaviAdi.ToLower().Contains(aramaMetni)) ||
                (r.RandevuTarihi.ToString("dd.MM.yyyy HH:mm").Contains(aramaMetni)) ||
                (r.Notlar != null && r.Notlar.ToLower().Contains(aramaMetni))
            ).ToList();

            grdRandevuListesi.DataSource = null;
            grdRandevuListesi.DataSource = filtrelenmisListe;
        }
    }
}

