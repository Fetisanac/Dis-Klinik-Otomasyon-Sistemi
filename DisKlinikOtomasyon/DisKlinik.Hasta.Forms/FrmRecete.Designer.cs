using DevExpress.XtraEditors;

namespace DisKlinik.Hasta.Forms
{
    partial class FrmRecete
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
            this.lblRandevu = new System.Windows.Forms.Label();
            this.cmbRandevu = new System.Windows.Forms.ComboBox();
            this.lblTani = new System.Windows.Forms.Label();
            this.txtTani = new System.Windows.Forms.TextBox();
            this.lblIlaclar = new System.Windows.Forms.Label();
            this.txtIlaclar = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnYazdir = new DevExpress.XtraEditors.SimpleButton();
            this.grdReceteListesi = new System.Windows.Forms.DataGridView();
            this.pnlArama = new System.Windows.Forms.Panel();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.btnAra = new DevExpress.XtraEditors.SimpleButton();
            this.txtArama = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReceteListesi)).BeginInit();
            this.pnlArama.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtArama.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRandevu
            // 
            this.lblRandevu.AutoSize = true;
            this.lblRandevu.Location = new System.Drawing.Point(12, 22);
            this.lblRandevu.Name = "lblRandevu";
            this.lblRandevu.Size = new System.Drawing.Size(58, 14);
            this.lblRandevu.TabIndex = 0;
            this.lblRandevu.Text = "Randevu:";
            // 
            // cmbRandevu
            // 
            this.cmbRandevu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRandevu.FormattingEnabled = true;
            this.cmbRandevu.Location = new System.Drawing.Point(97, 19);
            this.cmbRandevu.Name = "cmbRandevu";
            this.cmbRandevu.Size = new System.Drawing.Size(350, 22);
            this.cmbRandevu.TabIndex = 1;
            // 
            // lblTani
            // 
            this.lblTani.AutoSize = true;
            this.lblTani.Location = new System.Drawing.Point(12, 57);
            this.lblTani.Name = "lblTani";
            this.lblTani.Size = new System.Drawing.Size(34, 14);
            this.lblTani.TabIndex = 2;
            this.lblTani.Text = "Tanı:";
            // 
            // txtTani
            // 
            this.txtTani.Location = new System.Drawing.Point(97, 54);
            this.txtTani.Name = "txtTani";
            this.txtTani.Size = new System.Drawing.Size(350, 22);
            this.txtTani.TabIndex = 3;
            // 
            // lblIlaclar
            // 
            this.lblIlaclar.AutoSize = true;
            this.lblIlaclar.Location = new System.Drawing.Point(12, 92);
            this.lblIlaclar.Name = "lblIlaclar";
            this.lblIlaclar.Size = new System.Drawing.Size(41, 14);
            this.lblIlaclar.TabIndex = 4;
            this.lblIlaclar.Text = "İlaçlar:";
            // 
            // txtIlaclar
            // 
            this.txtIlaclar.Location = new System.Drawing.Point(97, 89);
            this.txtIlaclar.Multiline = true;
            this.txtIlaclar.Name = "txtIlaclar";
            this.txtIlaclar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIlaclar.Size = new System.Drawing.Size(350, 150);
            this.txtIlaclar.TabIndex = 5;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.Lime;
            this.btnKaydet.Location = new System.Drawing.Point(97, 255);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(120, 30);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Firebrick;
            this.btnSil.Location = new System.Drawing.Point(327, 255);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(120, 30);
            this.btnSil.TabIndex = 7;
            this.btnSil.Text = "SİL";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnYazdir
            // 
            this.btnYazdir.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btnYazdir.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYazdir.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYazdir.Appearance.Options.UseBackColor = true;
            this.btnYazdir.Appearance.Options.UseFont = true;
            this.btnYazdir.Appearance.Options.UseForeColor = true;
            this.btnYazdir.Location = new System.Drawing.Point(97, 295);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(350, 35);
            this.btnYazdir.TabIndex = 10;
            this.btnYazdir.Text = "REÇETE YAZDIR";
            this.btnYazdir.Click += new System.EventHandler(this.btnYazdir_Click);
            // 
            // grdReceteListesi
            // 
            this.grdReceteListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdReceteListesi.Location = new System.Drawing.Point(480, 69);
            this.grdReceteListesi.Name = "grdReceteListesi";
            this.grdReceteListesi.RowTemplate.Height = 24;
            this.grdReceteListesi.Size = new System.Drawing.Size(500, 400);
            this.grdReceteListesi.TabIndex = 8;
            this.grdReceteListesi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdReceteListesi_CellClick);
            // 
            // pnlArama
            // 
            this.pnlArama.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlArama.Controls.Add(this.btnTemizle);
            this.pnlArama.Controls.Add(this.btnAra);
            this.pnlArama.Controls.Add(this.txtArama);
            this.pnlArama.Location = new System.Drawing.Point(480, 19);
            this.pnlArama.Name = "pnlArama";
            this.pnlArama.Size = new System.Drawing.Size(500, 50);
            this.pnlArama.TabIndex = 9;
            // 
            // btnTemizle
            // 
            this.btnTemizle.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnTemizle.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTemizle.Appearance.Options.UseBackColor = true;
            this.btnTemizle.Appearance.Options.UseFont = true;
            this.btnTemizle.Appearance.Options.UseForeColor = true;
            this.btnTemizle.Location = new System.Drawing.Point(420, 10);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(70, 30);
            this.btnTemizle.TabIndex = 2;
            this.btnTemizle.Text = "TEMİZLE";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnAra
            // 
            this.btnAra.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnAra.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAra.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAra.Appearance.Options.UseBackColor = true;
            this.btnAra.Appearance.Options.UseFont = true;
            this.btnAra.Appearance.Options.UseForeColor = true;
            this.btnAra.Location = new System.Drawing.Point(340, 10);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(70, 30);
            this.btnAra.TabIndex = 1;
            this.btnAra.Text = "ARA";
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(10, 12);
            this.txtArama.Name = "txtArama";
            this.txtArama.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtArama.Properties.Appearance.Options.UseFont = true;
            this.txtArama.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtArama.Properties.NullValuePrompt = "Hasta adı, Tanı veya İlaç ile ara...";
            this.txtArama.Size = new System.Drawing.Size(320, 22);
            this.txtArama.TabIndex = 0;
            this.txtArama.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArama_KeyDown);
            // 
            // FrmRecete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.pnlArama);
            this.Controls.Add(this.grdReceteListesi);
            this.Controls.Add(this.btnYazdir);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtIlaclar);
            this.Controls.Add(this.lblIlaclar);
            this.Controls.Add(this.txtTani);
            this.Controls.Add(this.lblTani);
            this.Controls.Add(this.cmbRandevu);
            this.Controls.Add(this.lblRandevu);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "FrmRecete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reçete Yazma";
            this.Load += new System.EventHandler(this.FrmRecete_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdReceteListesi)).EndInit();
            this.pnlArama.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtArama.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRandevu;
        private System.Windows.Forms.ComboBox cmbRandevu;
        private System.Windows.Forms.Label lblTani;
        private System.Windows.Forms.TextBox txtTani;
        private System.Windows.Forms.Label lblIlaclar;
        private System.Windows.Forms.TextBox txtIlaclar;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnSil;
        private DevExpress.XtraEditors.SimpleButton btnYazdir;
        private System.Windows.Forms.DataGridView grdReceteListesi;
        private System.Windows.Forms.Panel pnlArama;
        private DevExpress.XtraEditors.TextEdit txtArama;
        private DevExpress.XtraEditors.SimpleButton btnAra;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
    }
}





