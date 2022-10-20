namespace GreenHouseFull.UI.Admin
{
    partial class FrmUrunAdmin
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
            this.listBUrun = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clbxUrunIcerik = new System.Windows.Forms.CheckedListBox();
            this.btnArkaYuzSec = new System.Windows.Forms.Button();
            this.btnOnYuzSec = new System.Windows.Forms.Button();
            this.btnGonder = new System.Windows.Forms.Button();
            this.checkBShowUser = new System.Windows.Forms.CheckBox();
            this.btnIcerikSec = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbKategori = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUretici = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mtxtBarkod = new System.Windows.Forms.MaskedTextBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.pbxOn = new System.Windows.Forms.PictureBox();
            this.pbxIcerik = new System.Windows.Forms.PictureBox();
            this.pbxArka = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEkleyen = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcerik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArka)).BeginInit();
            this.SuspendLayout();
            // 
            // listBUrun
            // 
            this.listBUrun.FormattingEnabled = true;
            this.listBUrun.Location = new System.Drawing.Point(12, 143);
            this.listBUrun.Name = "listBUrun";
            this.listBUrun.Size = new System.Drawing.Size(244, 368);
            this.listBUrun.TabIndex = 0;
            this.listBUrun.SelectedIndexChanged += new System.EventHandler(this.listBUrun_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 90);
            this.label1.MaximumSize = new System.Drawing.Size(260, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Güncelleme yada silme işlemi için listeden içerik seçiniz. Seçili içeriğin üstüne" +
    " tekrar basarak seçimi iptal edebilirsiniz.";
            // 
            // clbxUrunIcerik
            // 
            this.clbxUrunIcerik.CheckOnClick = true;
            this.clbxUrunIcerik.FormattingEnabled = true;
            this.clbxUrunIcerik.Location = new System.Drawing.Point(293, 218);
            this.clbxUrunIcerik.Name = "clbxUrunIcerik";
            this.clbxUrunIcerik.Size = new System.Drawing.Size(221, 184);
            this.clbxUrunIcerik.TabIndex = 50;
            // 
            // btnArkaYuzSec
            // 
            this.btnArkaYuzSec.Location = new System.Drawing.Point(696, 207);
            this.btnArkaYuzSec.Name = "btnArkaYuzSec";
            this.btnArkaYuzSec.Size = new System.Drawing.Size(64, 52);
            this.btnArkaYuzSec.TabIndex = 49;
            this.btnArkaYuzSec.Text = "Arka Yüz Resim Seç";
            this.btnArkaYuzSec.UseVisualStyleBackColor = true;
            this.btnArkaYuzSec.Click += new System.EventHandler(this.btnArkaYuzSec_Click);
            // 
            // btnOnYuzSec
            // 
            this.btnOnYuzSec.Location = new System.Drawing.Point(626, 207);
            this.btnOnYuzSec.Name = "btnOnYuzSec";
            this.btnOnYuzSec.Size = new System.Drawing.Size(64, 52);
            this.btnOnYuzSec.TabIndex = 48;
            this.btnOnYuzSec.Text = "Ön Yüz Resim Seç";
            this.btnOnYuzSec.UseVisualStyleBackColor = true;
            this.btnOnYuzSec.Click += new System.EventHandler(this.btnOnYuzSec_Click);
            // 
            // btnGonder
            // 
            this.btnGonder.Location = new System.Drawing.Point(293, 471);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(107, 37);
            this.btnGonder.TabIndex = 47;
            this.btnGonder.Text = "Ekle";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // checkBShowUser
            // 
            this.checkBShowUser.Checked = true;
            this.checkBShowUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBShowUser.Location = new System.Drawing.Point(292, 411);
            this.checkBShowUser.MaximumSize = new System.Drawing.Size(250, 0);
            this.checkBShowUser.Name = "checkBShowUser";
            this.checkBShowUser.Size = new System.Drawing.Size(222, 0);
            this.checkBShowUser.TabIndex = 46;
            this.checkBShowUser.Text = "Ürün sayfasında kullanıcı adımın gösterilmesini kabul ediyorum.";
            this.checkBShowUser.UseVisualStyleBackColor = true;
            // 
            // btnIcerikSec
            // 
            this.btnIcerikSec.Location = new System.Drawing.Point(556, 207);
            this.btnIcerikSec.Name = "btnIcerikSec";
            this.btnIcerikSec.Size = new System.Drawing.Size(64, 52);
            this.btnIcerikSec.TabIndex = 45;
            this.btnIcerikSec.Text = "İçerik Resim Seç";
            this.btnIcerikSec.UseVisualStyleBackColor = true;
            this.btnIcerikSec.Click += new System.EventHandler(this.btnIcerikSec_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Ürün İçeriği Seçiniz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(544, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Kategori";
            // 
            // cbKategori
            // 
            this.cbKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKategori.FormattingEnabled = true;
            this.cbKategori.Location = new System.Drawing.Point(547, 112);
            this.cbKategori.Name = "cbKategori";
            this.cbKategori.Size = new System.Drawing.Size(222, 21);
            this.cbKategori.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Ürün Adı";
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Location = new System.Drawing.Point(293, 164);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(221, 20);
            this.txtUrunAdi.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(544, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Üretici";
            // 
            // cbUretici
            // 
            this.cbUretici.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUretici.FormattingEnabled = true;
            this.cbUretici.Location = new System.Drawing.Point(547, 57);
            this.cbUretici.Name = "cbUretici";
            this.cbUretici.Size = new System.Drawing.Size(222, 21);
            this.cbUretici.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(290, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Barkod";
            // 
            // mtxtBarkod
            // 
            this.mtxtBarkod.Location = new System.Drawing.Point(293, 109);
            this.mtxtBarkod.Mask = "00000000-0000-0000-0000-000000000000";
            this.mtxtBarkod.Name = "mtxtBarkod";
            this.mtxtBarkod.Size = new System.Drawing.Size(222, 20);
            this.mtxtBarkod.TabIndex = 36;
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(408, 471);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(107, 37);
            this.btnSil.TabIndex = 51;
            this.btnSil.Text = "Seçileni Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // pbxOn
            // 
            this.pbxOn.Location = new System.Drawing.Point(679, 303);
            this.pbxOn.Name = "pbxOn";
            this.pbxOn.Size = new System.Drawing.Size(94, 102);
            this.pbxOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxOn.TabIndex = 53;
            this.pbxOn.TabStop = false;
            // 
            // pbxIcerik
            // 
            this.pbxIcerik.Location = new System.Drawing.Point(562, 303);
            this.pbxIcerik.Name = "pbxIcerik";
            this.pbxIcerik.Size = new System.Drawing.Size(94, 102);
            this.pbxIcerik.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxIcerik.TabIndex = 54;
            this.pbxIcerik.TabStop = false;
            // 
            // pbxArka
            // 
            this.pbxArka.Location = new System.Drawing.Point(615, 411);
            this.pbxArka.Name = "pbxArka";
            this.pbxArka.Size = new System.Drawing.Size(94, 102);
            this.pbxArka.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxArka.TabIndex = 55;
            this.pbxArka.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(290, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Ürünü Ekleyen Kullanıcı";
            // 
            // txtEkleyen
            // 
            this.txtEkleyen.Enabled = false;
            this.txtEkleyen.Location = new System.Drawing.Point(293, 57);
            this.txtEkleyen.Name = "txtEkleyen";
            this.txtEkleyen.Size = new System.Drawing.Size(222, 20);
            this.txtEkleyen.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(548, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 13);
            this.label8.TabIndex = 58;
            this.label8.Text = "Veritabanındaki Resimler";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(544, 164);
            this.label9.MaximumSize = new System.Drawing.Size(260, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(259, 39);
            this.label9.TabIndex = 59;
            this.label9.Text = "Güncelleme veya ekleme için aşağıdan resim seçiniz. Güncelleme için resim seçmezs" +
    "eniz veritabanındaki resimler oldukları gibi kalıcaktır.";
            // 
            // FrmUrunAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEkleyen);
            this.Controls.Add(this.pbxArka);
            this.Controls.Add(this.pbxIcerik);
            this.Controls.Add(this.pbxOn);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.clbxUrunIcerik);
            this.Controls.Add(this.btnArkaYuzSec);
            this.Controls.Add(this.btnOnYuzSec);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.checkBShowUser);
            this.Controls.Add(this.btnIcerikSec);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbKategori);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUrunAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbUretici);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mtxtBarkod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBUrun);
            this.Name = "FrmUrunAdmin";
            this.Text = "Ürün Admin İşlemleri";
            this.Load += new System.EventHandler(this.FrmUrunAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcerik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArka)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBUrun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox clbxUrunIcerik;
        private System.Windows.Forms.Button btnArkaYuzSec;
        private System.Windows.Forms.Button btnOnYuzSec;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.CheckBox checkBShowUser;
        private System.Windows.Forms.Button btnIcerikSec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbKategori;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbUretici;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mtxtBarkod;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.PictureBox pbxOn;
        private System.Windows.Forms.PictureBox pbxIcerik;
        private System.Windows.Forms.PictureBox pbxArka;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEkleyen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}