namespace GreenHouseFull.UI
{
    partial class FrmKullaniciUrunList
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
            this.txtTakip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBUrun
            // 
            this.listBUrun.FormattingEnabled = true;
            this.listBUrun.Location = new System.Drawing.Point(12, 40);
            this.listBUrun.Name = "listBUrun";
            this.listBUrun.Size = new System.Drawing.Size(214, 329);
            this.listBUrun.TabIndex = 0;
            this.listBUrun.SelectedIndexChanged += new System.EventHandler(this.listBUrun_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Eklediğiniz ürünler";
            // 
            // txtTakip
            // 
            this.txtTakip.Location = new System.Drawing.Point(265, 89);
            this.txtTakip.Name = "txtTakip";
            this.txtTakip.ReadOnly = true;
            this.txtTakip.Size = new System.Drawing.Size(245, 20);
            this.txtTakip.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Takip Numarası";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Onay Durumu Açıklama";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(265, 154);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.ReadOnly = true;
            this.txtAciklama.Size = new System.Drawing.Size(245, 141);
            this.txtAciklama.TabIndex = 4;
            // 
            // FrmKullaniciUrunList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 387);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTakip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBUrun);
            this.Name = "FrmKullaniciUrunList";
            this.Text = "Eklediğiniz Ürünler";
            this.Load += new System.EventHandler(this.FrmKullaniciUrunList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBUrun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTakip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAciklama;
    }
}