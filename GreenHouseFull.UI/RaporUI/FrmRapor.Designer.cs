namespace GreenHouseFull.UI
{
    partial class FrmRapor
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
            this.btnUrunIcerikAdet = new System.Windows.Forms.Button();
            this.btnIcerikKullananUrunler = new System.Windows.Forms.Button();
            this.btnKullaniciUrunler = new System.Windows.Forms.Button();
            this.btnBekleyenOnay = new System.Windows.Forms.Button();
            this.btnIcerikKaraListeSayi = new System.Windows.Forms.Button();
            this.btnRiskliUrunler = new System.Windows.Forms.Button();
            this.btnFavoriUrunler = new System.Windows.Forms.Button();
            this.btnAlerjenUrunler = new System.Windows.Forms.Button();
            this.tnEnAzRiskUrun = new System.Windows.Forms.Button();
            this.btnRiskliUrunKullanici = new System.Windows.Forms.Button();
            this.btnKullanıcıEnCokUrun = new System.Windows.Forms.Button();
            this.btnEnAzMaddeUrun = new System.Windows.Forms.Button();
            this.btnAylikFavoriUrunler = new System.Windows.Forms.Button();
            this.btnKullaniciFavoriSayi = new System.Windows.Forms.Button();
            this.btnKullaniciTipSayi = new System.Windows.Forms.Button();
            this.btnFavoriUrunlerIlk3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUrunIcerikAdet
            // 
            this.btnUrunIcerikAdet.Location = new System.Drawing.Point(12, 12);
            this.btnUrunIcerikAdet.Name = "btnUrunIcerikAdet";
            this.btnUrunIcerikAdet.Size = new System.Drawing.Size(113, 49);
            this.btnUrunIcerikAdet.TabIndex = 0;
            this.btnUrunIcerikAdet.Text = "Ürünlerin İçerik Adetleri";
            this.btnUrunIcerikAdet.UseVisualStyleBackColor = true;
            this.btnUrunIcerikAdet.Click += new System.EventHandler(this.btnUrunIcerikAdet_Click);
            // 
            // btnIcerikKullananUrunler
            // 
            this.btnIcerikKullananUrunler.Location = new System.Drawing.Point(12, 77);
            this.btnIcerikKullananUrunler.Name = "btnIcerikKullananUrunler";
            this.btnIcerikKullananUrunler.Size = new System.Drawing.Size(113, 49);
            this.btnIcerikKullananUrunler.TabIndex = 1;
            this.btnIcerikKullananUrunler.Text = "Ürün İçeriği Kullanan Ürünler";
            this.btnIcerikKullananUrunler.UseVisualStyleBackColor = true;
            this.btnIcerikKullananUrunler.Click += new System.EventHandler(this.btnIcerikKullananUrunler_Click);
            // 
            // btnKullaniciUrunler
            // 
            this.btnKullaniciUrunler.Location = new System.Drawing.Point(12, 141);
            this.btnKullaniciUrunler.Name = "btnKullaniciUrunler";
            this.btnKullaniciUrunler.Size = new System.Drawing.Size(113, 49);
            this.btnKullaniciUrunler.TabIndex = 2;
            this.btnKullaniciUrunler.Text = "Kullanıcıların Eklediği Ürünler";
            this.btnKullaniciUrunler.UseVisualStyleBackColor = true;
            this.btnKullaniciUrunler.Click += new System.EventHandler(this.btnKullaniciUrunler_Click);
            // 
            // btnBekleyenOnay
            // 
            this.btnBekleyenOnay.Location = new System.Drawing.Point(12, 206);
            this.btnBekleyenOnay.Name = "btnBekleyenOnay";
            this.btnBekleyenOnay.Size = new System.Drawing.Size(113, 49);
            this.btnBekleyenOnay.TabIndex = 3;
            this.btnBekleyenOnay.Text = "Aylık Bekleyen Onay Sayısı";
            this.btnBekleyenOnay.UseVisualStyleBackColor = true;
            this.btnBekleyenOnay.Click += new System.EventHandler(this.btnBekleyenOnay_Click);
            // 
            // btnIcerikKaraListeSayi
            // 
            this.btnIcerikKaraListeSayi.Location = new System.Drawing.Point(146, 12);
            this.btnIcerikKaraListeSayi.Name = "btnIcerikKaraListeSayi";
            this.btnIcerikKaraListeSayi.Size = new System.Drawing.Size(113, 49);
            this.btnIcerikKaraListeSayi.TabIndex = 4;
            this.btnIcerikKaraListeSayi.Text = "İçerik Kaç Kişinin Kara Listesinde";
            this.btnIcerikKaraListeSayi.UseVisualStyleBackColor = true;
            this.btnIcerikKaraListeSayi.Click += new System.EventHandler(this.btnIcerikKaraListeSayi_Click);
            // 
            // btnRiskliUrunler
            // 
            this.btnRiskliUrunler.Location = new System.Drawing.Point(146, 77);
            this.btnRiskliUrunler.Name = "btnRiskliUrunler";
            this.btnRiskliUrunler.Size = new System.Drawing.Size(113, 49);
            this.btnRiskliUrunler.TabIndex = 5;
            this.btnRiskliUrunler.Text = "En Riskli Ürünler";
            this.btnRiskliUrunler.UseVisualStyleBackColor = true;
            this.btnRiskliUrunler.Click += new System.EventHandler(this.btnRiskliUrunler_Click);
            // 
            // btnFavoriUrunler
            // 
            this.btnFavoriUrunler.Location = new System.Drawing.Point(146, 142);
            this.btnFavoriUrunler.Name = "btnFavoriUrunler";
            this.btnFavoriUrunler.Size = new System.Drawing.Size(113, 49);
            this.btnFavoriUrunler.TabIndex = 6;
            this.btnFavoriUrunler.Text = "En Favori Ürünler";
            this.btnFavoriUrunler.UseVisualStyleBackColor = true;
            this.btnFavoriUrunler.Click += new System.EventHandler(this.btnFavoriUrunler_Click);
            // 
            // btnAlerjenUrunler
            // 
            this.btnAlerjenUrunler.Location = new System.Drawing.Point(277, 12);
            this.btnAlerjenUrunler.Name = "btnAlerjenUrunler";
            this.btnAlerjenUrunler.Size = new System.Drawing.Size(113, 49);
            this.btnAlerjenUrunler.TabIndex = 7;
            this.btnAlerjenUrunler.Text = "Alerjen Sayılarına Göre Ürünler";
            this.btnAlerjenUrunler.UseVisualStyleBackColor = true;
            this.btnAlerjenUrunler.Click += new System.EventHandler(this.btnAlerjenUrunler_Click);
            // 
            // tnEnAzRiskUrun
            // 
            this.tnEnAzRiskUrun.Location = new System.Drawing.Point(277, 77);
            this.tnEnAzRiskUrun.Name = "tnEnAzRiskUrun";
            this.tnEnAzRiskUrun.Size = new System.Drawing.Size(113, 49);
            this.tnEnAzRiskUrun.TabIndex = 8;
            this.tnEnAzRiskUrun.Text = "En Az Riskli Ürünler ve Favori Bilgisi";
            this.tnEnAzRiskUrun.UseVisualStyleBackColor = true;
            this.tnEnAzRiskUrun.Click += new System.EventHandler(this.tnEnAzRiskUrun_Click);
            // 
            // btnRiskliUrunKullanici
            // 
            this.btnRiskliUrunKullanici.Location = new System.Drawing.Point(277, 142);
            this.btnRiskliUrunKullanici.Name = "btnRiskliUrunKullanici";
            this.btnRiskliUrunKullanici.Size = new System.Drawing.Size(113, 49);
            this.btnRiskliUrunKullanici.TabIndex = 9;
            this.btnRiskliUrunKullanici.Text = "En Fazla Riskli Ürün Tutan İlk 3 Kullanıcı";
            this.btnRiskliUrunKullanici.UseVisualStyleBackColor = true;
            this.btnRiskliUrunKullanici.Click += new System.EventHandler(this.btnRiskliUrunKullanici_Click);
            // 
            // btnKullanıcıEnCokUrun
            // 
            this.btnKullanıcıEnCokUrun.Location = new System.Drawing.Point(277, 206);
            this.btnKullanıcıEnCokUrun.Name = "btnKullanıcıEnCokUrun";
            this.btnKullanıcıEnCokUrun.Size = new System.Drawing.Size(113, 49);
            this.btnKullanıcıEnCokUrun.TabIndex = 10;
            this.btnKullanıcıEnCokUrun.Text = "En Çok Ürün Giren Kullanıcılar İlk 5";
            this.btnKullanıcıEnCokUrun.UseVisualStyleBackColor = true;
            this.btnKullanıcıEnCokUrun.Click += new System.EventHandler(this.btnKullanıcıEnCokUrun_Click);
            // 
            // btnEnAzMaddeUrun
            // 
            this.btnEnAzMaddeUrun.Location = new System.Drawing.Point(412, 12);
            this.btnEnAzMaddeUrun.Name = "btnEnAzMaddeUrun";
            this.btnEnAzMaddeUrun.Size = new System.Drawing.Size(113, 49);
            this.btnEnAzMaddeUrun.TabIndex = 11;
            this.btnEnAzMaddeUrun.Text = "En Az Maddesi Olan 10 Ürün";
            this.btnEnAzMaddeUrun.UseVisualStyleBackColor = true;
            this.btnEnAzMaddeUrun.Click += new System.EventHandler(this.btnEnAzMaddeUrun_Click);
            // 
            // btnAylikFavoriUrunler
            // 
            this.btnAylikFavoriUrunler.Location = new System.Drawing.Point(412, 77);
            this.btnAylikFavoriUrunler.Name = "btnAylikFavoriUrunler";
            this.btnAylikFavoriUrunler.Size = new System.Drawing.Size(113, 49);
            this.btnAylikFavoriUrunler.TabIndex = 13;
            this.btnAylikFavoriUrunler.Text = "Aylık Favoriye Alınan Ürünler";
            this.btnAylikFavoriUrunler.UseVisualStyleBackColor = true;
            this.btnAylikFavoriUrunler.Click += new System.EventHandler(this.btnAylikFavoriUrunler_Click);
            // 
            // btnKullaniciFavoriSayi
            // 
            this.btnKullaniciFavoriSayi.Location = new System.Drawing.Point(412, 142);
            this.btnKullaniciFavoriSayi.Name = "btnKullaniciFavoriSayi";
            this.btnKullaniciFavoriSayi.Size = new System.Drawing.Size(113, 49);
            this.btnKullaniciFavoriSayi.TabIndex = 14;
            this.btnKullaniciFavoriSayi.Text = "Kullanıcı Favori Sayıları";
            this.btnKullaniciFavoriSayi.UseVisualStyleBackColor = true;
            this.btnKullaniciFavoriSayi.Click += new System.EventHandler(this.btnKullaniciFavoriSayi_Click);
            // 
            // btnKullaniciTipSayi
            // 
            this.btnKullaniciTipSayi.Location = new System.Drawing.Point(412, 206);
            this.btnKullaniciTipSayi.Name = "btnKullaniciTipSayi";
            this.btnKullaniciTipSayi.Size = new System.Drawing.Size(113, 49);
            this.btnKullaniciTipSayi.TabIndex = 15;
            this.btnKullaniciTipSayi.Text = "Kullanıcı Tipi Sayıları";
            this.btnKullaniciTipSayi.UseVisualStyleBackColor = true;
            this.btnKullaniciTipSayi.Click += new System.EventHandler(this.btnKullaniciTipSayi_Click);
            // 
            // btnFavoriUrunlerIlk3
            // 
            this.btnFavoriUrunlerIlk3.Location = new System.Drawing.Point(146, 206);
            this.btnFavoriUrunlerIlk3.Name = "btnFavoriUrunlerIlk3";
            this.btnFavoriUrunlerIlk3.Size = new System.Drawing.Size(113, 49);
            this.btnFavoriUrunlerIlk3.TabIndex = 16;
            this.btnFavoriUrunlerIlk3.Text = "En Favori Ürünler Ilk 3";
            this.btnFavoriUrunlerIlk3.UseVisualStyleBackColor = true;
            this.btnFavoriUrunlerIlk3.Click += new System.EventHandler(this.btnFavoriUrunlerIlk3_Click);
            // 
            // FrmRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 273);
            this.Controls.Add(this.btnFavoriUrunlerIlk3);
            this.Controls.Add(this.btnKullaniciTipSayi);
            this.Controls.Add(this.btnKullaniciFavoriSayi);
            this.Controls.Add(this.btnAylikFavoriUrunler);
            this.Controls.Add(this.btnEnAzMaddeUrun);
            this.Controls.Add(this.btnKullanıcıEnCokUrun);
            this.Controls.Add(this.btnRiskliUrunKullanici);
            this.Controls.Add(this.tnEnAzRiskUrun);
            this.Controls.Add(this.btnAlerjenUrunler);
            this.Controls.Add(this.btnFavoriUrunler);
            this.Controls.Add(this.btnRiskliUrunler);
            this.Controls.Add(this.btnIcerikKaraListeSayi);
            this.Controls.Add(this.btnBekleyenOnay);
            this.Controls.Add(this.btnKullaniciUrunler);
            this.Controls.Add(this.btnIcerikKullananUrunler);
            this.Controls.Add(this.btnUrunIcerikAdet);
            this.Name = "FrmRapor";
            this.Text = "Raporlar";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUrunIcerikAdet;
        private System.Windows.Forms.Button btnIcerikKullananUrunler;
        private System.Windows.Forms.Button btnKullaniciUrunler;
        private System.Windows.Forms.Button btnBekleyenOnay;
        private System.Windows.Forms.Button btnIcerikKaraListeSayi;
        private System.Windows.Forms.Button btnRiskliUrunler;
        private System.Windows.Forms.Button btnFavoriUrunler;
        private System.Windows.Forms.Button btnAlerjenUrunler;
        private System.Windows.Forms.Button tnEnAzRiskUrun;
        private System.Windows.Forms.Button btnRiskliUrunKullanici;
        private System.Windows.Forms.Button btnKullanıcıEnCokUrun;
        private System.Windows.Forms.Button btnEnAzMaddeUrun;
        private System.Windows.Forms.Button btnAylikFavoriUrunler;
        private System.Windows.Forms.Button btnKullaniciFavoriSayi;
        private System.Windows.Forms.Button btnKullaniciTipSayi;
        private System.Windows.Forms.Button btnFavoriUrunlerIlk3;
    }
}