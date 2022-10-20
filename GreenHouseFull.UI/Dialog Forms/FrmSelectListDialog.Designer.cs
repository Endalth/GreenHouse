namespace GreenHouseFull.UI.Dialog_Forms
{
    partial class FrmSelectListDialog
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
            this.cbxFavoriLists = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFavoriList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxFavoriLists
            // 
            this.cbxFavoriLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFavoriLists.FormattingEnabled = true;
            this.cbxFavoriLists.Location = new System.Drawing.Point(26, 49);
            this.cbxFavoriLists.Name = "cbxFavoriLists";
            this.cbxFavoriLists.Size = new System.Drawing.Size(238, 21);
            this.cbxFavoriLists.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ürünü eklemek istediğiniz favori listesini seçiniz:";
            // 
            // btnFavoriList
            // 
            this.btnFavoriList.Location = new System.Drawing.Point(98, 90);
            this.btnFavoriList.Name = "btnFavoriList";
            this.btnFavoriList.Size = new System.Drawing.Size(75, 23);
            this.btnFavoriList.TabIndex = 2;
            this.btnFavoriList.Text = "Ok";
            this.btnFavoriList.UseVisualStyleBackColor = true;
            this.btnFavoriList.Click += new System.EventHandler(this.btnFavoriList_Click);
            // 
            // FrmSelectListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 135);
            this.Controls.Add(this.btnFavoriList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxFavoriLists);
            this.Name = "FrmSelectListDialog";
            this.Load += new System.EventHandler(this.FrmSelectListDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxFavoriLists;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFavoriList;
    }
}