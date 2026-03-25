using DevExpress.XtraEditors;

namespace DisKlinik.Hasta.Forms
{
    partial class FrmTedavi
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
            this.lblTedaviAdi = new System.Windows.Forms.Label();
            this.txtTedaviAdi = new System.Windows.Forms.TextBox();
            this.lblFiyat = new System.Windows.Forms.Label();
            this.numFiyat = new System.Windows.Forms.NumericUpDown();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.grdTedaviListesi = new System.Windows.Forms.DataGridView();
            this.pnlArama = new System.Windows.Forms.Panel();
            this.txtArama = new DevExpress.XtraEditors.TextEdit();
            this.btnAra = new DevExpress.XtraEditors.SimpleButton();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.numFiyat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTedaviListesi)).BeginInit();
            this.pnlArama.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtArama.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTedaviAdi
            // 
            this.lblTedaviAdi.AutoSize = true;
            this.lblTedaviAdi.Location = new System.Drawing.Point(12, 22);
            this.lblTedaviAdi.Name = "lblTedaviAdi";
            this.lblTedaviAdi.Size = new System.Drawing.Size(68, 14);
            this.lblTedaviAdi.TabIndex = 0;
            this.lblTedaviAdi.Text = "Tedavi Adı:";
            // 
            // txtTedaviAdi
            // 
            this.txtTedaviAdi.Location = new System.Drawing.Point(97, 19);
            this.txtTedaviAdi.Name = "txtTedaviAdi";
            this.txtTedaviAdi.Size = new System.Drawing.Size(200, 22);
            this.txtTedaviAdi.TabIndex = 1;
            // 
            // lblFiyat
            // 
            this.lblFiyat.AutoSize = true;
            this.lblFiyat.Location = new System.Drawing.Point(12, 57);
            this.lblFiyat.Name = "lblFiyat";
            this.lblFiyat.Size = new System.Drawing.Size(36, 14);
            this.lblFiyat.TabIndex = 2;
            this.lblFiyat.Text = "Fiyat:";
            // 
            // numFiyat
            // 
            this.numFiyat.DecimalPlaces = 2;
            this.numFiyat.Location = new System.Drawing.Point(97, 54);
            this.numFiyat.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numFiyat.Name = "numFiyat";
            this.numFiyat.Size = new System.Drawing.Size(200, 22);
            this.numFiyat.TabIndex = 3;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.Lime;
            this.btnKaydet.Location = new System.Drawing.Point(15, 100);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 4;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Firebrick;
            this.btnSil.Location = new System.Drawing.Point(96, 100);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 5;
            this.btnSil.Text = "SİL";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnGuncelle.Location = new System.Drawing.Point(15, 129);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(156, 23);
            this.btnGuncelle.TabIndex = 6;
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
            this.pnlArama.Location = new System.Drawing.Point(320, 19);
            this.pnlArama.Name = "pnlArama";
            this.pnlArama.Size = new System.Drawing.Size(600, 50);
            this.pnlArama.TabIndex = 8;
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(10, 12);
            this.txtArama.Name = "txtArama";
            this.txtArama.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtArama.Properties.Appearance.Options.UseFont = true;
            this.txtArama.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtArama.Properties.NullValuePrompt = "Tedavi adı veya fiyat ile ara...";
            this.txtArama.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtArama.Size = new System.Drawing.Size(400, 26);
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
            this.btnAra.Location = new System.Drawing.Point(420, 10);
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
            this.btnTemizle.Location = new System.Drawing.Point(510, 10);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(80, 30);
            this.btnTemizle.TabIndex = 2;
            this.btnTemizle.Text = "TEMİZLE";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // grdTedaviListesi
            // 
            this.grdTedaviListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTedaviListesi.Location = new System.Drawing.Point(320, 69);
            this.grdTedaviListesi.Name = "grdTedaviListesi";
            this.grdTedaviListesi.RowTemplate.Height = 24;
            this.grdTedaviListesi.Size = new System.Drawing.Size(600, 400);
            this.grdTedaviListesi.TabIndex = 7;
            this.grdTedaviListesi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTedaviListesi_CellClick);
            // 
            // FrmTedavi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(950, 500);
            this.Controls.Add(this.pnlArama);
            this.Controls.Add(this.grdTedaviListesi);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.numFiyat);
            this.Controls.Add(this.lblFiyat);
            this.Controls.Add(this.txtTedaviAdi);
            this.Controls.Add(this.lblTedaviAdi);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "FrmTedavi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tedavi İşlemleri";
            this.Load += new System.EventHandler(this.FrmTedavi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numFiyat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTedaviListesi)).EndInit();
            this.pnlArama.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtArama.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTedaviAdi;
        private System.Windows.Forms.TextBox txtTedaviAdi;
        private System.Windows.Forms.Label lblFiyat;
        private System.Windows.Forms.NumericUpDown numFiyat;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.DataGridView grdTedaviListesi;
        private System.Windows.Forms.Panel pnlArama;
        private DevExpress.XtraEditors.TextEdit txtArama;
        private DevExpress.XtraEditors.SimpleButton btnAra;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
    }
}





