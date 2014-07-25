namespace EasyOpen
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBtn = new System.Windows.Forms.Button();
            this.btnsPanel = new System.Windows.Forms.Panel();
            this.infoLbl = new System.Windows.Forms.Label();
            this.savedFoldersCb = new System.Windows.Forms.ComboBox();
            this.saveChk = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBtn
            // 
            this.listBtn.Location = new System.Drawing.Point(12, 30);
            this.listBtn.Name = "listBtn";
            this.listBtn.Size = new System.Drawing.Size(141, 23);
            this.listBtn.TabIndex = 0;
            this.listBtn.Text = "Browse";
            this.listBtn.UseVisualStyleBackColor = true;
            this.listBtn.Click += new System.EventHandler(this.listBtn_Click);
            // 
            // btnsPanel
            // 
            this.btnsPanel.AutoScroll = true;
            this.btnsPanel.Location = new System.Drawing.Point(13, 104);
            this.btnsPanel.Name = "btnsPanel";
            this.btnsPanel.Size = new System.Drawing.Size(271, 295);
            this.btnsPanel.TabIndex = 2;
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Location = new System.Drawing.Point(13, 81);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(271, 13);
            this.infoLbl.TabIndex = 3;
            this.infoLbl.Text = "Now open a folder from here and have a happy code :D";
            this.infoLbl.Visible = false;
            // 
            // savedFoldersCb
            // 
            this.savedFoldersCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.savedFoldersCb.FormattingEnabled = true;
            this.savedFoldersCb.Location = new System.Drawing.Point(159, 32);
            this.savedFoldersCb.Name = "savedFoldersCb";
            this.savedFoldersCb.Size = new System.Drawing.Size(125, 21);
            this.savedFoldersCb.TabIndex = 4;
            this.savedFoldersCb.SelectedIndexChanged += new System.EventHandler(this.savedFoldersCb_SelectedIndexChanged);
            // 
            // saveChk
            // 
            this.saveChk.AutoSize = true;
            this.saveChk.Location = new System.Drawing.Point(16, 57);
            this.saveChk.Name = "saveChk";
            this.saveChk.Size = new System.Drawing.Size(101, 17);
            this.saveChk.TabIndex = 5;
            this.saveChk.Text = "Save that folder";
            this.saveChk.UseVisualStyleBackColor = true;
            this.saveChk.CheckedChanged += new System.EventHandler(this.saveChk_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Browse or select a saved directory:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 411);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveChk);
            this.Controls.Add(this.savedFoldersCb);
            this.Controls.Add(this.infoLbl);
            this.Controls.Add(this.btnsPanel);
            this.Controls.Add(this.listBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Git Easy Open";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button listBtn;
        private System.Windows.Forms.Panel btnsPanel;
        private System.Windows.Forms.Label infoLbl;
        private System.Windows.Forms.ComboBox savedFoldersCb;
        private System.Windows.Forms.CheckBox saveChk;
        private System.Windows.Forms.Label label1;
    }
}

