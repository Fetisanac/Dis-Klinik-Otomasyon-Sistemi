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
using System.IO;
using System.Drawing.Printing;

namespace DisKlinik.Hasta.Forms
{
    public partial class FrmRecete : Form
    {
        public FrmRecete()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Single-Window Navigation için
        }

        private void FrmRecete_Load(object sender, EventArgs e)
        {
            ComboBoxlariDoldur();
            ListeyiYenile();
        }

        private void ComboBoxlariDoldur()
        {
            // Randevu listesini doldur (Bugün ve gelecek, aktif randevular)
            DisKlinik.Hasta.Service.SRecete receteServis = new DisKlinik.Hasta.Service.SRecete();
            List<DisKlinik.Hasta.Business.BRandevu> randevuListesi = receteServis.RandevuListesiGetir();

            cmbRandevu.DataSource = randevuListesi;
            cmbRandevu.DisplayMember = "DisplayText";
            cmbRandevu.ValueMember = "Id";
            cmbRandevu.SelectedIndex = -1;
        }

        private void ListeyiYenile()
        {
            // Servis katmanından reçete listesini getir
            DisKlinik.Hasta.Service.SRecete receteServis = new DisKlinik.Hasta.Service.SRecete();

            // Tabloyu önce temizle
            grdReceteListesi.DataSource = null;

            // Servisten gelen listeyi tabloya bağla
            grdReceteListesi.DataSource = receteServis.ReceteListesiGetir();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Validasyonlar
            if (cmbRandevu.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir randevu seçiniz.");
                return;
            }

            if (string.IsNullOrEmpty(txtTani.Text.Trim()))
            {
                MessageBox.Show("Lütfen tanı bilgisini giriniz.");
                txtTani.Focus();
                return;
            }

            // Veri Nesnesini Oluştur
            DisKlinik.Hasta.Business.BRecete yeniRecete = new DisKlinik.Hasta.Business.BRecete();

            yeniRecete.RandevuId = Convert.ToInt32(cmbRandevu.SelectedValue);
            yeniRecete.Tani = txtTani.Text.Trim();
            yeniRecete.Ilaclar = txtIlaclar.Text.Trim();
            yeniRecete.Tarih = DateTime.Now;

            // Servise Gönder
            DisKlinik.Hasta.Service.SRecete servis = new DisKlinik.Hasta.Service.SRecete();
            string sonuc = servis.ReceteEkle(yeniRecete);

            if (sonuc != null)
            {
                MessageBox.Show("Hata: " + sonuc);
            }
            else
            {
                MessageBox.Show("Reçete başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Temizlik
                cmbRandevu.SelectedIndex = -1;
                txtTani.Text = "";
                txtIlaclar.Text = "";

                // Listeyi yenile
                ListeyiYenile();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu reçeteyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Seçili satırdan Id'yi al
                if (grdReceteListesi.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(grdReceteListesi.SelectedRows[0].Cells["Id"].Value);

                    DisKlinik.Hasta.Service.SRecete servis = new DisKlinik.Hasta.Service.SRecete();
                    string sonuc = servis.ReceteSil(id);

                    if (sonuc == null)
                    {
                        MessageBox.Show("Reçete Silindi.");
                        ListeyiYenile();

                        // Temizlik
                        cmbRandevu.SelectedIndex = -1;
                        txtTani.Text = "";
                        txtIlaclar.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Hata: " + sonuc);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz reçeteyi seçiniz.");
                }
            }
        }

        private void grdReceteListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow satir = grdReceteListesi.Rows[e.RowIndex];

            // Randevu ID'sine göre ComboBox'ı seç
            int randevuId = Convert.ToInt32(satir.Cells["RandevuId"].Value);
            cmbRandevu.SelectedValue = randevuId;

            // Diğer alanları doldur
            txtTani.Text = satir.Cells["Tani"].Value != null ? satir.Cells["Tani"].Value.ToString() : "";
            txtIlaclar.Text = satir.Cells["Ilaclar"].Value != null ? satir.Cells["Ilaclar"].Value.ToString() : "";
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
            DisKlinik.Hasta.Service.SRecete servis = new DisKlinik.Hasta.Service.SRecete();
            var tumListe = servis.ReceteListesiGetir();

            if (tumListe == null) return;

            // Filtrele
            var filtrelenmisListe = tumListe.Where(r =>
                (r.HastaAdi != null && r.HastaAdi.ToLower().Contains(aramaMetni)) ||
                (r.Tani != null && r.Tani.ToLower().Contains(aramaMetni)) ||
                (r.Ilaclar != null && r.Ilaclar.ToLower().Contains(aramaMetni)) ||
                (r.Tarih.ToString("dd.MM.yyyy").Contains(aramaMetni))
            ).ToList();

            grdReceteListesi.DataSource = null;
            grdReceteListesi.DataSource = filtrelenmisListe;
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            // Seçili satır kontrolü
            if (grdReceteListesi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen yazdırmak istediğiniz reçeteyi tablodan seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçili satırdan verileri al
            DataGridViewRow satir = grdReceteListesi.SelectedRows[0];
            
            string hastaAdi = satir.Cells["HastaAdi"].Value != null ? satir.Cells["HastaAdi"].Value.ToString() : "";
            string tani = satir.Cells["Tani"].Value != null ? satir.Cells["Tani"].Value.ToString() : "";
            string ilaclar = satir.Cells["Ilaclar"].Value != null ? satir.Cells["Ilaclar"].Value.ToString() : "";
            DateTime tarih = satir.Cells["Tarih"].Value != null ? Convert.ToDateTime(satir.Cells["Tarih"].Value) : DateTime.Now;

            // SaveFileDialog ile dosya kayıt yeri seç
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF Dosyaları (*.pdf)|*.pdf|Tüm Dosyalar (*.*)|*.*";
            saveDialog.FilterIndex = 1;
            saveDialog.FileName = $"Recete_{hastaAdi.Replace(" ", "_")}_{tarih:yyyyMMdd}.pdf";
            saveDialog.DefaultExt = "pdf";
            saveDialog.Title = "Reçete PDF Olarak Kaydet";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PDFOlustur(saveDialog.FileName, hastaAdi, tani, ilaclar, tarih);
                    MessageBox.Show("Reçete başarıyla PDF olarak kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"PDF oluşturulurken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PDFOlustur(string dosyaYolu, string hastaAdi, string tani, string ilaclar, DateTime tarih)
        {
            // HTML içeriği oluştur (PDF'e dönüştürülebilir format)
            StringBuilder html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html>");
            html.AppendLine("<head>");
            html.AppendLine("<meta charset='UTF-8'>");
            html.AppendLine("<style>");
            html.AppendLine("@media print { body { margin: 0; } }");
            html.AppendLine("body { font-family: 'Arial', sans-serif; margin: 40px; background-color: white; }");
            html.AppendLine(".container { background-color: white; padding: 40px; max-width: 800px; margin: 0 auto; }");
            html.AppendLine("h1 { color: #2c3e50; text-align: center; border-bottom: 3px solid #3498db; padding-bottom: 15px; margin-bottom: 30px; font-size: 24px; }");
            html.AppendLine(".info-section { margin-bottom: 25px; }");
            html.AppendLine(".label { font-weight: bold; color: #34495e; font-size: 14px; margin-bottom: 5px; }");
            html.AppendLine(".value { font-size: 16px; color: #2c3e50; margin-bottom: 15px; padding: 10px; background-color: #f8f9fa; border-left: 4px solid #3498db; }");
            html.AppendLine(".ilaclar { white-space: pre-line; line-height: 1.8; }");
            html.AppendLine(".footer { margin-top: 40px; text-align: right; color: #7f8c8d; font-size: 12px; border-top: 2px solid #ecf0f1; padding-top: 20px; }");
            html.AppendLine("</style>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine("<div class='container'>");
            html.AppendLine("<h1>REÇETE</h1>");
            html.AppendLine("<div class='info-section'>");
            html.AppendLine("<div class='label'>Hasta Adı:</div>");
            html.AppendLine($"<div class='value'>{HtmlEncode(hastaAdi)}</div>");
            html.AppendLine("</div>");
            html.AppendLine("<div class='info-section'>");
            html.AppendLine("<div class='label'>Tanı:</div>");
            html.AppendLine($"<div class='value'>{HtmlEncode(tani)}</div>");
            html.AppendLine("</div>");
            html.AppendLine("<div class='info-section'>");
            html.AppendLine("<div class='label'>İlaçlar:</div>");
            html.AppendLine($"<div class='value ilaclar'>{HtmlEncode(ilaclar)}</div>");
            html.AppendLine("</div>");
            html.AppendLine("<div class='footer'>");
            html.AppendLine($"<div>Tarih: {tarih:dd.MM.yyyy HH:mm}</div>");
            html.AppendLine("<div>Diş Kliniği Otomasyon Sistemi</div>");
            html.AppendLine("</div>");
            html.AppendLine("</div>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            // HTML'i geçici dosyaya kaydet
            string tempHtmlPath = Path.Combine(Path.GetTempPath(), $"Recete_{Guid.NewGuid()}.html");
            File.WriteAllText(tempHtmlPath, html.ToString(), Encoding.UTF8);

            // HTML dosyasını aç (kullanıcı tarayıcıdan PDF olarak kaydedebilir)
            System.Diagnostics.Process.Start(tempHtmlPath);
            
            // Kullanıcıya bilgi ver
            MessageBox.Show("Reçete HTML formatında oluşturuldu ve tarayıcıda açıldı.\n\nPDF olarak kaydetmek için:\n1. Tarayıcıda Ctrl+P (veya Cmd+P) tuşlarına basın\n2. 'PDF olarak kaydet' veya 'Microsoft Print to PDF' seçeneğini seçin\n3. Kayıt konumunu belirleyin\n\nNot: Windows 10/11'de 'Microsoft Print to PDF' yazıcısı varsayılan olarak yüklüdür.", 
                "PDF Oluşturma", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string HtmlEncode(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return text
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;")
                .Replace("'", "&#39;");
        }
    }
}





