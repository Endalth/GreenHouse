namespace GreenHouseFull.UI.Admin
{
    partial class FrmKullaniciAdmin
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
            this.listBKullanici = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.btnGonder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassRepeat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnNewPass = new System.Windows.Forms.Button();
            this.cbxRol = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPassNewUser = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBKullanici
            // 
            this.listBKullanici.FormattingEnabled = true;
            this.listBKullanici.Location = new System.Drawing.Point(12, 70);
            this.listBKullanici.Name = "listBKullanici";
            this.listBKullanici.Size = new System.Drawing.Size(243, 368);
            this.listBKullanici.TabIndex = 0;
            this.listBKullanici.SelectedIndexChanged += new System.EventHandler(this.listBKullanici_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 31);
            this.label2.MaximumSize = new System.Drawing.Size(260, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Güncelleme veya Silme için listeden seçim yapınız. Seçimi iptal etmek için satıra" +
    " tekrar basabilirsiniz.";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(357, 291);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 23);
            this.btnSil.TabIndex = 9;
            this.btnSil.Text = "Seçileni Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(339, 70);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(145, 20);
            this.txtKullaniciAdi.TabIndex = 7;
            // 
            // btnGonder
            // 
            this.btnGonder.Location = new System.Drawing.Point(357, 262);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(100, 23);
            this.btnGonder.TabIndex = 6;
            this.btnGonder.Text = "Ekle";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(339, 166);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(145, 20);
            this.txtEmail.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Yeni Şifre Tekrar";
            // 
            // txtPassRepeat
            // 
            this.txtPassRepeat.Location = new System.Drawing.Point(273, 418);
            this.txtPassRepeat.Name = "txtPassRepeat";
            this.txtPassRepeat.PasswordChar = '*';
            this.txtPassRepeat.Size = new System.Drawing.Size(145, 20);
            this.txtPassRepeat.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 346);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Yeni Şifre";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(273, 362);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(145, 20);
            this.txtPass.TabIndex = 12;
            // 
            // btnNewPass
            // 
            this.btnNewPass.Location = new System.Drawing.Point(455, 369);
            this.btnNewPass.Name = "btnNewPass";
            this.btnNewPass.Size = new System.Drawing.Size(97, 46);
            this.btnNewPass.TabIndex = 16;
            this.btnNewPass.Text = "Seçili Kullanıcıya Yeni Şifre Ata";
            this.btnNewPass.UseVisualStyleBackColor = true;
            this.btnNewPass.Click += new System.EventHandler(this.btnNewPass_Click);
            // 
            // cbxRol
            // 
            this.cbxRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRol.FormattingEnabled = true;
            this.cbxRol.Location = new System.Drawing.Point(339, 217);
            this.cbxRol.Name = "cbxRol";
            this.cbxRol.Size = new System.Drawing.Size(145, 21);
            this.cbxRol.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(336, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Rol";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(336, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Şifre";
            // 
            // txtPassNewUser
            // 
            this.txtPassNewUser.Location = new System.Drawing.Point(339, 117);
            this.txtPassNewUser.Name = "txtPassNewUser";
            this.txtPassNewUser.PasswordChar = '*';
            this.txtPassNewUser.Size = new System.Drawing.Size(145, 20);
            this.txtPassNewUser.TabIndex = 19;
            // 
            // FrmKullaniciAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPassNewUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxRol);
            this.Controls.Add(this.btnNewPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPassRepeat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBKullanici);
            this.Name = "FrmKullaniciAdmin";
            this.Text = "Kullanıcı Admin İşlemleri";
            this.Load += new System.EventHandler(this.FrmKullaniciAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBKullanici;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassRepeat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnNewPass;
        private System.Windows.Forms.ComboBox cbxRol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPassNewUser;
    }
}