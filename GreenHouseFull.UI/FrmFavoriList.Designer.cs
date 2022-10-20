namespace GreenHouseFull.UI
{
    partial class FrmFavoriList
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
            this.txtNewListName = new System.Windows.Forms.TextBox();
            this.btnNewList = new System.Windows.Forms.Button();
            this.listBFavoriList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBUrun = new System.Windows.Forms.ListBox();
            this.btnListeSil = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUrunKaldir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNewListName
            // 
            this.txtNewListName.Location = new System.Drawing.Point(344, 153);
            this.txtNewListName.Name = "txtNewListName";
            this.txtNewListName.Size = new System.Drawing.Size(170, 20);
            this.txtNewListName.TabIndex = 2;
            // 
            // btnNewList
            // 
            this.btnNewList.Location = new System.Drawing.Point(374, 189);
            this.btnNewList.Name = "btnNewList";
            this.btnNewList.Size = new System.Drawing.Size(102, 46);
            this.btnNewList.TabIndex = 3;
            this.btnNewList.Text = "Yeni Liste Ekle";
            this.btnNewList.UseVisualStyleBackColor = true;
            this.btnNewList.Click += new System.EventHandler(this.btnNewList_Click);
            // 
            // listBFavoriList
            // 
            this.listBFavoriList.FormattingEnabled = true;
            this.listBFavoriList.Location = new System.Drawing.Point(12, 31);
            this.listBFavoriList.Name = "listBFavoriList";
            this.listBFavoriList.Size = new System.Drawing.Size(120, 433);
            this.listBFavoriList.TabIndex = 4;
            this.listBFavoriList.SelectedIndexChanged += new System.EventHandler(this.listBFavoriList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Favori Listeleriniz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Seçili Listedeki Ürünler";
            // 
            // listBUrun
            // 
            this.listBUrun.FormattingEnabled = true;
            this.listBUrun.Location = new System.Drawing.Point(182, 31);
            this.listBUrun.Name = "listBUrun";
            this.listBUrun.Size = new System.Drawing.Size(120, 433);
            this.listBUrun.TabIndex = 6;
            this.listBUrun.SelectedIndexChanged += new System.EventHandler(this.listBUrun_SelectedIndexChanged);
            this.listBUrun.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBUrun_MouseDoubleClick);
            // 
            // btnListeSil
            // 
            this.btnListeSil.Location = new System.Drawing.Point(374, 254);
            this.btnListeSil.Name = "btnListeSil";
            this.btnListeSil.Size = new System.Drawing.Size(102, 23);
            this.btnListeSil.TabIndex = 8;
            this.btnListeSil.Text = "Seçili Listeyi Sil";
            this.btnListeSil.UseVisualStyleBackColor = true;
            this.btnListeSil.Click += new System.EventHandler(this.btnListeSil_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Yeni Liste Adı";
            // 
            // btnUrunKaldir
            // 
            this.btnUrunKaldir.Location = new System.Drawing.Point(374, 301);
            this.btnUrunKaldir.Name = "btnUrunKaldir";
            this.btnUrunKaldir.Size = new System.Drawing.Size(102, 40);
            this.btnUrunKaldir.TabIndex = 10;
            this.btnUrunKaldir.Text = "Seçili Ürünü Listeden Kaldır";
            this.btnUrunKaldir.UseVisualStyleBackColor = true;
            this.btnUrunKaldir.Click += new System.EventHandler(this.btnUrunKaldir_Click);
            // 
            // FrmFavoriList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 482);
            this.Controls.Add(this.btnUrunKaldir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnListeSil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBUrun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBFavoriList);
            this.Controls.Add(this.btnNewList);
            this.Controls.Add(this.txtNewListName);
            this.Name = "FrmFavoriList";
            this.Text = "Favori Listeleri";
            this.Load += new System.EventHandler(this.FrmFavoriList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNewListName;
        private System.Windows.Forms.Button btnNewList;
        private System.Windows.Forms.ListBox listBFavoriList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBUrun;
        private System.Windows.Forms.Button btnListeSil;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUrunKaldir;
    }
}