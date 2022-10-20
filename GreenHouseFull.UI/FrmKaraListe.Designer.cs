namespace GreenHouseFull.UI
{
    partial class FrmKaraListe
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
            this.listBUrunIcerik = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKaraListedenKaldir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBUrunIcerik
            // 
            this.listBUrunIcerik.FormattingEnabled = true;
            this.listBUrunIcerik.Location = new System.Drawing.Point(12, 28);
            this.listBUrunIcerik.Name = "listBUrunIcerik";
            this.listBUrunIcerik.Size = new System.Drawing.Size(211, 433);
            this.listBUrunIcerik.TabIndex = 3;
            this.listBUrunIcerik.SelectedIndexChanged += new System.EventHandler(this.listBUrunIcerik_SelectedIndexChanged);
            this.listBUrunIcerik.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBUrunIcerik_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Açmak istediğiniz ürüne çift tıklayınız.";
            // 
            // btnKaraListedenKaldir
            // 
            this.btnKaraListedenKaldir.Location = new System.Drawing.Point(245, 44);
            this.btnKaraListedenKaldir.Name = "btnKaraListedenKaldir";
            this.btnKaraListedenKaldir.Size = new System.Drawing.Size(101, 54);
            this.btnKaraListedenKaldir.TabIndex = 4;
            this.btnKaraListedenKaldir.Text = "Seçili içeriği Kara Listeden Kaldır";
            this.btnKaraListedenKaldir.UseVisualStyleBackColor = true;
            this.btnKaraListedenKaldir.Click += new System.EventHandler(this.btnKaraListedenKaldir_Click);
            // 
            // FrmKaraListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 474);
            this.Controls.Add(this.btnKaraListedenKaldir);
            this.Controls.Add(this.listBUrunIcerik);
            this.Controls.Add(this.label1);
            this.Name = "FrmKaraListe";
            this.Text = "Kara Liste";
            this.Load += new System.EventHandler(this.FrmKaraListe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBUrunIcerik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKaraListedenKaldir;
    }
}