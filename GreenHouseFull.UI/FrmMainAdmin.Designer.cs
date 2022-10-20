namespace GreenHouseFull.UI
{
    partial class FrmMainAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogOut = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.urunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.araToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ekleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aramaGecmisiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favorilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.karaListeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yöneticiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlarAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ureticiAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kategoriAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullaniciAdminToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.urunIcerikAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urunAdminToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.urunDuzeltmeTalepleriAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urunOnaylamaAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullaniciFavoriListeAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullaniciGecmisAramaAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullaniciFavoriUrunAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullaniciKaraListeAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogOut.Location = new System.Drawing.Point(1047, 27);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.urunToolStripMenuItem,
            this.kullanıcıToolStripMenuItem,
            this.yöneticiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1159, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // urunToolStripMenuItem
            // 
            this.urunToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.araToolStripMenuItem,
            this.ekleToolStripMenuItem});
            this.urunToolStripMenuItem.Name = "urunToolStripMenuItem";
            this.urunToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.urunToolStripMenuItem.Text = "Ürün";
            // 
            // araToolStripMenuItem
            // 
            this.araToolStripMenuItem.Name = "araToolStripMenuItem";
            this.araToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.araToolStripMenuItem.Text = "Ara";
            this.araToolStripMenuItem.Click += new System.EventHandler(this.araToolStripMenuItem_Click);
            // 
            // ekleToolStripMenuItem
            // 
            this.ekleToolStripMenuItem.Name = "ekleToolStripMenuItem";
            this.ekleToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.ekleToolStripMenuItem.Text = "Ekle";
            this.ekleToolStripMenuItem.Click += new System.EventHandler(this.ekleToolStripMenuItem_Click);
            // 
            // kullanıcıToolStripMenuItem
            // 
            this.kullanıcıToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilToolStripMenuItem,
            this.aramaGecmisiToolStripMenuItem,
            this.favorilerToolStripMenuItem,
            this.karaListeToolStripMenuItem});
            this.kullanıcıToolStripMenuItem.Name = "kullanıcıToolStripMenuItem";
            this.kullanıcıToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.kullanıcıToolStripMenuItem.Text = "Kullanıcı";
            // 
            // profilToolStripMenuItem
            // 
            this.profilToolStripMenuItem.Name = "profilToolStripMenuItem";
            this.profilToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.profilToolStripMenuItem.Text = "Profil";
            this.profilToolStripMenuItem.Click += new System.EventHandler(this.profilToolStripMenuItem_Click);
            // 
            // aramaGecmisiToolStripMenuItem
            // 
            this.aramaGecmisiToolStripMenuItem.Name = "aramaGecmisiToolStripMenuItem";
            this.aramaGecmisiToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.aramaGecmisiToolStripMenuItem.Text = "Arama Geçmişi";
            this.aramaGecmisiToolStripMenuItem.Click += new System.EventHandler(this.aramaGecmisiToolStripMenuItem_Click);
            // 
            // favorilerToolStripMenuItem
            // 
            this.favorilerToolStripMenuItem.Name = "favorilerToolStripMenuItem";
            this.favorilerToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.favorilerToolStripMenuItem.Text = "Favoriler";
            this.favorilerToolStripMenuItem.Click += new System.EventHandler(this.favorilerToolStripMenuItem_Click);
            // 
            // karaListeToolStripMenuItem
            // 
            this.karaListeToolStripMenuItem.Name = "karaListeToolStripMenuItem";
            this.karaListeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.karaListeToolStripMenuItem.Text = "Kara Liste";
            this.karaListeToolStripMenuItem.Click += new System.EventHandler(this.karaListeToolStripMenuItem_Click);
            // 
            // yöneticiToolStripMenuItem
            // 
            this.yöneticiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.raporlarAdminToolStripMenuItem,
            this.ureticiAdminToolStripMenuItem,
            this.kategoriAdminToolStripMenuItem,
            this.kullaniciAdminToolStripMenuItem1,
            this.urunIcerikAdminToolStripMenuItem,
            this.urunAdminToolStripMenuItem1,
            this.urunDuzeltmeTalepleriAdminToolStripMenuItem,
            this.urunOnaylamaAdminToolStripMenuItem,
            this.kullaniciFavoriListeAdminToolStripMenuItem,
            this.kullaniciGecmisAramaAdminToolStripMenuItem,
            this.kullaniciFavoriUrunAdminToolStripMenuItem,
            this.kullaniciKaraListeAdminToolStripMenuItem});
            this.yöneticiToolStripMenuItem.Name = "yöneticiToolStripMenuItem";
            this.yöneticiToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.yöneticiToolStripMenuItem.Text = "Yönetici";
            // 
            // raporlarAdminToolStripMenuItem
            // 
            this.raporlarAdminToolStripMenuItem.Name = "raporlarAdminToolStripMenuItem";
            this.raporlarAdminToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.raporlarAdminToolStripMenuItem.Text = "Raporlar";
            this.raporlarAdminToolStripMenuItem.Click += new System.EventHandler(this.raporlarToolStripMenuItem_Click);
            // 
            // ureticiAdminToolStripMenuItem
            // 
            this.ureticiAdminToolStripMenuItem.Name = "ureticiAdminToolStripMenuItem";
            this.ureticiAdminToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.ureticiAdminToolStripMenuItem.Text = "Üretici";
            this.ureticiAdminToolStripMenuItem.Click += new System.EventHandler(this.ureticiAdminToolStripMenuItem_Click);
            // 
            // kategoriAdminToolStripMenuItem
            // 
            this.kategoriAdminToolStripMenuItem.Name = "kategoriAdminToolStripMenuItem";
            this.kategoriAdminToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.kategoriAdminToolStripMenuItem.Text = "Kategori";
            this.kategoriAdminToolStripMenuItem.Click += new System.EventHandler(this.kategoriAdminToolStripMenuItem_Click);
            // 
            // kullaniciAdminToolStripMenuItem1
            // 
            this.kullaniciAdminToolStripMenuItem1.Name = "kullaniciAdminToolStripMenuItem1";
            this.kullaniciAdminToolStripMenuItem1.Size = new System.Drawing.Size(222, 22);
            this.kullaniciAdminToolStripMenuItem1.Text = "Kullanıcı";
            this.kullaniciAdminToolStripMenuItem1.Click += new System.EventHandler(this.kullaniciAdminToolStripMenuItem1_Click);
            // 
            // urunIcerikAdminToolStripMenuItem
            // 
            this.urunIcerikAdminToolStripMenuItem.Name = "urunIcerikAdminToolStripMenuItem";
            this.urunIcerikAdminToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.urunIcerikAdminToolStripMenuItem.Text = "Ürün İçerik";
            this.urunIcerikAdminToolStripMenuItem.Click += new System.EventHandler(this.urunIcerikAdminToolStripMenuItem_Click);
            // 
            // urunAdminToolStripMenuItem1
            // 
            this.urunAdminToolStripMenuItem1.Name = "urunAdminToolStripMenuItem1";
            this.urunAdminToolStripMenuItem1.Size = new System.Drawing.Size(222, 22);
            this.urunAdminToolStripMenuItem1.Text = "Ürün";
            this.urunAdminToolStripMenuItem1.Click += new System.EventHandler(this.urunAdminToolStripMenuItem1_Click);
            // 
            // urunDuzeltmeTalepleriAdminToolStripMenuItem
            // 
            this.urunDuzeltmeTalepleriAdminToolStripMenuItem.Name = "urunDuzeltmeTalepleriAdminToolStripMenuItem";
            this.urunDuzeltmeTalepleriAdminToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.urunDuzeltmeTalepleriAdminToolStripMenuItem.Text = "Ürün Düzeltme Talepleri";
            this.urunDuzeltmeTalepleriAdminToolStripMenuItem.Click += new System.EventHandler(this.urunDuzeltmeTalepleriAdminToolStripMenuItem_Click);
            // 
            // urunOnaylamaAdminToolStripMenuItem
            // 
            this.urunOnaylamaAdminToolStripMenuItem.Name = "urunOnaylamaAdminToolStripMenuItem";
            this.urunOnaylamaAdminToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.urunOnaylamaAdminToolStripMenuItem.Text = "Ürün Onaylama";
            this.urunOnaylamaAdminToolStripMenuItem.Click += new System.EventHandler(this.urunOnaylamaToolStripMenuItem_Click);
            // 
            // kullaniciFavoriListeAdminToolStripMenuItem
            // 
            this.kullaniciFavoriListeAdminToolStripMenuItem.Name = "kullaniciFavoriListeAdminToolStripMenuItem";
            this.kullaniciFavoriListeAdminToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.kullaniciFavoriListeAdminToolStripMenuItem.Text = "Kullanıcı Favori Listeleri";
            this.kullaniciFavoriListeAdminToolStripMenuItem.Click += new System.EventHandler(this.kullaniciFavoriListeAdminToolStripMenuItem_Click);
            // 
            // kullaniciGecmisAramaAdminToolStripMenuItem
            // 
            this.kullaniciGecmisAramaAdminToolStripMenuItem.Name = "kullaniciGecmisAramaAdminToolStripMenuItem";
            this.kullaniciGecmisAramaAdminToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.kullaniciGecmisAramaAdminToolStripMenuItem.Text = "Kullanıcı Geçmiş Aramalar";
            this.kullaniciGecmisAramaAdminToolStripMenuItem.Click += new System.EventHandler(this.kullaniciGecmisAramaAdminToolStripMenuItem_Click);
            // 
            // kullaniciFavoriUrunAdminToolStripMenuItem
            // 
            this.kullaniciFavoriUrunAdminToolStripMenuItem.Name = "kullaniciFavoriUrunAdminToolStripMenuItem";
            this.kullaniciFavoriUrunAdminToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.kullaniciFavoriUrunAdminToolStripMenuItem.Text = "Kullanıcıların Favori Ürünleri";
            this.kullaniciFavoriUrunAdminToolStripMenuItem.Click += new System.EventHandler(this.kullaniciFavoriUrunAdminToolStripMenuItem_Click);
            // 
            // kullaniciKaraListeAdminToolStripMenuItem
            // 
            this.kullaniciKaraListeAdminToolStripMenuItem.Name = "kullaniciKaraListeAdminToolStripMenuItem";
            this.kullaniciKaraListeAdminToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.kullaniciKaraListeAdminToolStripMenuItem.Text = "Kullanıcı Kara Liste İçerikleri";
            this.kullaniciKaraListeAdminToolStripMenuItem.Click += new System.EventHandler(this.kullaniciKaraListeAdminToolStripMenuItem_Click);
            // 
            // FrmMainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 736);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnLogOut);
            this.IsMdiContainer = true;
            this.Name = "FrmMainAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Formu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMainAdmin_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem urunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yöneticiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem araToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ekleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aramaGecmisiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem favorilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporlarAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem karaListeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urunOnaylamaAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urunDuzeltmeTalepleriAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ureticiAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kategoriAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urunIcerikAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullaniciAdminToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem urunAdminToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem kullaniciFavoriListeAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullaniciGecmisAramaAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullaniciFavoriUrunAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullaniciKaraListeAdminToolStripMenuItem;
    }
}