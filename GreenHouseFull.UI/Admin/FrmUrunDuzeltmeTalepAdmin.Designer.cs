namespace GreenHouseFull.UI.Admin
{
    partial class FrmUrunDuzeltmeTalepAdmin
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
            this.listBTalep = new System.Windows.Forms.ListBox();
            this.btnGonder = new System.Windows.Forms.Button();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.cbxOnayDurum = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOnayAciklama = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.btnKanitResimGor = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBTalep
            // 
            this.listBTalep.FormattingEnabled = true;
            this.listBTalep.Location = new System.Drawing.Point(21, 88);
            this.listBTalep.Name = "listBTalep";
            this.listBTalep.Size = new System.Drawing.Size(244, 316);
            this.listBTalep.TabIndex = 0;
            this.listBTalep.SelectedIndexChanged += new System.EventHandler(this.listBTalep_SelectedIndexChanged);
            // 
            // btnGonder
            // 
            this.btnGonder.Location = new System.Drawing.Point(317, 381);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(78, 23);
            this.btnGonder.TabIndex = 11;
            this.btnGonder.Text = "Güncelle";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(317, 102);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.ReadOnly = true;
            this.txtAciklama.Size = new System.Drawing.Size(213, 87);
            this.txtAciklama.TabIndex = 13;
            // 
            // cbxOnayDurum
            // 
            this.cbxOnayDurum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOnayDurum.FormattingEnabled = true;
            this.cbxOnayDurum.Location = new System.Drawing.Point(317, 227);
            this.cbxOnayDurum.Name = "cbxOnayDurum";
            this.cbxOnayDurum.Size = new System.Drawing.Size(138, 21);
            this.cbxOnayDurum.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Açıklama";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Onay Durum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 35);
            this.label3.MaximumSize = new System.Drawing.Size(260, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 39);
            this.label3.TabIndex = 17;
            this.label3.Text = "Talepleri durumunu güncellemek için aşağıdan seçim yapınız. Seçili talebe tekrar " +
    "basarak seçimi iptal edebilirsiniz.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Onay Açıklama";
            // 
            // txtOnayAciklama
            // 
            this.txtOnayAciklama.Location = new System.Drawing.Point(317, 272);
            this.txtOnayAciklama.Multiline = true;
            this.txtOnayAciklama.Name = "txtOnayAciklama";
            this.txtOnayAciklama.Size = new System.Drawing.Size(213, 87);
            this.txtOnayAciklama.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Ürün Adı";
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Location = new System.Drawing.Point(317, 51);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.ReadOnly = true;
            this.txtUrunAdi.Size = new System.Drawing.Size(213, 20);
            this.txtUrunAdi.TabIndex = 21;
            // 
            // btnKanitResimGor
            // 
            this.btnKanitResimGor.Location = new System.Drawing.Point(547, 102);
            this.btnKanitResimGor.Name = "btnKanitResimGor";
            this.btnKanitResimGor.Size = new System.Drawing.Size(76, 87);
            this.btnKanitResimGor.TabIndex = 22;
            this.btnKanitResimGor.Text = "Kanıt Resmini Gör";
            this.btnKanitResimGor.UseVisualStyleBackColor = true;
            this.btnKanitResimGor.Click += new System.EventHandler(this.btnKanitResimGor_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(452, 381);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(78, 23);
            this.btnSil.TabIndex = 23;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // FrmUrunDuzeltmeTalepAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 419);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKanitResimGor);
            this.Controls.Add(this.txtUrunAdi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOnayAciklama);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxOnayDurum);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.listBTalep);
            this.Name = "FrmUrunDuzeltmeTalepAdmin";
            this.Text = "Ürün Düzeltme Talep Admin İşlemleri";
            this.Load += new System.EventHandler(this.FrmUrunDuzeltmeTalepAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBTalep;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.ComboBox cbxOnayDurum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOnayAciklama;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.Button btnKanitResimGor;
        private System.Windows.Forms.Button btnSil;
    }
}