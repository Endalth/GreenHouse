namespace GreenHouseFull.UI.Admin
{
    partial class FrmKategoriAdmin
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
            this.lvKategori = new System.Windows.Forms.ListView();
            this.cbxUstKategori = new System.Windows.Forms.ComboBox();
            this.txtKategoriAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGonder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 37);
            this.label2.MaximumSize = new System.Drawing.Size(300, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Güncelleme veya Silme için listeden seçim yapınız. Seçimi iptal etmek için listed" +
    "eki boşluğa basabilirsiniz.";
            // 
            // lvKategori
            // 
            this.lvKategori.FullRowSelect = true;
            this.lvKategori.HideSelection = false;
            this.lvKategori.Location = new System.Drawing.Point(12, 77);
            this.lvKategori.MultiSelect = false;
            this.lvKategori.Name = "lvKategori";
            this.lvKategori.Size = new System.Drawing.Size(288, 273);
            this.lvKategori.TabIndex = 6;
            this.lvKategori.UseCompatibleStateImageBehavior = false;
            this.lvKategori.View = System.Windows.Forms.View.Details;
            this.lvKategori.SelectedIndexChanged += new System.EventHandler(this.lvKategori_SelectedIndexChanged);
            // 
            // cbxUstKategori
            // 
            this.cbxUstKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUstKategori.FormattingEnabled = true;
            this.cbxUstKategori.Location = new System.Drawing.Point(344, 160);
            this.cbxUstKategori.Name = "cbxUstKategori";
            this.cbxUstKategori.Size = new System.Drawing.Size(167, 21);
            this.cbxUstKategori.TabIndex = 8;
            // 
            // txtKategoriAdi
            // 
            this.txtKategoriAdi.Location = new System.Drawing.Point(344, 104);
            this.txtKategoriAdi.Name = "txtKategoriAdi";
            this.txtKategoriAdi.Size = new System.Drawing.Size(167, 20);
            this.txtKategoriAdi.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(341, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Kategori Adı";
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ust Kategori";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(368, 265);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 23);
            this.btnSil.TabIndex = 13;
            this.btnSil.Text = "Seçileni Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGonder
            // 
            this.btnGonder.Location = new System.Drawing.Point(368, 207);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(100, 23);
            this.btnGonder.TabIndex = 12;
            this.btnGonder.Text = "Ekle";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // FrmKategoriAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 369);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKategoriAdi);
            this.Controls.Add(this.cbxUstKategori);
            this.Controls.Add(this.lvKategori);
            this.Controls.Add(this.label2);
            this.Name = "FrmKategoriAdmin";
            this.Text = "Kategori Admin İşlemleri";
            this.Load += new System.EventHandler(this.FrmKategoriAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvKategori;
        private System.Windows.Forms.ComboBox cbxUstKategori;
        private System.Windows.Forms.TextBox txtKategoriAdi;
        private System.Windows.Forms.Label label1;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGonder;
    }
}