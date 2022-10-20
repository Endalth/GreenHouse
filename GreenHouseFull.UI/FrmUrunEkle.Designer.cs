namespace GreenHouseFull.UI
{
    partial class FrmUrunEkle
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
            this.btnSend = new System.Windows.Forms.Button();
            this.checkBShowUser = new System.Windows.Forms.CheckBox();
            this.btnIcerikSec = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbKategori = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUretici = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mtxtBarkod = new System.Windows.Forms.MaskedTextBox();
            this.btnOnYuzSec = new System.Windows.Forms.Button();
            this.btnArkaYuzSec = new System.Windows.Forms.Button();
            this.clbxUrunIcerik = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(404, 238);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(107, 37);
            this.btnSend.TabIndex = 31;
            this.btnSend.Text = "Gönder";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // checkBShowUser
            // 
            this.checkBShowUser.Checked = true;
            this.checkBShowUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBShowUser.Location = new System.Drawing.Point(290, 196);
            this.checkBShowUser.MaximumSize = new System.Drawing.Size(250, 0);
            this.checkBShowUser.Name = "checkBShowUser";
            this.checkBShowUser.Size = new System.Drawing.Size(221, 0);
            this.checkBShowUser.TabIndex = 30;
            this.checkBShowUser.Text = "Ürün sayfasında kullanıcı adımın gösterilmesini kabul ediyorum.";
            this.checkBShowUser.UseVisualStyleBackColor = true;
            // 
            // btnIcerikSec
            // 
            this.btnIcerikSec.Location = new System.Drawing.Point(300, 127);
            this.btnIcerikSec.Name = "btnIcerikSec";
            this.btnIcerikSec.Size = new System.Drawing.Size(64, 52);
            this.btnIcerikSec.TabIndex = 29;
            this.btnIcerikSec.Text = "İçerik Resim Seç";
            this.btnIcerikSec.UseVisualStyleBackColor = true;
            this.btnIcerikSec.Click += new System.EventHandler(this.btnIcerikSec_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Ürün İçeriği Seçiniz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Kategori";
            // 
            // cbKategori
            // 
            this.cbKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKategori.FormattingEnabled = true;
            this.cbKategori.Location = new System.Drawing.Point(290, 83);
            this.cbKategori.Name = "cbKategori";
            this.cbKategori.Size = new System.Drawing.Size(222, 21);
            this.cbKategori.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Ürün Adı";
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Location = new System.Drawing.Point(22, 83);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(221, 20);
            this.txtUrunAdi.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Üretici";
            // 
            // cbUretici
            // 
            this.cbUretici.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUretici.FormattingEnabled = true;
            this.cbUretici.Location = new System.Drawing.Point(290, 28);
            this.cbUretici.Name = "cbUretici";
            this.cbUretici.Size = new System.Drawing.Size(222, 21);
            this.cbUretici.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Barkod";
            // 
            // mtxtBarkod
            // 
            this.mtxtBarkod.Location = new System.Drawing.Point(22, 28);
            this.mtxtBarkod.Mask = "00000000-0000-0000-0000-000000000000";
            this.mtxtBarkod.Name = "mtxtBarkod";
            this.mtxtBarkod.Size = new System.Drawing.Size(222, 20);
            this.mtxtBarkod.TabIndex = 19;
            // 
            // btnOnYuzSec
            // 
            this.btnOnYuzSec.Location = new System.Drawing.Point(370, 127);
            this.btnOnYuzSec.Name = "btnOnYuzSec";
            this.btnOnYuzSec.Size = new System.Drawing.Size(64, 52);
            this.btnOnYuzSec.TabIndex = 32;
            this.btnOnYuzSec.Text = "Ön Yüz Resim Seç";
            this.btnOnYuzSec.UseVisualStyleBackColor = true;
            this.btnOnYuzSec.Click += new System.EventHandler(this.btnOnYuzSec_Click);
            // 
            // btnArkaYuzSec
            // 
            this.btnArkaYuzSec.Location = new System.Drawing.Point(440, 127);
            this.btnArkaYuzSec.Name = "btnArkaYuzSec";
            this.btnArkaYuzSec.Size = new System.Drawing.Size(64, 52);
            this.btnArkaYuzSec.TabIndex = 33;
            this.btnArkaYuzSec.Text = "Arka Yüz Resim Seç";
            this.btnArkaYuzSec.UseVisualStyleBackColor = true;
            this.btnArkaYuzSec.Click += new System.EventHandler(this.btnArkaYuzSec_Click);
            // 
            // clbxUrunIcerik
            // 
            this.clbxUrunIcerik.CheckOnClick = true;
            this.clbxUrunIcerik.FormattingEnabled = true;
            this.clbxUrunIcerik.Location = new System.Drawing.Point(22, 137);
            this.clbxUrunIcerik.Name = "clbxUrunIcerik";
            this.clbxUrunIcerik.Size = new System.Drawing.Size(221, 184);
            this.clbxUrunIcerik.TabIndex = 35;
            // 
            // FrmUrunEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 335);
            this.Controls.Add(this.clbxUrunIcerik);
            this.Controls.Add(this.btnArkaYuzSec);
            this.Controls.Add(this.btnOnYuzSec);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.checkBShowUser);
            this.Controls.Add(this.btnIcerikSec);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbKategori);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUrunAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbUretici);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtxtBarkod);
            this.Name = "FrmUrunEkle";
            this.Text = "Ürün Ekleme";
            this.Load += new System.EventHandler(this.FrmUrunEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.CheckBox checkBShowUser;
        private System.Windows.Forms.Button btnIcerikSec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbKategori;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbUretici;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtxtBarkod;
        private System.Windows.Forms.Button btnOnYuzSec;
        private System.Windows.Forms.Button btnArkaYuzSec;
        private System.Windows.Forms.CheckedListBox clbxUrunIcerik;
    }
}