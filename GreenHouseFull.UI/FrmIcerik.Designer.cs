namespace GreenHouseFull.UI
{
    partial class FrmIcerik
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
            this.lblIcerikAdi = new System.Windows.Forms.Label();
            this.lblKaraListe = new System.Windows.Forms.Label();
            this.lblUsedInCount = new System.Windows.Forms.Label();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.btnKaraListeyeEkle = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIcerikAdi
            // 
            this.lblIcerikAdi.AutoSize = true;
            this.lblIcerikAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIcerikAdi.Location = new System.Drawing.Point(12, 72);
            this.lblIcerikAdi.Name = "lblIcerikAdi";
            this.lblIcerikAdi.Size = new System.Drawing.Size(65, 17);
            this.lblIcerikAdi.TabIndex = 0;
            this.lblIcerikAdi.Text = "İçerik Adı";
            // 
            // lblKaraListe
            // 
            this.lblKaraListe.AutoSize = true;
            this.lblKaraListe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKaraListe.Location = new System.Drawing.Point(12, 109);
            this.lblKaraListe.Name = "lblKaraListe";
            this.lblKaraListe.Size = new System.Drawing.Size(230, 13);
            this.lblKaraListe.TabIndex = 1;
            this.lblKaraListe.Text = "Bu içerik kara listenizde yer almaktadır.";
            // 
            // lblUsedInCount
            // 
            this.lblUsedInCount.AutoSize = true;
            this.lblUsedInCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsedInCount.Location = new System.Drawing.Point(12, 143);
            this.lblUsedInCount.Name = "lblUsedInCount";
            this.lblUsedInCount.Size = new System.Drawing.Size(162, 13);
            this.lblUsedInCount.TabIndex = 2;
            this.lblUsedInCount.Text = "Bu içeriği kullanan ürünlerin adeti";
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Location = new System.Drawing.Point(12, 184);
            this.lblAciklama.MaximumSize = new System.Drawing.Size(280, 0);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(50, 13);
            this.lblAciklama.TabIndex = 3;
            this.lblAciklama.Text = "Açıklama";
            // 
            // btnKaraListeyeEkle
            // 
            this.btnKaraListeyeEkle.Location = new System.Drawing.Point(234, 12);
            this.btnKaraListeyeEkle.Name = "btnKaraListeyeEkle";
            this.btnKaraListeyeEkle.Size = new System.Drawing.Size(75, 39);
            this.btnKaraListeyeEkle.TabIndex = 4;
            this.btnKaraListeyeEkle.Text = "Kara Listeye Ekle";
            this.btnKaraListeyeEkle.UseVisualStyleBackColor = true;
            this.btnKaraListeyeEkle.Click += new System.EventHandler(this.btnKaraListeyeEkle_Click);
            // 
            // btnGoBack
            // 
            this.btnGoBack.AutoSize = true;
            this.btnGoBack.Location = new System.Drawing.Point(15, 12);
            this.btnGoBack.MaximumSize = new System.Drawing.Size(139, 57);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(59, 39);
            this.btnGoBack.TabIndex = 5;
            this.btnGoBack.Text = "Geri Dön";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // FrmIcerik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 412);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnKaraListeyeEkle);
            this.Controls.Add(this.lblAciklama);
            this.Controls.Add(this.lblUsedInCount);
            this.Controls.Add(this.lblKaraListe);
            this.Controls.Add(this.lblIcerikAdi);
            this.Name = "FrmIcerik";
            this.Text = "İçerik";
            this.Load += new System.EventHandler(this.FrmIcerik_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIcerikAdi;
        private System.Windows.Forms.Label lblKaraListe;
        private System.Windows.Forms.Label lblUsedInCount;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.Button btnKaraListeyeEkle;
        private System.Windows.Forms.Button btnGoBack;
    }
}