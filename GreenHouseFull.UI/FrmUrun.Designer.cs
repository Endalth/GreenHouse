namespace GreenHouseFull.UI
{
    partial class FrmUrun
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
            this.picBox = new System.Windows.Forms.PictureBox();
            this.lblUrunAdi = new System.Windows.Forms.Label();
            this.lblUretici = new System.Windows.Forms.Label();
            this.btnOnResim = new System.Windows.Forms.Button();
            this.btnArkaResim = new System.Windows.Forms.Button();
            this.lblKategori = new System.Windows.Forms.Label();
            this.lblKara = new System.Windows.Forms.Label();
            this.lblRisk = new System.Windows.Forms.Label();
            this.lblOrtaRisk = new System.Windows.Forms.Label();
            this.lblTemiz = new System.Windows.Forms.Label();
            this.lblAzRisk = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listVBilesen = new System.Windows.Forms.ListView();
            this.lblUrunuEkleyen = new System.Windows.Forms.Label();
            this.btnDuzeltmeTalep = new System.Windows.Forms.Button();
            this.btnFavoriyeEkle = new System.Windows.Forms.Button();
            this.btnOrdering = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(12, 12);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(113, 134);
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // lblUrunAdi
            // 
            this.lblUrunAdi.AutoSize = true;
            this.lblUrunAdi.Location = new System.Drawing.Point(153, 72);
            this.lblUrunAdi.Name = "lblUrunAdi";
            this.lblUrunAdi.Size = new System.Drawing.Size(48, 13);
            this.lblUrunAdi.TabIndex = 1;
            this.lblUrunAdi.Text = "Ürün Adı";
            // 
            // lblUretici
            // 
            this.lblUretici.AutoSize = true;
            this.lblUretici.Location = new System.Drawing.Point(153, 48);
            this.lblUretici.Name = "lblUretici";
            this.lblUretici.Size = new System.Drawing.Size(37, 13);
            this.lblUretici.TabIndex = 2;
            this.lblUretici.Text = "Üretici";
            // 
            // btnOnResim
            // 
            this.btnOnResim.Location = new System.Drawing.Point(12, 164);
            this.btnOnResim.Name = "btnOnResim";
            this.btnOnResim.Size = new System.Drawing.Size(49, 39);
            this.btnOnResim.TabIndex = 3;
            this.btnOnResim.Text = "Ön Resim";
            this.btnOnResim.UseVisualStyleBackColor = true;
            this.btnOnResim.Click += new System.EventHandler(this.btnOnResim_Click);
            // 
            // btnArkaResim
            // 
            this.btnArkaResim.Location = new System.Drawing.Point(76, 164);
            this.btnArkaResim.Name = "btnArkaResim";
            this.btnArkaResim.Size = new System.Drawing.Size(49, 39);
            this.btnArkaResim.TabIndex = 4;
            this.btnArkaResim.Text = "Arka Resim";
            this.btnArkaResim.UseVisualStyleBackColor = true;
            this.btnArkaResim.Click += new System.EventHandler(this.btnArkaResim_Click);
            // 
            // lblKategori
            // 
            this.lblKategori.AutoSize = true;
            this.lblKategori.Location = new System.Drawing.Point(153, 23);
            this.lblKategori.Name = "lblKategori";
            this.lblKategori.Size = new System.Drawing.Size(46, 13);
            this.lblKategori.TabIndex = 5;
            this.lblKategori.Text = "Kategori";
            // 
            // lblKara
            // 
            this.lblKara.AutoSize = true;
            this.lblKara.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKara.Location = new System.Drawing.Point(153, 101);
            this.lblKara.Name = "lblKara";
            this.lblKara.Size = new System.Drawing.Size(145, 13);
            this.lblKara.TabIndex = 6;
            this.lblKara.Text = "Kara listedeki içerikler   ";
            // 
            // lblRisk
            // 
            this.lblRisk.AutoSize = true;
            this.lblRisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRisk.ForeColor = System.Drawing.Color.Red;
            this.lblRisk.Location = new System.Drawing.Point(153, 123);
            this.lblRisk.Name = "lblRisk";
            this.lblRisk.Size = new System.Drawing.Size(148, 13);
            this.lblRisk.TabIndex = 7;
            this.lblRisk.Text = "Riskli İçerikler               ";
            // 
            // lblOrtaRisk
            // 
            this.lblOrtaRisk.AutoSize = true;
            this.lblOrtaRisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrtaRisk.ForeColor = System.Drawing.Color.Coral;
            this.lblOrtaRisk.Location = new System.Drawing.Point(153, 145);
            this.lblOrtaRisk.Name = "lblOrtaRisk";
            this.lblOrtaRisk.Size = new System.Drawing.Size(146, 13);
            this.lblOrtaRisk.TabIndex = 8;
            this.lblOrtaRisk.Text = "Orta riskli içerikler         ";
            // 
            // lblTemiz
            // 
            this.lblTemiz.AutoSize = true;
            this.lblTemiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemiz.ForeColor = System.Drawing.Color.OliveDrab;
            this.lblTemiz.Location = new System.Drawing.Point(153, 186);
            this.lblTemiz.Name = "lblTemiz";
            this.lblTemiz.Size = new System.Drawing.Size(145, 13);
            this.lblTemiz.TabIndex = 10;
            this.lblTemiz.Text = "Temiz içerikler              ";
            // 
            // lblAzRisk
            // 
            this.lblAzRisk.AutoSize = true;
            this.lblAzRisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAzRisk.ForeColor = System.Drawing.Color.Yellow;
            this.lblAzRisk.Location = new System.Drawing.Point(153, 164);
            this.lblAzRisk.Name = "lblAzRisk";
            this.lblAzRisk.Size = new System.Drawing.Size(148, 13);
            this.lblAzRisk.TabIndex = 9;
            this.lblAzRisk.Text = "Az riskli içerikler            ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ürün Bileşimi";
            // 
            // listVBilesen
            // 
            this.listVBilesen.HideSelection = false;
            this.listVBilesen.Location = new System.Drawing.Point(12, 295);
            this.listVBilesen.MultiSelect = false;
            this.listVBilesen.Name = "listVBilesen";
            this.listVBilesen.Size = new System.Drawing.Size(348, 195);
            this.listVBilesen.TabIndex = 13;
            this.listVBilesen.UseCompatibleStateImageBehavior = false;
            this.listVBilesen.View = System.Windows.Forms.View.List;
            this.listVBilesen.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listVBilesen_MouseDoubleClick);
            // 
            // lblUrunuEkleyen
            // 
            this.lblUrunuEkleyen.AutoSize = true;
            this.lblUrunuEkleyen.Location = new System.Drawing.Point(155, 214);
            this.lblUrunuEkleyen.Name = "lblUrunuEkleyen";
            this.lblUrunuEkleyen.Size = new System.Drawing.Size(83, 13);
            this.lblUrunuEkleyen.TabIndex = 14;
            this.lblUrunuEkleyen.Text = "Ürünü Ekleyen: ";
            // 
            // btnDuzeltmeTalep
            // 
            this.btnDuzeltmeTalep.Location = new System.Drawing.Point(12, 513);
            this.btnDuzeltmeTalep.Name = "btnDuzeltmeTalep";
            this.btnDuzeltmeTalep.Size = new System.Drawing.Size(75, 35);
            this.btnDuzeltmeTalep.TabIndex = 15;
            this.btnDuzeltmeTalep.Text = "Duzeltme Talebi Aç";
            this.btnDuzeltmeTalep.UseVisualStyleBackColor = true;
            this.btnDuzeltmeTalep.Click += new System.EventHandler(this.btnDuzeltmeTalep_Click);
            // 
            // btnFavoriyeEkle
            // 
            this.btnFavoriyeEkle.Location = new System.Drawing.Point(285, 513);
            this.btnFavoriyeEkle.Name = "btnFavoriyeEkle";
            this.btnFavoriyeEkle.Size = new System.Drawing.Size(75, 35);
            this.btnFavoriyeEkle.TabIndex = 16;
            this.btnFavoriyeEkle.Text = "Favoriye Ekle";
            this.btnFavoriyeEkle.UseVisualStyleBackColor = true;
            this.btnFavoriyeEkle.Click += new System.EventHandler(this.btnFavoriyeEkle_Click);
            // 
            // btnOrdering
            // 
            this.btnOrdering.Location = new System.Drawing.Point(198, 265);
            this.btnOrdering.Name = "btnOrdering";
            this.btnOrdering.Size = new System.Drawing.Size(162, 24);
            this.btnOrdering.TabIndex = 17;
            this.btnOrdering.Text = "Alfabetik Sıralama";
            this.btnOrdering.UseVisualStyleBackColor = true;
            this.btnOrdering.Click += new System.EventHandler(this.btnOrdering_Click);
            // 
            // FrmUrun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 563);
            this.Controls.Add(this.btnOrdering);
            this.Controls.Add(this.btnFavoriyeEkle);
            this.Controls.Add(this.btnDuzeltmeTalep);
            this.Controls.Add(this.lblUrunuEkleyen);
            this.Controls.Add(this.listVBilesen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTemiz);
            this.Controls.Add(this.lblAzRisk);
            this.Controls.Add(this.lblOrtaRisk);
            this.Controls.Add(this.lblRisk);
            this.Controls.Add(this.lblKara);
            this.Controls.Add(this.lblKategori);
            this.Controls.Add(this.btnArkaResim);
            this.Controls.Add(this.btnOnResim);
            this.Controls.Add(this.lblUretici);
            this.Controls.Add(this.lblUrunAdi);
            this.Controls.Add(this.picBox);
            this.Name = "FrmUrun";
            this.Text = "Ürün";
            this.Load += new System.EventHandler(this.FrmUrun_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label lblUrunAdi;
        private System.Windows.Forms.Label lblUretici;
        private System.Windows.Forms.Button btnOnResim;
        private System.Windows.Forms.Button btnArkaResim;
        private System.Windows.Forms.Label lblKategori;
        private System.Windows.Forms.Label lblKara;
        private System.Windows.Forms.Label lblRisk;
        private System.Windows.Forms.Label lblOrtaRisk;
        private System.Windows.Forms.Label lblTemiz;
        private System.Windows.Forms.Label lblAzRisk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listVBilesen;
        private System.Windows.Forms.Label lblUrunuEkleyen;
        private System.Windows.Forms.Button btnDuzeltmeTalep;
        private System.Windows.Forms.Button btnFavoriyeEkle;
        private System.Windows.Forms.Button btnOrdering;
    }
}