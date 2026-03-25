namespace DisKlinik.Hasta.Forms
{
    partial class FrmYonetici
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabIstatistikler = new System.Windows.Forms.TabPage();
            this.lblTedaviBaslik = new System.Windows.Forms.Label();
            this.chartTedaviler = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblKazancBaslik = new System.Windows.Forms.Label();
            this.chartKazanc = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnIstatistikYenile = new System.Windows.Forms.Button();
            this.tabLoglar = new System.Windows.Forms.TabPage();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.btnYenile = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.cmbLogFiltre = new System.Windows.Forms.ComboBox();
            this.grdLoglar = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.lblToplamCiro = new System.Windows.Forms.Label();
            this.lblToplamAlacak = new System.Windows.Forms.Label();
            this.grdTumIslemler = new System.Windows.Forms.DataGridView();
            this.btnKasaYenile = new System.Windows.Forms.Button();
            this.btnKasaRapor = new DevExpress.XtraEditors.SimpleButton();
            this.tabFinansal = new System.Windows.Forms.TabPage();
            this.pnlOdemeIcerik = new System.Windows.Forms.Panel();
            this.tabOdeme = new System.Windows.Forms.TabPage();
            this.tabIstatistikler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTedaviler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartKazanc)).BeginInit();
            this.tabLoglar.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoglar)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTumIslemler)).BeginInit();
            this.tabFinansal.SuspendLayout();
            this.tabOdeme.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabIstatistikler
            // 
            this.tabIstatistikler.Controls.Add(this.btnIstatistikYenile);
            this.tabIstatistikler.Controls.Add(this.chartKazanc);
            this.tabIstatistikler.Controls.Add(this.lblKazancBaslik);
            this.tabIstatistikler.Controls.Add(this.chartTedaviler);
            this.tabIstatistikler.Controls.Add(this.lblTedaviBaslik);
            this.tabIstatistikler.Location = new System.Drawing.Point(4, 23);
            this.tabIstatistikler.Name = "tabIstatistikler";
            this.tabIstatistikler.Padding = new System.Windows.Forms.Padding(3);
            this.tabIstatistikler.Size = new System.Drawing.Size(992, 473);
            this.tabIstatistikler.TabIndex = 1;
            this.tabIstatistikler.Text = "İstatistikler & Raporlar";
            this.tabIstatistikler.UseVisualStyleBackColor = true;
            // 
            // lblTedaviBaslik
            // 
            this.lblTedaviBaslik.AutoSize = true;
            this.lblTedaviBaslik.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTedaviBaslik.Location = new System.Drawing.Point(10, 25);
            this.lblTedaviBaslik.Name = "lblTedaviBaslik";
            this.lblTedaviBaslik.Size = new System.Drawing.Size(278, 19);
            this.lblTedaviBaslik.TabIndex = 0;
            this.lblTedaviBaslik.Text = "En Çok Yapılan Tedaviler (Top 5)";
            // 
            // chartTedaviler
            // 
            chartArea9.Name = "ChartArea1";
            this.chartTedaviler.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.chartTedaviler.Legends.Add(legend9);
            this.chartTedaviler.Location = new System.Drawing.Point(10, 50);
            this.chartTedaviler.Name = "chartTedaviler";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series9.Legend = "Legend1";
            series9.Name = "Tedaviler";
            this.chartTedaviler.Series.Add(series9);
            this.chartTedaviler.Size = new System.Drawing.Size(500, 400);
            this.chartTedaviler.TabIndex = 1;
            this.chartTedaviler.Text = "chartTedaviler";
            // 
            // lblKazancBaslik
            // 
            this.lblKazancBaslik.AutoSize = true;
            this.lblKazancBaslik.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKazancBaslik.Location = new System.Drawing.Point(520, 25);
            this.lblKazancBaslik.Name = "lblKazancBaslik";
            this.lblKazancBaslik.Size = new System.Drawing.Size(179, 19);
            this.lblKazancBaslik.TabIndex = 2;
            this.lblKazancBaslik.Text = "Son 7 Günün Kazancı";
            // 
            // chartKazanc
            // 
            chartArea10.Name = "ChartArea1";
            this.chartKazanc.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.chartKazanc.Legends.Add(legend10);
            this.chartKazanc.Location = new System.Drawing.Point(520, 50);
            this.chartKazanc.Name = "chartKazanc";
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "Kazanç";
            this.chartKazanc.Series.Add(series10);
            this.chartKazanc.Size = new System.Drawing.Size(460, 400);
            this.chartKazanc.TabIndex = 3;
            this.chartKazanc.Text = "chartKazanc";
            // 
            // btnIstatistikYenile
            // 
            this.btnIstatistikYenile.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnIstatistikYenile.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIstatistikYenile.Location = new System.Drawing.Point(850, 10);
            this.btnIstatistikYenile.Name = "btnIstatistikYenile";
            this.btnIstatistikYenile.Size = new System.Drawing.Size(130, 30);
            this.btnIstatistikYenile.TabIndex = 4;
            this.btnIstatistikYenile.Text = "YENİLE";
            this.btnIstatistikYenile.UseVisualStyleBackColor = false;
            this.btnIstatistikYenile.Click += new System.EventHandler(this.btnIstatistikYenile_Click);
            // 
            // tabLoglar
            // 
            this.tabLoglar.Controls.Add(this.grdLoglar);
            this.tabLoglar.Controls.Add(this.pnlTop);
            this.tabLoglar.Location = new System.Drawing.Point(4, 23);
            this.tabLoglar.Name = "tabLoglar";
            this.tabLoglar.Padding = new System.Windows.Forms.Padding(3);
            this.tabLoglar.Size = new System.Drawing.Size(992, 473);
            this.tabLoglar.TabIndex = 0;
            this.tabLoglar.Text = "Sistem Logları";
            this.tabLoglar.UseVisualStyleBackColor = true;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTop.Controls.Add(this.cmbLogFiltre);
            this.pnlTop.Controls.Add(this.btnTemizle);
            this.pnlTop.Controls.Add(this.btnYenile);
            this.pnlTop.Controls.Add(this.lblBaslik);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(3, 3);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(986, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.Location = new System.Drawing.Point(20, 18);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(216, 23);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Sistem İşlem Geçmişi";
            // 
            // btnYenile
            // 
            this.btnYenile.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnYenile.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYenile.Location = new System.Drawing.Point(690, 15);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(100, 30);
            this.btnYenile.TabIndex = 1;
            this.btnYenile.Text = "YENİLE";
            this.btnYenile.UseVisualStyleBackColor = false;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.Firebrick;
            this.btnTemizle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Location = new System.Drawing.Point(796, 15);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(190, 30);
            this.btnTemizle.TabIndex = 2;
            this.btnTemizle.Text = "TÜMÜNÜ TEMİZLE";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // cmbLogFiltre
            // 
            this.cmbLogFiltre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogFiltre.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbLogFiltre.FormattingEnabled = true;
            this.cmbLogFiltre.Location = new System.Drawing.Point(280, 18);
            this.cmbLogFiltre.Name = "cmbLogFiltre";
            this.cmbLogFiltre.Size = new System.Drawing.Size(200, 24);
            this.cmbLogFiltre.TabIndex = 3;
            this.cmbLogFiltre.SelectedIndexChanged += new System.EventHandler(this.cmbLogFiltre_SelectedIndexChanged);
            // 
            // grdLoglar
            // 
            this.grdLoglar.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.grdLoglar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLoglar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLoglar.Location = new System.Drawing.Point(3, 63);
            this.grdLoglar.Name = "grdLoglar";
            this.grdLoglar.RowTemplate.Height = 24;
            this.grdLoglar.Size = new System.Drawing.Size(986, 407);
            this.grdLoglar.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabLoglar);
            this.tabControl1.Controls.Add(this.tabIstatistikler);
            this.tabControl1.Controls.Add(this.tabFinansal);
            this.tabControl1.Controls.Add(this.tabOdeme);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // lblToplamCiro
            // 
            this.lblToplamCiro.AutoSize = true;
            this.lblToplamCiro.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamCiro.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblToplamCiro.Location = new System.Drawing.Point(20, 20);
            this.lblToplamCiro.Name = "lblToplamCiro";
            this.lblToplamCiro.Size = new System.Drawing.Size(0, 19);
            this.lblToplamCiro.TabIndex = 1;
            // 
            // lblToplamAlacak
            // 
            this.lblToplamAlacak.AutoSize = true;
            this.lblToplamAlacak.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamAlacak.ForeColor = System.Drawing.Color.DarkRed;
            this.lblToplamAlacak.Location = new System.Drawing.Point(20, 50);
            this.lblToplamAlacak.Name = "lblToplamAlacak";
            this.lblToplamAlacak.Size = new System.Drawing.Size(0, 19);
            this.lblToplamAlacak.TabIndex = 2;
            // 
            // grdTumIslemler
            // 
            this.grdTumIslemler.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.grdTumIslemler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTumIslemler.Location = new System.Drawing.Point(20, 90);
            this.grdTumIslemler.Name = "grdTumIslemler";
            this.grdTumIslemler.RowTemplate.Height = 24;
            this.grdTumIslemler.Size = new System.Drawing.Size(950, 360);
            this.grdTumIslemler.TabIndex = 3;
            // 
            // btnKasaYenile
            // 
            this.btnKasaYenile.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnKasaYenile.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKasaYenile.Location = new System.Drawing.Point(392, 19);
            this.btnKasaYenile.Name = "btnKasaYenile";
            this.btnKasaYenile.Size = new System.Drawing.Size(120, 50);
            this.btnKasaYenile.TabIndex = 4;
            this.btnKasaYenile.Text = "YENİLE";
            this.btnKasaYenile.UseVisualStyleBackColor = false;
            this.btnKasaYenile.Click += new System.EventHandler(this.btnKasaYenile_Click);
            // 
            // btnKasaRapor
            // 
            this.btnKasaRapor.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnKasaRapor.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKasaRapor.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKasaRapor.Appearance.Options.UseBackColor = true;
            this.btnKasaRapor.Appearance.Options.UseFont = true;
            this.btnKasaRapor.Appearance.Options.UseForeColor = true;
            this.btnKasaRapor.Location = new System.Drawing.Point(530, 19);
            this.btnKasaRapor.Name = "btnKasaRapor";
            this.btnKasaRapor.Size = new System.Drawing.Size(150, 50);
            this.btnKasaRapor.TabIndex = 5;
            this.btnKasaRapor.Text = "Tabloyu yazdır";
            this.btnKasaRapor.Click += new System.EventHandler(this.btnKasaRapor_Click);
            // 
            // tabFinansal
            // 
            this.tabFinansal.Controls.Add(this.btnKasaRapor);
            this.tabFinansal.Controls.Add(this.btnKasaYenile);
            this.tabFinansal.Controls.Add(this.grdTumIslemler);
            this.tabFinansal.Controls.Add(this.lblToplamAlacak);
            this.tabFinansal.Controls.Add(this.lblToplamCiro);
            this.tabFinansal.Location = new System.Drawing.Point(4, 23);
            this.tabFinansal.Name = "tabFinansal";
            this.tabFinansal.Padding = new System.Windows.Forms.Padding(3);
            this.tabFinansal.Size = new System.Drawing.Size(992, 473);
            this.tabFinansal.TabIndex = 2;
            this.tabFinansal.Text = "Kasa & Muhasebe";
            this.tabFinansal.UseVisualStyleBackColor = true;
            // 
            // pnlOdemeIcerik
            // 
            this.pnlOdemeIcerik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOdemeIcerik.Location = new System.Drawing.Point(3, 3);
            this.pnlOdemeIcerik.Name = "pnlOdemeIcerik";
            this.pnlOdemeIcerik.Size = new System.Drawing.Size(986, 467);
            this.pnlOdemeIcerik.TabIndex = 0;
            // 
            // tabOdeme
            // 
            this.tabOdeme.Controls.Add(this.pnlOdemeIcerik);
            this.tabOdeme.Location = new System.Drawing.Point(4, 23);
            this.tabOdeme.Name = "tabOdeme";
            this.tabOdeme.Padding = new System.Windows.Forms.Padding(3);
            this.tabOdeme.Size = new System.Drawing.Size(992, 473);
            this.tabOdeme.TabIndex = 3;
            this.tabOdeme.Text = "Ödemeler";
            this.tabOdeme.UseVisualStyleBackColor = true;
            // 
            // FrmYonetici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "FrmYonetici";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yönetici Paneli";
            this.Load += new System.EventHandler(this.FrmYonetici_Load);
            this.tabIstatistikler.ResumeLayout(false);
            this.tabIstatistikler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTedaviler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartKazanc)).EndInit();
            this.tabLoglar.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoglar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTumIslemler)).EndInit();
            this.tabFinansal.ResumeLayout(false);
            this.tabFinansal.PerformLayout();
            this.tabOdeme.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabIstatistikler;
        private System.Windows.Forms.Button btnIstatistikYenile;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartKazanc;
        private System.Windows.Forms.Label lblKazancBaslik;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTedaviler;
        private System.Windows.Forms.Label lblTedaviBaslik;
        private System.Windows.Forms.TabPage tabLoglar;
        private System.Windows.Forms.DataGridView grdLoglar;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ComboBox cmbLogFiltre;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFinansal;
        private DevExpress.XtraEditors.SimpleButton btnKasaRapor;
        private System.Windows.Forms.Button btnKasaYenile;
        private System.Windows.Forms.DataGridView grdTumIslemler;
        private System.Windows.Forms.Label lblToplamAlacak;
        private System.Windows.Forms.Label lblToplamCiro;
        private System.Windows.Forms.TabPage tabOdeme;
        private System.Windows.Forms.Panel pnlOdemeIcerik;
    }
}
