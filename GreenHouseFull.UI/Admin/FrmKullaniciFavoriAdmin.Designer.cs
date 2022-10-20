namespace GreenHouseFull.UI.Admin
{
    partial class FrmKullaniciFavoriAdmin
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
            this.listKullanici = new System.Windows.Forms.ListBox();
            this.listList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtListeAdi = new System.Windows.Forms.TextBox();
            this.btnGonder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listKullanici
            // 
            this.listKullanici.FormattingEnabled = true;
            this.listKullanici.Location = new System.Drawing.Point(15, 53);
            this.listKullanici.Name = "listKullanici";
            this.listKullanici.Size = new System.Drawing.Size(141, 316);
            this.listKullanici.TabIndex = 0;
            this.listKullanici.SelectedIndexChanged += new System.EventHandler(this.listKullanici_SelectedIndexChanged);
            // 
            // listList
            // 
            this.listList.FormattingEnabled = true;
            this.listList.Location = new System.Drawing.Point(190, 53);
            this.listList.Name = "listList";
            this.listList.Size = new System.Drawing.Size(141, 316);
            this.listList.TabIndex = 1;
            this.listList.SelectedIndexChanged += new System.EventHandler(this.listList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kullanıcı Seçiniz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Liste Seçiniz";
            // 
            // txtListeAdi
            // 
            this.txtListeAdi.Location = new System.Drawing.Point(386, 124);
            this.txtListeAdi.Name = "txtListeAdi";
            this.txtListeAdi.Size = new System.Drawing.Size(159, 20);
            this.txtListeAdi.TabIndex = 4;
            // 
            // btnGonder
            // 
            this.btnGonder.Location = new System.Drawing.Point(413, 165);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(98, 23);
            this.btnGonder.TabIndex = 5;
            this.btnGonder.Text = "Liste Ekle";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Liste Adı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(565, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sadece kullanıcı seçerek liste ekleyebilir yada kullanıcı ve liste seçerek liste " +
    "adını güncelleyebilir veya listeyi silebilirsiniz.";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(413, 213);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(98, 23);
            this.btnSil.TabIndex = 8;
            this.btnSil.Text = "Seçileni Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // FrmKullaniciFavoriAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 397);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.txtListeAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listList);
            this.Controls.Add(this.listKullanici);
            this.Name = "FrmKullaniciFavoriAdmin";
            this.Text = "Kullanıcı Favori Liste Admin İşlemleri";
            this.Load += new System.EventHandler(this.FrmKullaniciFavoriAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listKullanici;
        private System.Windows.Forms.ListBox listList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtListeAdi;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSil;
    }
}