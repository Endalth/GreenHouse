namespace GreenHouseFull.UI
{
    partial class FrmProfil
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
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRegisterDate = new System.Windows.Forms.Label();
            this.lblUrunSayisi = new System.Windows.Forms.Label();
            this.btnPremium = new System.Windows.Forms.Button();
            this.btnChangeEmail = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnCleanHistory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(76, 22);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // lblRegisterDate
            // 
            this.lblRegisterDate.AutoSize = true;
            this.lblRegisterDate.Location = new System.Drawing.Point(27, 45);
            this.lblRegisterDate.Name = "lblRegisterDate";
            this.lblRegisterDate.Size = new System.Drawing.Size(92, 13);
            this.lblRegisterDate.TabIndex = 1;
            this.lblRegisterDate.Text = "Kayıt Olma Tarihi: ";
            // 
            // lblUrunSayisi
            // 
            this.lblUrunSayisi.AutoSize = true;
            this.lblUrunSayisi.Location = new System.Drawing.Point(29, 70);
            this.lblUrunSayisi.Name = "lblUrunSayisi";
            this.lblUrunSayisi.Size = new System.Drawing.Size(102, 13);
            this.lblUrunSayisi.TabIndex = 2;
            this.lblUrunSayisi.Text = "Eklediği ürün sayısı: ";
            this.lblUrunSayisi.Click += new System.EventHandler(this.lblUrunSayisi_Click);
            // 
            // btnPremium
            // 
            this.btnPremium.Location = new System.Drawing.Point(30, 107);
            this.btnPremium.Name = "btnPremium";
            this.btnPremium.Size = new System.Drawing.Size(148, 23);
            this.btnPremium.TabIndex = 3;
            this.btnPremium.Text = "Premium Üye Ol";
            this.btnPremium.UseVisualStyleBackColor = true;
            this.btnPremium.Click += new System.EventHandler(this.btnPremium_Click);
            // 
            // btnChangeEmail
            // 
            this.btnChangeEmail.Location = new System.Drawing.Point(30, 136);
            this.btnChangeEmail.Name = "btnChangeEmail";
            this.btnChangeEmail.Size = new System.Drawing.Size(148, 23);
            this.btnChangeEmail.TabIndex = 4;
            this.btnChangeEmail.Text = "E-posta Değiştir";
            this.btnChangeEmail.UseVisualStyleBackColor = true;
            this.btnChangeEmail.Click += new System.EventHandler(this.btnChangeEmail_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(30, 165);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(148, 23);
            this.btnChangePassword.TabIndex = 5;
            this.btnChangePassword.Text = "Şifre Değiştir";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnCleanHistory
            // 
            this.btnCleanHistory.Location = new System.Drawing.Point(30, 194);
            this.btnCleanHistory.Name = "btnCleanHistory";
            this.btnCleanHistory.Size = new System.Drawing.Size(148, 23);
            this.btnCleanHistory.TabIndex = 6;
            this.btnCleanHistory.Text = "Arama Geçmişini Temizle";
            this.btnCleanHistory.UseVisualStyleBackColor = true;
            this.btnCleanHistory.Click += new System.EventHandler(this.btnCleanHistory_Click);
            // 
            // FrmProfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 230);
            this.Controls.Add(this.btnCleanHistory);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnChangeEmail);
            this.Controls.Add(this.btnPremium);
            this.Controls.Add(this.lblUrunSayisi);
            this.Controls.Add(this.lblRegisterDate);
            this.Controls.Add(this.lblUsername);
            this.Name = "FrmProfil";
            this.Text = "Profil";
            this.Load += new System.EventHandler(this.FrmProfil_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRegisterDate;
        private System.Windows.Forms.Label lblUrunSayisi;
        private System.Windows.Forms.Button btnPremium;
        private System.Windows.Forms.Button btnChangeEmail;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnCleanHistory;
    }
}