using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DisKlinik.Hasta.Service;

namespace DisKlinik.Hasta.Forms
{
    public partial class FrmYapayZeka : Form
    {
        public FrmYapayZeka()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Single-Window Navigation için
        }

        /// <summary>
        /// Chat log'una mesaj ekler ve formatlar
        /// </summary>
        private void AppendChatLog(string message, bool isUser)
        {
            // Önek ve renk ayarları
            string prefix;
            Color prefixColor;
            Color textColor = Color.Black;

            if (isUser)
            {
                prefix = "SİZ: ";
                prefixColor = Color.DarkBlue;
            }
            else
            {
                prefix = "ASİSTAN: ";
                prefixColor = Color.DarkGreen;
            }

            // Öneki ekle (renkli)
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionLength = 0;
            rtbChat.SelectionColor = prefixColor;
            rtbChat.AppendText(prefix);

            // Mesaj içeriğini ekle (siyah)
            rtbChat.SelectionColor = textColor;
            rtbChat.AppendText(message);

            // 2 satır boşluk ekle
            rtbChat.AppendText("\n\n");

            // En alta kaydır
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.ScrollToCaret();
        }

        private async void btnGonder_Click(object sender, EventArgs e)
        {
            string mesaj = txtMesaj.Text.Trim();

            if (string.IsNullOrEmpty(mesaj))
            {
                MessageBox.Show("Lütfen bir mesaj giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Butonu devre dışı bırak ve durumu göster
            btnGonder.Enabled = false;
            btnGonder.Text = "...";

            try
            {
                // Kullanıcı mesajını ekle
                AppendChatLog(mesaj, true);

                // Yapay zekaya sor
                string cevap = await SYapayZeka.YapayZekayaSorAsenkron(mesaj);

                // AI cevabını ekle
                AppendChatLog(cevap, false);

                // Mesaj kutusunu temizle
                txtMesaj.Text = "";
                txtMesaj.Focus();
            }
            catch (Exception ex)
            {
                // Hata mesajını ekle
                AppendChatLog($"Hata: {ex.Message}", false);
            }
            finally
            {
                // Butonu tekrar aktif et
                btnGonder.Enabled = true;
                btnGonder.Text = "GÖNDER";
            }
        }

        private void txtMesaj_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl+Enter ile gönder
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                btnGonder_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Konuşma geçmişini temizlemek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // RichTextBox'ı temizle
                rtbChat.Clear();

                // Conversation history'yi temizle
                SYapayZeka.ClearConversation("default");

                MessageBox.Show("Konuşma geçmişi temizlendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
