using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DevExpress.XtraEditors;
using System.IO;

namespace DisKlinik.Hasta.Forms
{
    public partial class FrmYonetici : Form
    {
        private Form aktifOdemeForm = null; // Ödeme formu için

        public FrmYonetici()
        {
            InitializeComponent();
        }

        private List<DisKlinik.Hasta.Business.BLog> tumLoglar;

        private void FrmYonetici_Load(object sender, EventArgs e)
        {
            // ComboBox'ı doldur
            cmbLogFiltre.Items.Add("Tümü");
            cmbLogFiltre.Items.Add("Sistem Girişleri");
            cmbLogFiltre.Items.Add("Veri İşlemleri");
            cmbLogFiltre.SelectedIndex = 0; // Varsayılan: "Tümü"

            LoglariYenile();
            GrafikleriDoldur();
            KasaYenile();
            OdemeFormunuYukle();
        }

        private void OdemeFormunuYukle()
        {
            // Önceki formu temizle
            if (aktifOdemeForm != null)
            {
                aktifOdemeForm.Hide();
                aktifOdemeForm.Dispose();
            }

            // İçerik panelini temizle
            pnlOdemeIcerik.Controls.Clear();

            // FrmOdeme formunu oluştur
            FrmOdeme frmOdeme = new FrmOdeme();
            frmOdeme.TopLevel = false;
            frmOdeme.FormBorderStyle = FormBorderStyle.None;
            frmOdeme.Dock = DockStyle.Fill;
            frmOdeme.Visible = true;

            // İçerik paneline ekle
            pnlOdemeIcerik.Controls.Add(frmOdeme);

            // Aktif formu kaydet
            aktifOdemeForm = frmOdeme;
        }

        private void LoglariYenile()
        {
            // Servis katmanından log listesini getir
            DisKlinik.Hasta.Service.SLog logServis = new DisKlinik.Hasta.Service.SLog();

            // Tüm logları al
            tumLoglar = logServis.LogListesiGetir();

            // Filtreleme uygula
            Filtrele();
        }

        private void Filtrele()
        {
            if (tumLoglar == null) return;

            List<DisKlinik.Hasta.Business.BLog> filtrelenmisListe = new List<DisKlinik.Hasta.Business.BLog>();

            if (cmbLogFiltre.SelectedItem == null)
            {
                filtrelenmisListe = tumLoglar;
            }
            else
            {
                string secilenFiltre = cmbLogFiltre.SelectedItem.ToString();

                if (secilenFiltre == "Tümü")
                {
                    filtrelenmisListe = tumLoglar;
                }
                else if (secilenFiltre == "Sistem Girişleri")
                {
                    filtrelenmisListe = tumLoglar.Where(x => x.IslemTuru == "Giriş").ToList();
                }
                else if (secilenFiltre == "Veri İşlemleri")
                {
                    filtrelenmisListe = tumLoglar.Where(x => x.IslemTuru != "Giriş").ToList();
                }
            }

            // Tabloyu önce temizle
            grdLoglar.DataSource = null;

            // Filtrelenmiş listeyi tabloya bağla
            grdLoglar.DataSource = filtrelenmisListe;
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            LoglariYenile();
        }

        private void cmbLogFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tüm log kayıtlarını silmek istediğinize emin misiniz? Bu işlem geri alınamaz!", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DisKlinik.Hasta.Service.SLog logServis = new DisKlinik.Hasta.Service.SLog();
                string sonuc = logServis.TumLoglariTemizle();

