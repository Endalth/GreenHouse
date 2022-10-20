namespace GreenHouseFull.UI.Admin
{
    partial class FrmKullaniciFavoriUrunAdmin
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listList = new System.Windows.Forms.ListBox();
            this.listKullanici = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listUrun = new System.Windows.Forms.ListBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.cbxUrun = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Kullanıcı Listesi Seçiniz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Kullanıcı Seçiniz";
            // 
            // listList
            // 
            this.listList.FormattingEnabled = true;
            this.listList.Location = new System.Drawing.Point(175, 33);
            this.listList.Name = "listList";
            this.listList.Size = new System.Drawing.Size(141, 316);
            this.listList.TabIndex = 5;
            this.listList.SelectedIndexChanged += new System.EventHandler(this.listList_SelectedIndexChanged);
            // 
            // listKullanici
            // 
            this.listKullanici.FormattingEnabled = true;
            this.listKullanici.Location = new System.Drawing.Point(12, 33);
            this.listKullanici.Name = "listKullanici";
            this.listKullanici.Size = new System.Drawing.Size(141, 316);
            this.listKullanici.TabIndex = 4;
            this.listKullanici.SelectedIndexChanged += new System.EventHandler(this.listKullanici_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Listedeki Ürünler";
            // 
            // listUrun
            // 
            this.listUrun.FormattingEnabled = true;
            this.listUrun.Location = new System.Drawing.Point(341, 33);
            this.listUrun.Name = "listUrun";
            this.listUrun.Size = new System.Drawing.Size(141, 316);
            this.listUrun.TabIndex = 8;
            this.listUrun.SelectedIndexChanged += new System.EventHandler(this.listUrun_SelectedIndexChanged);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(584, 265);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(92, 49);
            this.btnSil.TabIndex = 10;
            this.btnSil.Text = "Seçili Ürünü Listeden Kaldır";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(584, 193);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(92, 49);
            this.btnEkle.TabIndex = 11;
            this.btnEkle.Text = "Seçili Listeye Ürün Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // cbxUrun
            // 
            this.cbxUrun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUrun.FormattingEnabled = true;
            this.cbxUrun.Location = new System.Drawing.Point(553, 102);
            this.cbxUrun.Name = "cbxUrun";
            this.cbxUrun.Size = new System.Drawing.Size(159, 21);
            this.cbxUrun.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(550, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Eklemek için ürün seçiniz";
            // 
            // FrmKullaniciFavoriUrunAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 373);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxUrun);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listUrun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listList);
            this.Controls.Add(this.listKullanici);
            this.Name = "FrmKullaniciFavoriUrunAdmin";
            this.Text = "Kullanıcı Favori Ürün Admin İşlemleri";
            this.Load += new System.EventHandler(this.FrmKullaniciFavoriUrunAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listList;
        private System.Windows.Forms.ListBox listKullanici;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listUrun;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.ComboBox cbxUrun;
        private System.Windows.Forms.Label label4;
    }
}