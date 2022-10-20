namespace GreenHouseFull.UI
{
    partial class FrmUrunAra
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
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.mtxtBarkod = new System.Windows.Forms.MaskedTextBox();
            this.radioBUrunAdi = new System.Windows.Forms.RadioButton();
            this.radioBBarkod = new System.Windows.Forms.RadioButton();
            this.btnUrunAra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Location = new System.Drawing.Point(43, 69);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(222, 20);
            this.txtUrunAdi.TabIndex = 5;
            // 
            // mtxtBarkod
            // 
            this.mtxtBarkod.Location = new System.Drawing.Point(43, 69);
            this.mtxtBarkod.Mask = "00000000-0000-0000-0000-000000000000";
            this.mtxtBarkod.Name = "mtxtBarkod";
            this.mtxtBarkod.Size = new System.Drawing.Size(222, 20);
            this.mtxtBarkod.TabIndex = 4;
            // 
            // radioBUrunAdi
            // 
            this.radioBUrunAdi.AutoSize = true;
            this.radioBUrunAdi.Location = new System.Drawing.Point(43, 27);
            this.radioBUrunAdi.Name = "radioBUrunAdi";
            this.radioBUrunAdi.Size = new System.Drawing.Size(96, 17);
            this.radioBUrunAdi.TabIndex = 6;
            this.radioBUrunAdi.TabStop = true;
            this.radioBUrunAdi.Text = "Urun adı ile ara";
            this.radioBUrunAdi.UseVisualStyleBackColor = true;
            this.radioBUrunAdi.CheckedChanged += new System.EventHandler(this.radioBUrunAdi_CheckedChanged);
            // 
            // radioBBarkod
            // 
            this.radioBBarkod.AutoSize = true;
            this.radioBBarkod.Location = new System.Drawing.Point(170, 27);
            this.radioBBarkod.Name = "radioBBarkod";
            this.radioBBarkod.Size = new System.Drawing.Size(90, 17);
            this.radioBBarkod.TabIndex = 7;
            this.radioBBarkod.TabStop = true;
            this.radioBBarkod.Text = "Barkod ile ara";
            this.radioBBarkod.UseVisualStyleBackColor = true;
            this.radioBBarkod.CheckedChanged += new System.EventHandler(this.radioBBarkod_CheckedChanged);
            // 
            // btnUrunAra
            // 
            this.btnUrunAra.Location = new System.Drawing.Point(107, 115);
            this.btnUrunAra.Name = "btnUrunAra";
            this.btnUrunAra.Size = new System.Drawing.Size(75, 23);
            this.btnUrunAra.TabIndex = 8;
            this.btnUrunAra.Text = "Urun Ara";
            this.btnUrunAra.UseVisualStyleBackColor = true;
            this.btnUrunAra.Click += new System.EventHandler(this.btnUrunAra_Click);
            // 
            // FrmUrunAra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 158);
            this.Controls.Add(this.btnUrunAra);
            this.Controls.Add(this.radioBBarkod);
            this.Controls.Add(this.radioBUrunAdi);
            this.Controls.Add(this.txtUrunAdi);
            this.Controls.Add(this.mtxtBarkod);
            this.Name = "FrmUrunAra";
            this.Text = "Ürün Arama";
            this.Load += new System.EventHandler(this.FrmUrunAra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.MaskedTextBox mtxtBarkod;
        private System.Windows.Forms.RadioButton radioBUrunAdi;
        private System.Windows.Forms.RadioButton radioBBarkod;
        private System.Windows.Forms.Button btnUrunAra;
    }
}