                if (sonuc == null)
                {
                    MessageBox.Show("Tüm log kayıtları başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoglariYenile();
                }
                else
                {
                    MessageBox.Show("Hata: " + sonuc, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GrafikleriDoldur()
        {
            // Tedavi grafiğini doldur
            DisKlinik.Hasta.Service.SIstatistik istatistikServis = new DisKlinik.Hasta.Service.SIstatistik();
            List<DisKlinik.Hasta.Business.Bİstatistik> tedaviListesi = istatistikServis.EnCokYapilanTedaviler();

            chartTedaviler.Series["Tedaviler"].Points.Clear();
            foreach (var item in tedaviListesi)
            {
                chartTedaviler.Series["Tedaviler"].Points.AddXY(item.Etiket, item.Deger);
            }

            // Kazanç grafiğini doldur
            List<DisKlinik.Hasta.Business.Bİstatistik> kazancListesi = istatistikServis.GunlukKazancGrafigi();

            chartKazanc.Series["Kazanç"].Points.Clear();
            foreach (var item in kazancListesi)
            {
                chartKazanc.Series["Kazanç"].Points.AddXY(item.Etiket, item.Deger);
            }
        }

        private void btnIstatistikYenile_Click(object sender, EventArgs e)
        {
            GrafikleriDoldur();
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            // Ödeme sekmesine geç
            tabControl1.SelectedTab = tabOdeme;
            // Kasa verilerini yenile
            KasaYenile();
        }

        // ========== KASA & MUHASEBE ==========

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

        private void btnKasaRapor_Click(object sender, EventArgs e)
        {
            // Veri kontrolü
            if (grdTumIslemler.Rows.Count == 0)
            {
                XtraMessageBox.Show("Rapor için görüntülenecek veri bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SaveFileDialog ile dosya kayıt yeri seç
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF Dosyaları (*.pdf)|*.pdf|Tüm Dosyalar (*.*)|*.*";
            saveDialog.FilterIndex = 1;
            saveDialog.FileName = "KasaRaporu.pdf";
            saveDialog.DefaultExt = "pdf";
            saveDialog.Title = "Kasa Raporunu PDF Olarak Kaydet";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataGridViewToPDF(grdTumIslemler, saveDialog.FileName);
                    
                    // Başarı mesajı ve dosyayı açma sorusu
                    DialogResult result = XtraMessageBox.Show(
                        "Kasa raporu başarıyla PDF olarak kaydedildi.\n\nDosyayı açmak ister misiniz?",
                        "Başarılı",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"PDF oluşturulurken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridViewToPDF(DataGridView dgv, string dosyaYolu)
        {
            // HTML içeriği oluştur
            StringBuilder html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html>");
            html.AppendLine("<head>");
            html.AppendLine("<meta charset='UTF-8'>");
            html.AppendLine("<style>");
            html.AppendLine("@media print { body { margin: 0; } @page { size: A4 landscape; } }");
            html.AppendLine("body { font-family: 'Arial', sans-serif; margin: 20px; background-color: white; }");
            html.AppendLine(".container { background-color: white; padding: 20px; max-width: 100%; }");
            html.AppendLine("h1 { color: #2c3e50; text-align: center; border-bottom: 3px solid #3498db; padding-bottom: 15px; margin-bottom: 30px; font-size: 24px; }");
            html.AppendLine(".info { margin-bottom: 20px; padding: 10px; background-color: #f8f9fa; border-left: 4px solid #3498db; }");
            html.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 20px; font-size: 11px; }");
            html.AppendLine("th { background-color: #3498db; color: white; padding: 10px 8px; text-align: left; font-weight: bold; border: 1px solid #2980b9; }");
            html.AppendLine("td { padding: 8px; border: 1px solid #ddd; }");
            html.AppendLine("tr:nth-child(even) { background-color: #f2f2f2; }");
            html.AppendLine(".footer { margin-top: 30px; text-align: right; color: #7f8c8d; font-size: 11px; border-top: 2px solid #ecf0f1; padding-top: 15px; }");
            html.AppendLine("</style>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine("<div class='container'>");
            html.AppendLine("<h1>KASA RAPORU</h1>");
            
            // Özet bilgileri ekle
            html.AppendLine("<div class='info'>");
            html.AppendLine($"<strong>Toplam Ciro:</strong> {HtmlEncode(lblToplamCiro.Text)}<br>");
            html.AppendLine($"<strong>Toplam Alacak:</strong> {HtmlEncode(lblToplamAlacak.Text)}");
            html.AppendLine("</div>");

            // Tablo başlangıcı
            html.AppendLine("<table>");
            html.AppendLine("<thead>");
            html.AppendLine("<tr>");

            // Sütun başlıklarını ekle
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    html.AppendLine($"<th>{HtmlEncode(column.HeaderText)}</th>");
                }
            }
            html.AppendLine("</tr>");
            html.AppendLine("</thead>");
            html.AppendLine("<tbody>");

            // Satırları ekle
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    html.AppendLine("<tr>");
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (column.Visible)
                        {
                            object cellValue = row.Cells[column.Index].Value;
                            string cellText = cellValue != null ? cellValue.ToString() : "";
                            html.AppendLine($"<td>{HtmlEncode(cellText)}</td>");
                        }
                    }
                    html.AppendLine("</tr>");
                }
            }

            html.AppendLine("</tbody>");
            html.AppendLine("</table>");

            // Footer
            html.AppendLine("<div class='footer'>");
            html.AppendLine($"<div>Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm}</div>");
            html.AppendLine("<div>Diş Kliniği Otomasyon Sistemi - Yönetici Raporu</div>");
            html.AppendLine("</div>");

            html.AppendLine("</div>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            // HTML'i geçici dosyaya kaydet (PDF'e dönüştürülebilir)
            string tempHtmlPath = Path.Combine(Path.GetTempPath(), $"KasaRaporu_{Guid.NewGuid()}.html");
            File.WriteAllText(tempHtmlPath, html.ToString(), Encoding.UTF8);
            
            // HTML dosyasını aç (kullanıcı tarayıcıdan PDF olarak kaydedebilir)
            System.Diagnostics.Process.Start(tempHtmlPath);
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
