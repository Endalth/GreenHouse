namespace GreenHouseFull.UI
{
    partial class FrmUreticiAdmin
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
            this.listbxUretici = new System.Windows.Forms.ListBox();
            this.btnGonder = new System.Windows.Forms.Button();
            this.txtAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listbxUretici
            // 
            this.listbxUretici.FormattingEnabled = true;
            this.listbxUretici.Location = new System.Drawing.Point(12, 71);
            this.listbxUretici.Name = "listbxUretici";
            this.listbxUretici.Size = new System.Drawing.Size(240, 303);
            this.listbxUretici.TabIndex = 0;
            this.listbxUretici.SelectedIndexChanged += new System.EventHandler(this.listbxUretici_SelectedIndexChanged);
            // 
            // btnGonder
            // 
            this.btnGonder.Location = new System.Drawing.Point(318, 207);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(100, 23);
            this.btnGonder.TabIndex = 1;
            this.btnGonder.Text = "Ekle";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // txtAdi
            // 
            this.txtAdi.Location = new System.Drawing.Point(306, 167);
            this.txtAdi.Name = "txtAdi";
            this.txtAdi.Size = new System.Drawing.Size(145, 20);
            this.txtAdi.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Üretici Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.MaximumSize = new System.Drawing.Size(260, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Güncelleme veya Silme için listeden seçim yapınız. Seçimi iptal etmek için satıra" +
    " tekrar basabilirsiniz.";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(318, 265);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 23);
            this.btnSil.TabIndex = 5;
            this.btnSil.Text = "Seçileni Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // FrmUreticiAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 399);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAdi);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.listbxUretici);
            this.Name = "FrmUreticiAdmin";
            this.Text = "Üretici Admin İşlemleri";
            this.Load += new System.EventHandler(this.FrmUreticiAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listbxUretici;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.TextBox txtAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSil;
    }
}