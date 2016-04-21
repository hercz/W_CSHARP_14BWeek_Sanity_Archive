using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace SanityArchive
{
    public partial class SanityArchive : Form
    {
        public FileSize SizeOfFile { get; set; }
        public FileOperationHandler FileOperationHandler { get; set; }
        private Archiving ar = new Archiving();

        public SanityArchive()
        {
            InitializeComponent();           
        }

        private void SanityArchive_Load(object sender, EventArgs e)
        {
            SizeOfFile = new FileSize(primaryFileListBox, fileSize_Textbox);
            FileOperationHandler = new FileOperationHandler();
            FileOperationHandler.FillComboBox(primaryDriverComboBox);
            FileOperationHandler.FillComboBox(secondaryDriveComboBox);
        }

        private void PrimaryDriveComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileOperationHandler.FillFileListBoxFromComboBox(primaryFileListBox, primaryDriverComboBox);
            FileOperationHandler.SetPathTextBoxFromComboBox(primaryDriverComboBox, primaryPathTextBox);
        }
        private void secondaryDriveComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileOperationHandler.FillFileListBoxFromComboBox(SecondaryFileListBox, secondaryDriveComboBox);
            FileOperationHandler.SetPathTextBoxFromComboBox(secondaryDriveComboBox, secondaryPathTextBox); ;
        }


        private void primaryFileListBox_DoubleClick(object sender, MouseEventArgs e)
        {
            FileOperationHandler.SetPathTextBox(primaryFileListBox,primaryPathTextBox);
            FileOperationHandler.ShowDirsAndFiles(primaryFileListBox);
        }


        private void SecondaryFileListBox_DoubleClick(object sender, MouseEventArgs e)
        {
            FileOperationHandler.SetPathTextBox(SecondaryFileListBox, secondaryPathTextBox);
            FileOperationHandler.ShowDirsAndFiles(SecondaryFileListBox);
        }

        private void primaryFileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = primaryFileListBox.SelectedItem.ToString().ToLower();

            if (selectedItem.EndsWith(".enc"))
            {
                encryptionButton.Text = "Decryption";
            }
            else
            {
                encryptionButton.Text = "Encryption";
            }
            SizeOfFile.FillFileSizeTextBox();
        }

        private void compressButton_Click(object sender, EventArgs e)
        {
            if (primaryFileListBox.SelectedItem.ToString().EndsWith(".gz"))
            {
                compressButton.Text = "Decompessing";
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                string path = string.Empty;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    path = fbd.SelectedPath;
                }
                DirectoryInfo dInfo = new DirectoryInfo(path);
                foreach (FileInfo fInfo in dInfo.GetFiles())
                {
                    ar.Decompress(fInfo);
                    MessageBox.Show("Decompressing Finished!");
                }
            }
            else
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                string path = string.Empty;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    path = fbd.SelectedPath;
                }
                DirectoryInfo dInfo = new DirectoryInfo(path);
                foreach (FileInfo fInfo in dInfo.GetFiles())
                {
                    ar.Compress(fInfo);
                    MessageBox.Show("Compression Finished!");
                }
            }
        }
    
        private void editButton_Click(object sender, EventArgs e)
        {
            AttributeEditorForm attributeEditorForm = new AttributeEditorForm();
            if (primaryFileListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a file from the list first!");
            }
            else
            {
                attributeEditorForm.TextBoxValue = primaryFileListBox.SelectedItem.ToString();
                attributeEditorForm.ShowDialog();
            }
        }

        private void encryptionButton_Click(object sender, EventArgs e)
        {
            string selectedItem = primaryPathTextBox.Text + primaryFileListBox.SelectedItem.ToString();
            EncryptionAndDecryption encrypOrDecrypt = new EncryptionAndDecryption();

            if (encryptionButton.Text.Equals("Encryption"))
            {
                encrypOrDecrypt.EncryptFile(@selectedItem, @selectedItem + ".enc");
                primaryFileListBox.Items.Clear();
                FileOperationHandler.ShowDirsAndFiles(primaryFileListBox);

            }
            else
            {
                encrypOrDecrypt.DecryptFile(@selectedItem, @selectedItem.Substring(0, (selectedItem.Length - 4)));
                primaryFileListBox.Items.Clear();
                FileOperationHandler.ShowDirsAndFiles(primaryFileListBox);
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            List<string> selectedItems = new List<string>();
            foreach (var item in primaryFileListBox.SelectedItems)
            {
                string selectedItemPath = Path.Combine(primaryPathTextBox.Text, item.ToString());
                selectedItems.Add(selectedItemPath);
            }
            string destFilePath = secondaryPathTextBox.Text;
            foreach (var item in selectedItems)
            {
                FileAttributes fa = File.GetAttributes(item);
                CopyAndMove cam = new CopyAndMove(item, destFilePath);
                if (fa == FileAttributes.Directory)
                {
                    cam.CopyDirectory();
                }
                else
                {
                    cam.CopyFile();
                }
            }
            
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            List<string> selectedItems = new List<string>();
            foreach (var item in primaryFileListBox.SelectedItems)
            {
                string selectedItemPath = Path.Combine(primaryPathTextBox.Text, item.ToString());
                selectedItems.Add(selectedItemPath);
            }
            string destFilePath = secondaryPathTextBox.Text;
            foreach (var item in selectedItems)
            {
                FileAttributes fa = File.GetAttributes(item);
                CopyAndMove cam = new CopyAndMove(item, destFilePath);
                if (fa == FileAttributes.Directory)
                {
                    cam.MoveDirectory();
                }
                else
                {
                    cam.MoveFile();
                }
            }
        }
    }
}
