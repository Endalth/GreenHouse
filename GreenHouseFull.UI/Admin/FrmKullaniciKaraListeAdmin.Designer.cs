namespace GreenHouseFull.UI.Admin
{
    partial class FrmKullaniciKaraListeAdmin
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
            this.listKaraliste = new System.Windows.Forms.ListBox();
            this.listKullanici = new System.Windows.Forms.ListBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGonder = new System.Windows.Forms.Button();
            this.cbxIcerik = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Kara Listedeki İçerikler";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Kullanıcı Seçiniz";
            // 
            // listKaraliste
            // 
            this.listKaraliste.FormattingEnabled = true;
            this.listKaraliste.Location = new System.Drawing.Point(190, 82);
            this.listKaraliste.Name = "listKaraliste";
            this.listKaraliste.Size = new System.Drawing.Size(141, 316);
            this.listKaraliste.TabIndex = 5;
            this.listKaraliste.SelectedIndexChanged += new System.EventHandler(this.listKaraliste_SelectedIndexChanged);
            // 
            // listKullanici
            // 
            this.listKullanici.FormattingEnabled = true;
            this.listKullanici.Location = new System.Drawing.Point(15, 82);
            this.listKullanici.Name = "listKullanici";
            this.listKullanici.Size = new System.Drawing.Size(141, 316);
            this.listKullanici.TabIndex = 4;
            this.listKullanici.SelectedIndexChanged += new System.EventHandler(this.listKullanici_SelectedIndexChanged);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(406, 267);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(129, 44);
            this.btnSil.TabIndex = 12;
            this.btnSil.Text = "Seçilen İçeriği Kara Listeden Kaldır";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Eklemek için ürün içeriği seçiniz.";
            // 
            // btnGonder
            // 
            this.btnGonder.Location = new System.Drawing.Point(406, 205);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(129, 42);
            this.btnGonder.TabIndex = 10;
            this.btnGonder.Text = "İçeriği Kara Listeye Ekle";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // cbxIcerik
            // 
            this.cbxIcerik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIcerik.FormattingEnabled = true;
            this.cbxIcerik.Location = new System.Drawing.Point(383, 164);
            this.cbxIcerik.Name = "cbxIcerik";
            this.cbxIcerik.Size = new System.Drawing.Size(182, 21);
            this.cbxIcerik.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(617, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Kullanıcı kara listesine ekleme yapmak için kullanıcı seçiniz. Listeden içerik ka" +
    "ldırmak için Kara Listedeki İçeriklerden içerik seçiniz.";
            // 
            // FrmKullaniciKaraListeAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 412);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxIcerik);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listKaraliste);
            this.Controls.Add(this.listKullanici);
            this.Name = "FrmKullaniciKaraListeAdmin";
            this.Text = "Kullanıcı Kara Liste Admin İşlemleri";
            this.Load += new System.EventHandler(this.FrmKullaniciKaraListeAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listKaraliste;
        private System.Windows.Forms.ListBox listKullanici;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.ComboBox cbxIcerik;
        private System.Windows.Forms.Label label4;
    }
}