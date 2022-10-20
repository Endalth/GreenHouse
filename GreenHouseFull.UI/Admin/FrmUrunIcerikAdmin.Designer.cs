namespace GreenHouseFull.UI.Admin
{
    partial class FrmUrunIcerikAdmin
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
            this.listBIcerik = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIcerikAdi = new System.Windows.Forms.TextBox();
            this.cbxRiskSeviye = new System.Windows.Forms.ComboBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.btnGonder = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBIcerik
            // 
            this.listBIcerik.FormattingEnabled = true;
            this.listBIcerik.Location = new System.Drawing.Point(12, 108);
            this.listBIcerik.Name = "listBIcerik";
            this.listBIcerik.Size = new System.Drawing.Size(247, 329);
            this.listBIcerik.TabIndex = 1;
            this.listBIcerik.SelectedIndexChanged += new System.EventHandler(this.listBIcerik_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.MaximumSize = new System.Drawing.Size(260, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Güncelleme yada silme işlemi için listeden içerik seçiniz. Seçili içeriğin üstüne" +
    " tekrar basarak seçimi iptal edebilirsiniz.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 92);
            this.label2.MaximumSize = new System.Drawing.Size(260, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "İçerik Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 140);
            this.label3.MaximumSize = new System.Drawing.Size(260, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Açıklama";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 258);
            this.label4.MaximumSize = new System.Drawing.Size(260, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Risk Seviye";
            // 
            // txtIcerikAdi
            // 
            this.txtIcerikAdi.Location = new System.Drawing.Point(334, 108);
            this.txtIcerikAdi.Name = "txtIcerikAdi";
            this.txtIcerikAdi.Size = new System.Drawing.Size(145, 20);
            this.txtIcerikAdi.TabIndex = 6;
            // 
            // cbxRiskSeviye
            // 
            this.cbxRiskSeviye.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRiskSeviye.FormattingEnabled = true;
            this.cbxRiskSeviye.Location = new System.Drawing.Point(334, 274);
            this.cbxRiskSeviye.Name = "cbxRiskSeviye";
            this.cbxRiskSeviye.Size = new System.Drawing.Size(145, 21);
            this.cbxRiskSeviye.TabIndex = 7;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(332, 156);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(220, 86);
            this.txtAciklama.TabIndex = 8;
            // 
            // btnGonder
            // 
            this.btnGonder.Location = new System.Drawing.Point(352, 315);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(106, 23);
            this.btnGonder.TabIndex = 9;
            this.btnGonder.Text = "Ekle";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(353, 365);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(105, 23);
            this.btnSil.TabIndex = 10;
            this.btnSil.Text = "Seçileni Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // FrmUrunIcerikAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 447);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.cbxRiskSeviye);
            this.Controls.Add(this.txtIcerikAdi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBIcerik);
            this.Name = "FrmUrunIcerikAdmin";
            this.Text = "Ürün İçerik Admin İşlemleri";
            this.Load += new System.EventHandler(this.FrmUrunIcerikAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBIcerik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIcerikAdi;
        private System.Windows.Forms.ComboBox cbxRiskSeviye;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.Button btnSil;
    }
}