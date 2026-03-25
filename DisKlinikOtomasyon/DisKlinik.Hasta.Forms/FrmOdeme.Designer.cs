namespace DisKlinik.Hasta.Forms
{
    partial class FrmOdeme
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBorc = new System.Windows.Forms.TabPage();
            this.btnBorcKaydet = new System.Windows.Forms.Button();
            this.dtpTarih_Borc = new System.Windows.Forms.DateTimePicker();
            this.lblTarih_Borc = new System.Windows.Forms.Label();
            this.numTutar_Borc = new System.Windows.Forms.NumericUpDown();
            this.lblTutar_Borc = new System.Windows.Forms.Label();
            this.cmbTedavi = new System.Windows.Forms.ComboBox();
            this.lblTedavi = new System.Windows.Forms.Label();
            this.cmbHasta_Borc = new System.Windows.Forms.ComboBox();
            this.lblHasta_Borc = new System.Windows.Forms.Label();
            this.tabOdeme = new System.Windows.Forms.TabPage();
            this.btnOdemeKaydet = new System.Windows.Forms.Button();
            this.dtpTarih_Odeme = new System.Windows.Forms.DateTimePicker();
            this.lblTarih_Odeme = new System.Windows.Forms.Label();
            this.numOdemeTutari = new System.Windows.Forms.NumericUpDown();
            this.lblOdemeTutari = new System.Windows.Forms.Label();
            this.lblGuncelBakiye = new System.Windows.Forms.Label();
            this.cmbHasta_Odeme = new System.Windows.Forms.ComboBox();
            this.lblHasta_Odeme = new System.Windows.Forms.Label();
            this.tabKasa = new System.Windows.Forms.TabPage();
            this.btnKasaYenile = new System.Windows.Forms.Button();
            this.grdTumIslemler = new System.Windows.Forms.DataGridView();
            this.lblToplamAlacak = new System.Windows.Forms.Label();
            this.lblToplamCiro = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabBorc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTutar_Borc)).BeginInit();
            this.tabOdeme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOdemeTutari)).BeginInit();
            this.tabKasa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTumIslemler)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBorc);
            this.tabControl1.Controls.Add(this.tabOdeme);
            this.tabControl1.Controls.Add(this.tabKasa);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1050, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // tabBorc
            // 
            this.tabBorc.Controls.Add(this.btnBorcKaydet);
            this.tabBorc.Controls.Add(this.dtpTarih_Borc);
            this.tabBorc.Controls.Add(this.lblTarih_Borc);
            this.tabBorc.Controls.Add(this.numTutar_Borc);
            this.tabBorc.Controls.Add(this.lblTutar_Borc);
            this.tabBorc.Controls.Add(this.cmbTedavi);
            this.tabBorc.Controls.Add(this.lblTedavi);
            this.tabBorc.Controls.Add(this.cmbHasta_Borc);
            this.tabBorc.Controls.Add(this.lblHasta_Borc);
            this.tabBorc.Location = new System.Drawing.Point(4, 23);
            this.tabBorc.Name = "tabBorc";
            this.tabBorc.Padding = new System.Windows.Forms.Padding(3);
            this.tabBorc.Size = new System.Drawing.Size(1042, 473);
            this.tabBorc.TabIndex = 0;
            this.tabBorc.Text = "Tedavi & Borç Ekle";
            this.tabBorc.UseVisualStyleBackColor = true;
            // 
            // btnBorcKaydet
            // 
            this.btnBorcKaydet.BackColor = System.Drawing.Color.Lime;
            this.btnBorcKaydet.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBorcKaydet.Location = new System.Drawing.Point(100, 190);
            this.btnBorcKaydet.Name = "btnBorcKaydet";
            this.btnBorcKaydet.Size = new System.Drawing.Size(250, 35);
            this.btnBorcKaydet.TabIndex = 8;
            this.btnBorcKaydet.Text = "BORÇ KAYDET";
            this.btnBorcKaydet.UseVisualStyleBackColor = false;
            this.btnBorcKaydet.Click += new System.EventHandler(this.btnBorcKaydet_Click);
            // 
            // dtpTarih_Borc
            // 
            this.dtpTarih_Borc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTarih_Borc.Location = new System.Drawing.Point(100, 147);
            this.dtpTarih_Borc.Name = "dtpTarih_Borc";
            this.dtpTarih_Borc.Size = new System.Drawing.Size(250, 22);
            this.dtpTarih_Borc.TabIndex = 7;
            // 
            // lblTarih_Borc
            // 
            this.lblTarih_Borc.AutoSize = true;
            this.lblTarih_Borc.Location = new System.Drawing.Point(20, 150);
            this.lblTarih_Borc.Name = "lblTarih_Borc";
            this.lblTarih_Borc.Size = new System.Drawing.Size(38, 14);
            this.lblTarih_Borc.TabIndex = 6;
            this.lblTarih_Borc.Text = "Tarih:";
            // 
            // numTutar_Borc
            // 
            this.numTutar_Borc.DecimalPlaces = 2;
            this.numTutar_Borc.Location = new System.Drawing.Point(100, 107);
            this.numTutar_Borc.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numTutar_Borc.Name = "numTutar_Borc";
            this.numTutar_Borc.Size = new System.Drawing.Size(250, 22);
            this.numTutar_Borc.TabIndex = 5;
            // 
            // lblTutar_Borc
            // 
            this.lblTutar_Borc.AutoSize = true;
            this.lblTutar_Borc.Location = new System.Drawing.Point(20, 110);
            this.lblTutar_Borc.Name = "lblTutar_Borc";
            this.lblTutar_Borc.Size = new System.Drawing.Size(41, 14);
            this.lblTutar_Borc.TabIndex = 4;
            this.lblTutar_Borc.Text = "Tutar:";
            // 
            // cmbTedavi
            // 
            this.cmbTedavi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTedavi.FormattingEnabled = true;
            this.cmbTedavi.Location = new System.Drawing.Point(100, 67);
            this.cmbTedavi.Name = "cmbTedavi";
            this.cmbTedavi.Size = new System.Drawing.Size(250, 22);
            this.cmbTedavi.TabIndex = 3;
            this.cmbTedavi.SelectedIndexChanged += new System.EventHandler(this.cmbTedavi_SelectedIndexChanged);
            // 
            // lblTedavi
            // 
            this.lblTedavi.AutoSize = true;
            this.lblTedavi.Location = new System.Drawing.Point(20, 70);
            this.lblTedavi.Name = "lblTedavi";
            this.lblTedavi.Size = new System.Drawing.Size(47, 14);
            this.lblTedavi.TabIndex = 2;
            this.lblTedavi.Text = "Tedavi:";
            // 
            // cmbHasta_Borc
            // 
            this.cmbHasta_Borc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHasta_Borc.FormattingEnabled = true;
            this.cmbHasta_Borc.Location = new System.Drawing.Point(100, 27);
            this.cmbHasta_Borc.Name = "cmbHasta_Borc";
            this.cmbHasta_Borc.Size = new System.Drawing.Size(250, 22);
            this.cmbHasta_Borc.TabIndex = 1;
            // 
            // lblHasta_Borc
            // 
            this.lblHasta_Borc.AutoSize = true;
            this.lblHasta_Borc.Location = new System.Drawing.Point(20, 30);
            this.lblHasta_Borc.Name = "lblHasta_Borc";
            this.lblHasta_Borc.Size = new System.Drawing.Size(41, 14);
            this.lblHasta_Borc.TabIndex = 0;
            this.lblHasta_Borc.Text = "Hasta:";
            // 
            // tabOdeme
            // 
            this.tabOdeme.Controls.Add(this.btnOdemeKaydet);
            this.tabOdeme.Controls.Add(this.dtpTarih_Odeme);
            this.tabOdeme.Controls.Add(this.lblTarih_Odeme);
            this.tabOdeme.Controls.Add(this.numOdemeTutari);
            this.tabOdeme.Controls.Add(this.lblOdemeTutari);
            this.tabOdeme.Controls.Add(this.lblGuncelBakiye);
            this.tabOdeme.Controls.Add(this.cmbHasta_Odeme);
            this.tabOdeme.Controls.Add(this.lblHasta_Odeme);
            this.tabOdeme.Location = new System.Drawing.Point(4, 23);
            this.tabOdeme.Name = "tabOdeme";
            this.tabOdeme.Padding = new System.Windows.Forms.Padding(3);
            this.tabOdeme.Size = new System.Drawing.Size(1042, 473);
            this.tabOdeme.TabIndex = 1;
            this.tabOdeme.Text = "Ödeme Al";
            this.tabOdeme.UseVisualStyleBackColor = true;
            // 
            // btnOdemeKaydet
            // 
            this.btnOdemeKaydet.BackColor = System.Drawing.Color.Lime;
            this.btnOdemeKaydet.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOdemeKaydet.Location = new System.Drawing.Point(100, 190);
            this.btnOdemeKaydet.Name = "btnOdemeKaydet";
            this.btnOdemeKaydet.Size = new System.Drawing.Size(250, 35);
            this.btnOdemeKaydet.TabIndex = 7;
            this.btnOdemeKaydet.Text = "ÖDEME KAYDET";
            this.btnOdemeKaydet.UseVisualStyleBackColor = false;
            this.btnOdemeKaydet.Click += new System.EventHandler(this.btnOdemeKaydet_Click);
            // 
            // dtpTarih_Odeme
            // 
            this.dtpTarih_Odeme.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTarih_Odeme.Location = new System.Drawing.Point(100, 147);
            this.dtpTarih_Odeme.Name = "dtpTarih_Odeme";
            this.dtpTarih_Odeme.Size = new System.Drawing.Size(250, 22);
            this.dtpTarih_Odeme.TabIndex = 6;
            // 
            // lblTarih_Odeme
            // 
            this.lblTarih_Odeme.AutoSize = true;
            this.lblTarih_Odeme.Location = new System.Drawing.Point(20, 150);
            this.lblTarih_Odeme.Name = "lblTarih_Odeme";
            this.lblTarih_Odeme.Size = new System.Drawing.Size(38, 14);
            this.lblTarih_Odeme.TabIndex = 5;
            this.lblTarih_Odeme.Text = "Tarih:";
            // 
            // numOdemeTutari
            // 
            this.numOdemeTutari.DecimalPlaces = 2;
            this.numOdemeTutari.Location = new System.Drawing.Point(100, 107);
            this.numOdemeTutari.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numOdemeTutari.Name = "numOdemeTutari";
            this.numOdemeTutari.Size = new System.Drawing.Size(250, 22);
            this.numOdemeTutari.TabIndex = 4;
            // 
            // lblOdemeTutari
            // 
            this.lblOdemeTutari.AutoSize = true;
            this.lblOdemeTutari.Location = new System.Drawing.Point(20, 110);
            this.lblOdemeTutari.Name = "lblOdemeTutari";
            this.lblOdemeTutari.Size = new System.Drawing.Size(87, 14);
            this.lblOdemeTutari.TabIndex = 3;
            this.lblOdemeTutari.Text = "Ödeme Tutarı:";
            // 
            // lblGuncelBakiye
            // 
            this.lblGuncelBakiye.AutoSize = true;
            this.lblGuncelBakiye.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGuncelBakiye.ForeColor = System.Drawing.Color.DarkRed;
            this.lblGuncelBakiye.Location = new System.Drawing.Point(20, 70);
            this.lblGuncelBakiye.Name = "lblGuncelBakiye";
            this.lblGuncelBakiye.Size = new System.Drawing.Size(142, 19);
            this.lblGuncelBakiye.TabIndex = 2;
            this.lblGuncelBakiye.Text = "Kalan Borç: 0 TL";
            // 
            // cmbHasta_Odeme
            // 
            this.cmbHasta_Odeme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHasta_Odeme.FormattingEnabled = true;
            this.cmbHasta_Odeme.Location = new System.Drawing.Point(100, 27);
            this.cmbHasta_Odeme.Name = "cmbHasta_Odeme";
            this.cmbHasta_Odeme.Size = new System.Drawing.Size(250, 22);
            this.cmbHasta_Odeme.TabIndex = 1;
            this.cmbHasta_Odeme.SelectedIndexChanged += new System.EventHandler(this.cmbHasta_Odeme_SelectedIndexChanged);
            // 
            // lblHasta_Odeme
            // 
            this.lblHasta_Odeme.AutoSize = true;
            this.lblHasta_Odeme.Location = new System.Drawing.Point(20, 30);
            this.lblHasta_Odeme.Name = "lblHasta_Odeme";
            this.lblHasta_Odeme.Size = new System.Drawing.Size(41, 14);
            this.lblHasta_Odeme.TabIndex = 0;
            this.lblHasta_Odeme.Text = "Hasta:";
            // 
            // tabKasa
            // 
            this.tabKasa.Controls.Add(this.btnKasaYenile);
            this.tabKasa.Controls.Add(this.grdTumIslemler);
            this.tabKasa.Controls.Add(this.lblToplamAlacak);
            this.tabKasa.Controls.Add(this.lblToplamCiro);
            this.tabKasa.Location = new System.Drawing.Point(4, 23);
            this.tabKasa.Name = "tabKasa";
            this.tabKasa.Padding = new System.Windows.Forms.Padding(3);
            this.tabKasa.Size = new System.Drawing.Size(1042, 473);
            this.tabKasa.TabIndex = 2;
            this.tabKasa.Text = "Kasa & Rapor";
            this.tabKasa.UseVisualStyleBackColor = true;
            // 
            // btnKasaYenile
            // 
            this.btnKasaYenile.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnKasaYenile.Location = new System.Drawing.Point(479, 20);
            this.btnKasaYenile.Name = "btnKasaYenile";
            this.btnKasaYenile.Size = new System.Drawing.Size(120, 50);
            this.btnKasaYenile.TabIndex = 3;
            this.btnKasaYenile.Text = "YENİLE";
            this.btnKasaYenile.UseVisualStyleBackColor = false;
            this.btnKasaYenile.Click += new System.EventHandler(this.btnKasaYenile_Click);
            // 
            // grdTumIslemler
            // 
            this.grdTumIslemler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTumIslemler.Location = new System.Drawing.Point(20, 90);
            this.grdTumIslemler.Name = "grdTumIslemler";
            this.grdTumIslemler.RowTemplate.Height = 24;
            this.grdTumIslemler.Size = new System.Drawing.Size(1000, 350);
            this.grdTumIslemler.TabIndex = 2;
            // 
            // lblToplamAlacak
            // 
            this.lblToplamAlacak.AutoSize = true;
            this.lblToplamAlacak.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamAlacak.ForeColor = System.Drawing.Color.DarkRed;
            this.lblToplamAlacak.Location = new System.Drawing.Point(20, 50);
            this.lblToplamAlacak.Name = "lblToplamAlacak";
            this.lblToplamAlacak.Size = new System.Drawing.Size(176, 19);
            this.lblToplamAlacak.TabIndex = 1;
            this.lblToplamAlacak.Text = "Toplam Alacak: 0 TL";
            // 
            // lblToplamCiro
            // 
            this.lblToplamCiro.AutoSize = true;
            this.lblToplamCiro.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamCiro.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblToplamCiro.Location = new System.Drawing.Point(20, 20);
            this.lblToplamCiro.Name = "lblToplamCiro";
            this.lblToplamCiro.Size = new System.Drawing.Size(154, 19);
            this.lblToplamCiro.TabIndex = 0;
            this.lblToplamCiro.Text = "Toplam Ciro: 0 TL";
            // 
            // FrmOdeme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1050, 500);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "FrmOdeme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ödemeler & Muhasebe";
            this.Load += new System.EventHandler(this.FrmOdeme_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabBorc.ResumeLayout(false);
            this.tabBorc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTutar_Borc)).EndInit();
            this.tabOdeme.ResumeLayout(false);
            this.tabOdeme.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOdemeTutari)).EndInit();
            this.tabKasa.ResumeLayout(false);
            this.tabKasa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTumIslemler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBorc;
        private System.Windows.Forms.TabPage tabOdeme;
        private System.Windows.Forms.TabPage tabKasa;
        private System.Windows.Forms.Label lblHasta_Borc;
        private System.Windows.Forms.ComboBox cmbHasta_Borc;
        private System.Windows.Forms.Label lblTedavi;
        private System.Windows.Forms.ComboBox cmbTedavi;
        private System.Windows.Forms.Label lblTutar_Borc;
        private System.Windows.Forms.NumericUpDown numTutar_Borc;
        private System.Windows.Forms.Label lblTarih_Borc;
        private System.Windows.Forms.DateTimePicker dtpTarih_Borc;
        private System.Windows.Forms.Button btnBorcKaydet;
        private System.Windows.Forms.Label lblHasta_Odeme;
        private System.Windows.Forms.ComboBox cmbHasta_Odeme;
        private System.Windows.Forms.Label lblGuncelBakiye;
        private System.Windows.Forms.Label lblOdemeTutari;
        private System.Windows.Forms.NumericUpDown numOdemeTutari;
        private System.Windows.Forms.Label lblTarih_Odeme;
        private System.Windows.Forms.DateTimePicker dtpTarih_Odeme;
        private System.Windows.Forms.Button btnOdemeKaydet;
        private System.Windows.Forms.Label lblToplamCiro;
        private System.Windows.Forms.Label lblToplamAlacak;
        private System.Windows.Forms.DataGridView grdTumIslemler;
        private System.Windows.Forms.Button btnKasaYenile;
    }
}
