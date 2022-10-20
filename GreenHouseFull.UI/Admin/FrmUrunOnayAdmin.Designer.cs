namespace GreenHouseFull.UI
{
    partial class FrmUrunOnayAdmin
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
            this.lvUrunOnay = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvUrunOnay
            // 
            this.lvUrunOnay.FullRowSelect = true;
            this.lvUrunOnay.HideSelection = false;
            this.lvUrunOnay.Location = new System.Drawing.Point(12, 50);
            this.lvUrunOnay.MultiSelect = false;
            this.lvUrunOnay.Name = "lvUrunOnay";
            this.lvUrunOnay.Size = new System.Drawing.Size(610, 503);
            this.lvUrunOnay.TabIndex = 0;
            this.lvUrunOnay.UseCompatibleStateImageBehavior = false;
            this.lvUrunOnay.View = System.Windows.Forms.View.Details;
            this.lvUrunOnay.SelectedIndexChanged += new System.EventHandler(this.lvUrunOnay_SelectedIndexChanged);
            this.lvUrunOnay.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvUrunOnay_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(472, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Güncellemek istediğiniz onaya çift tıklayınız.. Seçimi iptal etmek için listede b" +
    "ir boşluğa basabilirsiniz.";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(508, 24);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(114, 23);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Seçileni Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // FrmUrunOnayAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 565);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvUrunOnay);
            this.Name = "FrmUrunOnayAdmin";
            this.Text = "Ürün Onay Admin İşlemleri";
            this.Load += new System.EventHandler(this.FrmUrunOnay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvUrunOnay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSil;
    }
}