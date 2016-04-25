namespace SanityArchive
{
    partial class SanityArchive
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
            this.DriverLabel = new System.Windows.Forms.Label();
            this.primaryDriverComboBox = new System.Windows.Forms.ComboBox();
            this.primaryFileListBox = new System.Windows.Forms.ListBox();
            this.compressButton = new System.Windows.Forms.Button();
            this.encryptionButton = new System.Windows.Forms.Button();
            this.driverLabel2 = new System.Windows.Forms.Label();
            this.secondaryDriveComboBox = new System.Windows.Forms.ComboBox();
            this.SecondaryFileListBox = new System.Windows.Forms.ListBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.primaryPathTextBox = new System.Windows.Forms.TextBox();
            this.secondaryPathTextBox = new System.Windows.Forms.TextBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fileSize_Textbox = new System.Windows.Forms.TextBox();
            this.fileSize_label = new System.Windows.Forms.Label();
            this.buttonDecompress = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DriverLabel
            // 
            this.DriverLabel.AutoSize = true;
            this.DriverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DriverLabel.Location = new System.Drawing.Point(30, 15);
            this.DriverLabel.Name = "DriverLabel";
            this.DriverLabel.Size = new System.Drawing.Size(44, 16);
            this.DriverLabel.TabIndex = 0;
            this.DriverLabel.Text = "Driver";
            // 
            // primaryDriverComboBox
            // 
            this.primaryDriverComboBox.FormattingEnabled = true;
            this.primaryDriverComboBox.Location = new System.Drawing.Point(95, 12);
            this.primaryDriverComboBox.Name = "primaryDriverComboBox";
            this.primaryDriverComboBox.Size = new System.Drawing.Size(250, 21);
            this.primaryDriverComboBox.TabIndex = 1;
            this.primaryDriverComboBox.SelectedIndexChanged += new System.EventHandler(this.PrimaryDriveComboBox_SelectedIndexChanged);
            // 
            // primaryFileListBox
            // 
            this.primaryFileListBox.FormattingEnabled = true;
            this.primaryFileListBox.Location = new System.Drawing.Point(95, 128);
            this.primaryFileListBox.Name = "primaryFileListBox";
            this.primaryFileListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.primaryFileListBox.Size = new System.Drawing.Size(250, 251);
            this.primaryFileListBox.TabIndex = 2;
            this.primaryFileListBox.SelectedIndexChanged += new System.EventHandler(this.primaryFileListBox_SelectedIndexChanged);
            this.primaryFileListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.primaryFileListBox_DoubleClick);
            // 
            // compressButton
            // 
            this.compressButton.Location = new System.Drawing.Point(375, 301);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(94, 35);
            this.compressButton.TabIndex = 3;
            this.compressButton.Text = "Compress";
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.compressButton_Click);
            // 
            // encryptionButton
            // 
            this.encryptionButton.Location = new System.Drawing.Point(375, 258);
            this.encryptionButton.Name = "encryptionButton";
            this.encryptionButton.Size = new System.Drawing.Size(94, 37);
            this.encryptionButton.TabIndex = 4;
            this.encryptionButton.Text = "Encryption";
            this.encryptionButton.UseVisualStyleBackColor = true;
            this.encryptionButton.Click += new System.EventHandler(this.encryptionButton_Click);
            // 
            // driverLabel2
            // 
            this.driverLabel2.AutoSize = true;
            this.driverLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.driverLabel2.Location = new System.Drawing.Point(427, 51);
            this.driverLabel2.Name = "driverLabel2";
            this.driverLabel2.Size = new System.Drawing.Size(44, 16);
            this.driverLabel2.TabIndex = 7;
            this.driverLabel2.Text = "Driver";
            // 
            // secondaryDriveComboBox
            // 
            this.secondaryDriveComboBox.FormattingEnabled = true;
            this.secondaryDriveComboBox.Location = new System.Drawing.Point(498, 50);
            this.secondaryDriveComboBox.Name = "secondaryDriveComboBox";
            this.secondaryDriveComboBox.Size = new System.Drawing.Size(268, 21);
            this.secondaryDriveComboBox.TabIndex = 9;
            this.secondaryDriveComboBox.SelectedIndexChanged += new System.EventHandler(this.secondaryDriveComboBox_SelectedIndexChanged);
            // 
            // SecondaryFileListBox
            // 
            this.SecondaryFileListBox.FormattingEnabled = true;
            this.SecondaryFileListBox.Location = new System.Drawing.Point(498, 128);
            this.SecondaryFileListBox.Name = "SecondaryFileListBox";
            this.SecondaryFileListBox.Size = new System.Drawing.Size(268, 251);
            this.SecondaryFileListBox.TabIndex = 11;
            this.SecondaryFileListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SecondaryFileListBox_DoubleClick);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(375, 219);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(94, 33);
            this.copyButton.TabIndex = 14;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(375, 180);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(94, 33);
            this.moveButton.TabIndex = 15;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(375, 141);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(94, 33);
            this.editButton.TabIndex = 16;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(30, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(427, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Path";
            // 
            // primaryPathTextBox
            // 
            this.primaryPathTextBox.Location = new System.Drawing.Point(95, 53);
            this.primaryPathTextBox.Name = "primaryPathTextBox";
            this.primaryPathTextBox.Size = new System.Drawing.Size(250, 20);
            this.primaryPathTextBox.TabIndex = 19;
            // 
            // secondaryPathTextBox
            // 
            this.secondaryPathTextBox.Location = new System.Drawing.Point(498, 90);
            this.secondaryPathTextBox.Name = "secondaryPathTextBox";
            this.secondaryPathTextBox.Size = new System.Drawing.Size(268, 20);
            this.secondaryPathTextBox.TabIndex = 20;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(95, 91);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(250, 20);
            this.searchTextBox.TabIndex = 21;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(30, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Search";
            // 
            // fileSize_Textbox
            // 
            this.fileSize_Textbox.Location = new System.Drawing.Point(13, 359);
            this.fileSize_Textbox.Name = "fileSize_Textbox";
            this.fileSize_Textbox.Size = new System.Drawing.Size(68, 20);
            this.fileSize_Textbox.TabIndex = 23;
            // 
            // fileSize_label
            // 
            this.fileSize_label.AutoSize = true;
            this.fileSize_label.Location = new System.Drawing.Point(12, 343);
            this.fileSize_label.Name = "fileSize_label";
            this.fileSize_label.Size = new System.Drawing.Size(30, 13);
            this.fileSize_label.TabIndex = 24;
            this.fileSize_label.Text = "Size:";
            // 
            // buttonDecompress
            // 
            this.buttonDecompress.Location = new System.Drawing.Point(375, 344);
            this.buttonDecompress.Name = "buttonDecompress";
            this.buttonDecompress.Size = new System.Drawing.Size(94, 35);
            this.buttonDecompress.TabIndex = 25;
            this.buttonDecompress.Text = "Decompress";
            this.buttonDecompress.UseVisualStyleBackColor = true;
            this.buttonDecompress.Click += new System.EventHandler(this.buttonDecompress_Click_1);
            // 
            // SanityArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 407);
            this.Controls.Add(this.buttonDecompress);
            this.Controls.Add(this.fileSize_label);
            this.Controls.Add(this.fileSize_Textbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.secondaryPathTextBox);
            this.Controls.Add(this.primaryPathTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.SecondaryFileListBox);
            this.Controls.Add(this.secondaryDriveComboBox);
            this.Controls.Add(this.driverLabel2);
            this.Controls.Add(this.encryptionButton);
            this.Controls.Add(this.compressButton);
            this.Controls.Add(this.primaryFileListBox);
            this.Controls.Add(this.primaryDriverComboBox);
            this.Controls.Add(this.DriverLabel);
            this.Name = "SanityArchive";
            this.Text = "Sanity archive";
            this.Load += new System.EventHandler(this.SanityArchive_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DriverLabel;
        private System.Windows.Forms.ComboBox primaryDriverComboBox;
        public System.Windows.Forms.ListBox primaryFileListBox;
        private System.Windows.Forms.Button compressButton;
        private System.Windows.Forms.Button encryptionButton;
        private System.Windows.Forms.Label driverLabel2;
        private System.Windows.Forms.ComboBox secondaryDriveComboBox;
        private System.Windows.Forms.ListBox SecondaryFileListBox;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox primaryPathTextBox;
        private System.Windows.Forms.TextBox secondaryPathTextBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fileSize_Textbox;
        private System.Windows.Forms.Label fileSize_label;
        private System.Windows.Forms.Button buttonDecompress;
    }
}

