namespace GreenHouseFull.UI.Admin
{
    partial class FrmKullaniciGecmisAdmin
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
            this.listGecmis = new System.Windows.Forms.ListBox();
            this.listKullanici = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Kullanıcı Geçmişi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Kullanıcı Seçiniz";
            // 
            // listGecmis
            // 
            this.listGecmis.FormattingEnabled = true;
            this.listGecmis.Location = new System.Drawing.Point(200, 119);
            this.listGecmis.Name = "listGecmis";
            this.listGecmis.Size = new System.Drawing.Size(141, 316);
            this.listGecmis.TabIndex = 5;
            this.listGecmis.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listGecmis_MouseDoubleClick);
            // 
            // listKullanici
            // 
            this.listKullanici.FormattingEnabled = true;
            this.listKullanici.Location = new System.Drawing.Point(25, 119);
            this.listKullanici.Name = "listKullanici";
            this.listKullanici.Size = new System.Drawing.Size(141, 316);
            this.listKullanici.TabIndex = 4;
            this.listKullanici.SelectedIndexChanged += new System.EventHandler(this.listKullanici_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 25);
            this.label3.MaximumSize = new System.Drawing.Size(300, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 39);
            this.label3.TabIndex = 8;
            this.label3.Text = "Kullanıcı seçerek kullanıcı geçmişlerini görüntüleyebilirsiniz. Bir ürüne çift tı" +
    "klarsanız ürün sayfası açılacaktır. Ancak ürün sayfasındaki karaliste bilgisi ad" +
    "minin ayarlarına göredir.";
            // 
            // FrmKullaniciGecmisAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 449);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listGecmis);
            this.Controls.Add(this.listKullanici);
            this.Name = "FrmKullaniciGecmisAdmin";
            this.Text = "Kullanıcı Geçmişleri";
            this.Load += new System.EventHandler(this.FrmKullaniciGecmisAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listGecmis;
        private System.Windows.Forms.ListBox listKullanici;
        private System.Windows.Forms.Label label3;
    }
}