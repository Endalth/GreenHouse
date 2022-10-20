namespace GreenHouseFull.UI
{
    partial class FrmGecmisAramalar
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
            this.listBUruns = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKaldir = new System.Windows.Forms.Button();
            this.btnRemoveBeforeDate = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // listBUruns
            // 
            this.listBUruns.FormattingEnabled = true;
            this.listBUruns.Location = new System.Drawing.Point(12, 39);
            this.listBUruns.Name = "listBUruns";
            this.listBUruns.Size = new System.Drawing.Size(259, 433);
            this.listBUruns.TabIndex = 3;
            this.listBUruns.SelectedIndexChanged += new System.EventHandler(this.listBUruns_SelectedIndexChanged);
            this.listBUruns.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBUruns_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Açmak istediğiniz ürüne çift tıklayınız.";
            // 
            // btnKaldir
            // 
            this.btnKaldir.Location = new System.Drawing.Point(352, 213);
            this.btnKaldir.Name = "btnKaldir";
            this.btnKaldir.Size = new System.Drawing.Size(112, 33);
            this.btnKaldir.TabIndex = 4;
            this.btnKaldir.Text = "Seçili Geçmişi Sil";
            this.btnKaldir.UseVisualStyleBackColor = true;
            this.btnKaldir.Click += new System.EventHandler(this.btnKaldir_Click);
            // 
            // btnRemoveBeforeDate
            // 
            this.btnRemoveBeforeDate.Location = new System.Drawing.Point(352, 127);
            this.btnRemoveBeforeDate.Name = "btnRemoveBeforeDate";
            this.btnRemoveBeforeDate.Size = new System.Drawing.Size(112, 54);
            this.btnRemoveBeforeDate.TabIndex = 5;
            this.btnRemoveBeforeDate.Text = "Seçili Tarihten Önce Eklenenleri Sil";
            this.btnRemoveBeforeDate.UseVisualStyleBackColor = true;
            this.btnRemoveBeforeDate.Click += new System.EventHandler(this.btnRemoveBeforeDate_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(314, 89);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(183, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // FrmGecmisAramalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 503);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnRemoveBeforeDate);
            this.Controls.Add(this.btnKaldir);
            this.Controls.Add(this.listBUruns);
            this.Controls.Add(this.label1);
            this.Name = "FrmGecmisAramalar";
            this.Text = "Gecmiş Aramalar";
            this.Load += new System.EventHandler(this.FrmGecmisAramalar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBUruns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKaldir;
        private System.Windows.Forms.Button btnRemoveBeforeDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}