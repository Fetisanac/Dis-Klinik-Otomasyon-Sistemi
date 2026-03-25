using DevExpress.XtraEditors;

namespace DisKlinik.Hasta.Forms
{
    partial class FrmRandevu
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHastaTc = new System.Windows.Forms.Label();
            this.cmbHasta = new System.Windows.Forms.ComboBox();
            this.lblDoktorSicil = new System.Windows.Forms.Label();
            this.cmbDoktor = new System.Windows.Forms.ComboBox();
            this.lblTedavi = new System.Windows.Forms.Label();
            this.cmbTedavi = new System.Windows.Forms.ComboBox();
            this.lblTarih = new System.Windows.Forms.Label();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.lblSaat = new System.Windows.Forms.Label();
            this.dtpSaat = new System.Windows.Forms.DateTimePicker();
            this.lblNotlar = new System.Windows.Forms.Label();
            this.txtNotlar = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.grdRandevuListesi = new System.Windows.Forms.DataGridView();
            this.chkDurum = new System.Windows.Forms.CheckBox();
            this.pnlArama = new System.Windows.Forms.Panel();
            this.txtArama = new DevExpress.XtraEditors.TextEdit();
            this.btnAra = new DevExpress.XtraEditors.SimpleButton();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdRandevuListesi)).BeginInit();
            this.pnlArama.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtArama.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHastaTc
            // 
            this.lblHastaTc.AutoSize = true;
            this.lblHastaTc.Location = new System.Drawing.Point(12, 22);
            this.lblHastaTc.Name = "lblHastaTc";
            this.lblHastaTc.Size = new System.Drawing.Size(41, 14);
            this.lblHastaTc.TabIndex = 0;
            this.lblHastaTc.Text = "Hasta:";
            // 
            // cmbHasta
            // 
            this.cmbHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHasta.FormattingEnabled = true;
            this.cmbHasta.Location = new System.Drawing.Point(97, 19);
            this.cmbHasta.Name = "cmbHasta";
            this.cmbHasta.Size = new System.Drawing.Size(150, 22);
            this.cmbHasta.TabIndex = 1;
            // 
            // lblDoktorSicil
            // 
            this.lblDoktorSicil.AutoSize = true;
            this.lblDoktorSicil.Location = new System.Drawing.Point(12, 57);
            this.lblDoktorSicil.Name = "lblDoktorSicil";
            this.lblDoktorSicil.Size = new System.Drawing.Size(48, 14);
            this.lblDoktorSicil.TabIndex = 2;
            this.lblDoktorSicil.Text = "Doktor:";
            // 
            // cmbDoktor
            // 
            this.cmbDoktor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoktor.FormattingEnabled = true;
            this.cmbDoktor.Location = new System.Drawing.Point(97, 54);
            this.cmbDoktor.Name = "cmbDoktor";
            this.cmbDoktor.Size = new System.Drawing.Size(150, 22);
            this.cmbDoktor.TabIndex = 3;
            // 
            // lblTedavi
            // 
            this.lblTedavi.AutoSize = true;
            this.lblTedavi.Location = new System.Drawing.Point(12, 92);
            this.lblTedavi.Name = "lblTedavi";
            this.lblTedavi.Size = new System.Drawing.Size(92, 14);
            this.lblTedavi.TabIndex = 4;
            this.lblTedavi.Text = "Yapılacak İşlem:";
            // 
            // cmbTedavi
            // 
            this.cmbTedavi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTedavi.FormattingEnabled = true;
            this.cmbTedavi.Location = new System.Drawing.Point(97, 89);
            this.cmbTedavi.Name = "cmbTedavi";
            this.cmbTedavi.Size = new System.Drawing.Size(150, 22);
            this.cmbTedavi.TabIndex = 5;
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.Location = new System.Drawing.Point(12, 127);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(38, 14);
            this.lblTarih.TabIndex = 6;
            this.lblTarih.Text = "Tarih:";
            // 
            // dtpTarih
            // 
            this.dtpTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTarih.Location = new System.Drawing.Point(97, 124);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(150, 22);
            this.dtpTarih.TabIndex = 7;
            // 
            // lblSaat
            // 
            this.lblSaat.AutoSize = true;
            this.lblSaat.Location = new System.Drawing.Point(12, 162);
            this.lblSaat.Name = "lblSaat";
            this.lblSaat.Size = new System.Drawing.Size(35, 14);
            this.lblSaat.TabIndex = 8;
            this.lblSaat.Text = "Saat:";
            // 
            // dtpSaat
            // 
            this.dtpSaat.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSaat.Location = new System.Drawing.Point(97, 159);
            this.dtpSaat.Name = "dtpSaat";
            this.dtpSaat.ShowUpDown = true;
            this.dtpSaat.Size = new System.Drawing.Size(150, 22);
            this.dtpSaat.TabIndex = 9;
            // 
            // lblNotlar
            // 
            this.lblNotlar.AutoSize = true;
            this.lblNotlar.Location = new System.Drawing.Point(12, 197);
            this.lblNotlar.Name = "lblNotlar";
            this.lblNotlar.Size = new System.Drawing.Size(43, 14);
            this.lblNotlar.TabIndex = 8;
            this.lblNotlar.Text = "Notlar:";
            // 
            // txtNotlar
            // 
            this.txtNotlar.Location = new System.Drawing.Point(97, 194);
            this.txtNotlar.Multiline = true;
            this.txtNotlar.Name = "txtNotlar";
            this.txtNotlar.Size = new System.Drawing.Size(150, 80);
            this.txtNotlar.TabIndex = 11;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.Lime;
            this.btnKaydet.Location = new System.Drawing.Point(15, 315);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 10;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Firebrick;
            this.btnSil.Location = new System.Drawing.Point(96, 315);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 13;
            this.btnSil.Text = "SİL";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnGuncelle.Location = new System.Drawing.Point(15, 344);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(156, 23);
            this.btnGuncelle.TabIndex = 14;
            this.btnGuncelle.Text = "GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // pnlArama
            // 
            this.pnlArama.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlArama.Controls.Add(this.btnTemizle);
            this.pnlArama.Controls.Add(this.btnAra);
            this.pnlArama.Controls.Add(this.txtArama);
            this.pnlArama.Location = new System.Drawing.Point(280, 19);
            this.pnlArama.Name = "pnlArama";
            this.pnlArama.Size = new System.Drawing.Size(700, 50);
            this.pnlArama.TabIndex = 16;
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(10, 12);
            this.txtArama.Name = "txtArama";
            this.txtArama.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtArama.Properties.Appearance.Options.UseFont = true;
            this.txtArama.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtArama.Properties.NullValuePrompt = "Hasta adı, Doktor adı veya Tarih ile ara...";
            this.txtArama.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtArama.Size = new System.Drawing.Size(500, 26);
            this.txtArama.TabIndex = 0;
            this.txtArama.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArama_KeyDown);
            // 
            // btnAra
            // 
            this.btnAra.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnAra.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAra.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAra.Appearance.Options.UseBackColor = true;
            this.btnAra.Appearance.Options.UseFont = true;
            this.btnAra.Appearance.Options.UseForeColor = true;
            this.btnAra.Location = new System.Drawing.Point(520, 10);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(80, 30);
            this.btnAra.TabIndex = 1;
            this.btnAra.Text = "ARA";
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnTemizle.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTemizle.Appearance.Options.UseBackColor = true;
            this.btnTemizle.Appearance.Options.UseFont = true;
            this.btnTemizle.Appearance.Options.UseForeColor = true;
            this.btnTemizle.Location = new System.Drawing.Point(610, 10);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(80, 30);
            this.btnTemizle.TabIndex = 2;
            this.btnTemizle.Text = "TEMİZLE";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // grdRandevuListesi
            // 
            this.grdRandevuListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRandevuListesi.Location = new System.Drawing.Point(280, 69);
            this.grdRandevuListesi.Name = "grdRandevuListesi";
            this.grdRandevuListesi.RowTemplate.Height = 24;
            this.grdRandevuListesi.Size = new System.Drawing.Size(700, 400);
            this.grdRandevuListesi.TabIndex = 13;
            this.grdRandevuListesi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRandevuListesi_CellClick);
            // 
            // chkDurum
            // 
            this.chkDurum.AutoSize = true;
            this.chkDurum.Checked = true;
            this.chkDurum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDurum.Location = new System.Drawing.Point(97, 280);
            this.chkDurum.Name = "chkDurum";
            this.chkDurum.Size = new System.Drawing.Size(51, 18);
            this.chkDurum.TabIndex = 15;
            this.chkDurum.Text = "Aktif";
            this.chkDurum.UseVisualStyleBackColor = true;
            // 
            // FrmRandevu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.pnlArama);
            this.Controls.Add(this.chkDurum);
            this.Controls.Add(this.grdRandevuListesi);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtNotlar);
            this.Controls.Add(this.lblNotlar);
            this.Controls.Add(this.dtpSaat);
            this.Controls.Add(this.lblSaat);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.lblTarih);
            this.Controls.Add(this.cmbTedavi);
            this.Controls.Add(this.lblTedavi);
            this.Controls.Add(this.cmbDoktor);
            this.Controls.Add(this.lblDoktorSicil);
            this.Controls.Add(this.cmbHasta);
            this.Controls.Add(this.lblHastaTc);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "FrmRandevu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Randevu İşlemleri";
            this.Load += new System.EventHandler(this.FrmRandevu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdRandevuListesi)).EndInit();
            this.pnlArama.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtArama.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHastaTc;
        private System.Windows.Forms.ComboBox cmbHasta;
        private System.Windows.Forms.Label lblDoktorSicil;
        private System.Windows.Forms.ComboBox cmbDoktor;
        private System.Windows.Forms.Label lblTedavi;
        private System.Windows.Forms.ComboBox cmbTedavi;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label lblSaat;
        private System.Windows.Forms.DateTimePicker dtpSaat;
        private System.Windows.Forms.Label lblNotlar;
        private System.Windows.Forms.TextBox txtNotlar;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.DataGridView grdRandevuListesi;
        private System.Windows.Forms.CheckBox chkDurum;
        private System.Windows.Forms.Panel pnlArama;
        private DevExpress.XtraEditors.TextEdit txtArama;
        private DevExpress.XtraEditors.SimpleButton btnAra;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
    }
}

