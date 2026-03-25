using DevExpress.XtraEditors;

namespace DisKlinik.Hasta.Forms
{
    partial class FrmAnaSayfa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnaSayfa));
            this.pnlUst = new System.Windows.Forms.Panel();
            this.btnCikis = new DevExpress.XtraEditors.SimpleButton();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.btnGeri = new DevExpress.XtraEditors.SimpleButton();
            this.pnlIcerik = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnHasta = new DevExpress.XtraEditors.SimpleButton();
            this.btnDoktor = new DevExpress.XtraEditors.SimpleButton();
            this.btnRandevu = new DevExpress.XtraEditors.SimpleButton();
            this.btnTedavi = new DevExpress.XtraEditors.SimpleButton();
            this.btnRecete = new DevExpress.XtraEditors.SimpleButton();
            this.btnYapayZeka = new DevExpress.XtraEditors.SimpleButton();
            this.pnlUst.SuspendLayout();
            this.pnlIcerik.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUst
            // 
            this.pnlUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlUst.Controls.Add(this.btnCikis);
            this.pnlUst.Controls.Add(this.lblBaslik);
            this.pnlUst.Controls.Add(this.btnGeri);
            this.pnlUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUst.Location = new System.Drawing.Point(0, 0);
            this.pnlUst.Name = "pnlUst";
            this.pnlUst.Size = new System.Drawing.Size(1000, 80);
            this.pnlUst.TabIndex = 0;
            // 
            // btnCikis
            // 
            this.btnCikis.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnCikis.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Appearance.Options.UseBackColor = true;
            this.btnCikis.Appearance.Options.UseFont = true;
            this.btnCikis.Appearance.Options.UseForeColor = true;
            this.btnCikis.AppearanceHovered.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnCikis.AppearanceHovered.Options.UseBackColor = true;
            this.btnCikis.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCikis.Location = new System.Drawing.Point(900, 0);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(100, 80);
            this.btnCikis.TabIndex = 2;
            this.btnCikis.Text = "ÇIKIŞ";
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(70, 25);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(130, 29);
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.Text = "Ana Menü";
            // 
            // btnGeri
            // 
            this.btnGeri.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGeri.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeri.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.btnGeri.Appearance.Options.UseBackColor = true;
            this.btnGeri.Appearance.Options.UseFont = true;
            this.btnGeri.Appearance.Options.UseForeColor = true;
            this.btnGeri.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnGeri.AppearanceHovered.Options.UseBackColor = true;
            this.btnGeri.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGeri.ImageOptions.Image")));
            this.btnGeri.Location = new System.Drawing.Point(14, 25);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(38, 40);
            this.btnGeri.TabIndex = 0;
            this.btnGeri.Visible = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // pnlIcerik
            // 
            this.pnlIcerik.BackColor = System.Drawing.Color.White;
            this.pnlIcerik.Controls.Add(this.tableLayoutPanel1);
            this.pnlIcerik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIcerik.Location = new System.Drawing.Point(0, 80);
            this.pnlIcerik.Name = "pnlIcerik";
            this.pnlIcerik.Size = new System.Drawing.Size(1000, 420);
            this.pnlIcerik.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnHasta, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDoktor, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRandevu, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTedavi, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnRecete, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnYapayZeka, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(30);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 420);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnHasta
            // 
            this.btnHasta.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnHasta.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHasta.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnHasta.Appearance.Options.UseBackColor = true;
            this.btnHasta.Appearance.Options.UseFont = true;
            this.btnHasta.Appearance.Options.UseForeColor = true;
            this.btnHasta.AppearanceHovered.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnHasta.AppearanceHovered.Options.UseBackColor = true;
            this.btnHasta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHasta.Location = new System.Drawing.Point(33, 33);
            this.btnHasta.Name = "btnHasta";
            this.btnHasta.Size = new System.Drawing.Size(307, 174);
            this.btnHasta.TabIndex = 0;
            this.btnHasta.Text = "HASTA İŞLEMLERİ";
            this.btnHasta.Click += new System.EventHandler(this.btnHasta_Click);
            // 
            // btnDoktor
            // 
            this.btnDoktor.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnDoktor.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDoktor.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDoktor.Appearance.Options.UseBackColor = true;
            this.btnDoktor.Appearance.Options.UseFont = true;
            this.btnDoktor.Appearance.Options.UseForeColor = true;
            this.btnDoktor.AppearanceHovered.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnDoktor.AppearanceHovered.Options.UseBackColor = true;
            this.btnDoktor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDoktor.Location = new System.Drawing.Point(346, 33);
            this.btnDoktor.Name = "btnDoktor";
            this.btnDoktor.Size = new System.Drawing.Size(307, 174);
            this.btnDoktor.TabIndex = 1;
            this.btnDoktor.Text = "DOKTOR İŞLEMLERİ";
            this.btnDoktor.Click += new System.EventHandler(this.btnDoktor_Click);
            // 
            // btnRandevu
            // 
            this.btnRandevu.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnRandevu.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRandevu.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRandevu.Appearance.Options.UseBackColor = true;
            this.btnRandevu.Appearance.Options.UseFont = true;
            this.btnRandevu.Appearance.Options.UseForeColor = true;
            this.btnRandevu.AppearanceHovered.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnRandevu.AppearanceHovered.Options.UseBackColor = true;
            this.btnRandevu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRandevu.Location = new System.Drawing.Point(659, 33);
            this.btnRandevu.Name = "btnRandevu";
            this.btnRandevu.Size = new System.Drawing.Size(308, 174);
            this.btnRandevu.TabIndex = 2;
            this.btnRandevu.Text = "RANDEVU İŞLEMLERİ";
            this.btnRandevu.Click += new System.EventHandler(this.btnRandevu_Click);
            // 
            // btnTedavi
            // 
            this.btnTedavi.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnTedavi.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTedavi.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTedavi.Appearance.Options.UseBackColor = true;
            this.btnTedavi.Appearance.Options.UseFont = true;
            this.btnTedavi.Appearance.Options.UseForeColor = true;
            this.btnTedavi.AppearanceHovered.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnTedavi.AppearanceHovered.Options.UseBackColor = true;
            this.btnTedavi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTedavi.Location = new System.Drawing.Point(33, 213);
            this.btnTedavi.Name = "btnTedavi";
            this.btnTedavi.Size = new System.Drawing.Size(307, 174);
            this.btnTedavi.TabIndex = 3;
            this.btnTedavi.Text = "TEDAVİLER";
            this.btnTedavi.Click += new System.EventHandler(this.btnTedavi_Click);
            // 
            // btnRecete
            // 
            this.btnRecete.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnRecete.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRecete.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRecete.Appearance.Options.UseBackColor = true;
            this.btnRecete.Appearance.Options.UseFont = true;
            this.btnRecete.Appearance.Options.UseForeColor = true;
            this.btnRecete.AppearanceHovered.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnRecete.AppearanceHovered.Options.UseBackColor = true;
            this.btnRecete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecete.Location = new System.Drawing.Point(346, 213);
            this.btnRecete.Name = "btnRecete";
            this.btnRecete.Size = new System.Drawing.Size(307, 174);
            this.btnRecete.TabIndex = 5;
            this.btnRecete.Text = "REÇETE YAZ";
            this.btnRecete.Click += new System.EventHandler(this.btnRecete_Click);
            // 
            // btnYapayZeka
            // 
            this.btnYapayZeka.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnYapayZeka.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYapayZeka.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYapayZeka.Appearance.Options.UseBackColor = true;
            this.btnYapayZeka.Appearance.Options.UseFont = true;
            this.btnYapayZeka.Appearance.Options.UseForeColor = true;
            this.btnYapayZeka.AppearanceHovered.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnYapayZeka.AppearanceHovered.Options.UseBackColor = true;
            this.btnYapayZeka.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYapayZeka.Location = new System.Drawing.Point(659, 213);
            this.btnYapayZeka.Name = "btnYapayZeka";
            this.btnYapayZeka.Size = new System.Drawing.Size(308, 174);
            this.btnYapayZeka.TabIndex = 6;
            this.btnYapayZeka.Text = "YAPAY ZEKA";
            this.btnYapayZeka.Click += new System.EventHandler(this.btnYapayZeka_Click);
            // 
            // FrmAnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.pnlIcerik);
            this.Controls.Add(this.pnlUst);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAnaSayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diş Kliniği Otomasyonu";
            this.Load += new System.EventHandler(this.FrmAnaSayfa_Load);
            this.pnlUst.ResumeLayout(false);
            this.pnlUst.PerformLayout();
            this.pnlIcerik.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUst;
        private DevExpress.XtraEditors.SimpleButton btnGeri;
        private System.Windows.Forms.Label lblBaslik;
        private DevExpress.XtraEditors.SimpleButton btnCikis;
        private System.Windows.Forms.Panel pnlIcerik;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnHasta;
        private DevExpress.XtraEditors.SimpleButton btnDoktor;
        private DevExpress.XtraEditors.SimpleButton btnRandevu;
        private DevExpress.XtraEditors.SimpleButton btnTedavi;
        private DevExpress.XtraEditors.SimpleButton btnRecete;
        private DevExpress.XtraEditors.SimpleButton btnYapayZeka;
    }
}
