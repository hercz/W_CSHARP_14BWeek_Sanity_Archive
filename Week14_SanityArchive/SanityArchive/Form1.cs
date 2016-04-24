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
            SizeOfFile = new FileSize(primaryPathTextBox,primaryFileListBox, fileSize_Textbox);
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
            FileOperationHandler.SetPathTextBox(primaryFileListBox, primaryPathTextBox);
            FileOperationHandler.ShowDirsAndFiles(primaryFileListBox);
        }


        private void SecondaryFileListBox_DoubleClick(object sender, MouseEventArgs e)
        {
            FileOperationHandler.SetPathTextBox(SecondaryFileListBox, secondaryPathTextBox);
            FileOperationHandler.ShowDirsAndFiles(SecondaryFileListBox);
        }

        private void primaryFileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SizeOfFile.FillFileSizeTextBox();
            if (primaryFileListBox.SelectedItem == null) return;
            string selectedItem = primaryFileListBox.SelectedItem.ToString().ToLower();

            if (selectedItem.EndsWith(".enc"))
            {
                encryptionButton.Text = "Decryption";
            }
            else
            {
                encryptionButton.Text = "Encryption";
            }            
        }

        private void compressButton_Click(object sender, EventArgs e)
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
            }
            MessageBox.Show("Compression Finished!");

           
        }

        private void buttonDecompress_Click_1(object sender, EventArgs e)
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
                ar.Decompress(fInfo);
            }
            MessageBox.Show("Decompressing Finished!");
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (primaryFileListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a file from the list first!");
            }
            else
            {
                string selectedItem = primaryPathTextBox.Text + primaryFileListBox.SelectedItem.ToString();
                AttributeEditorForm attributeEditorForm = new AttributeEditorForm(selectedItem);
                //attributeEditorForm.TextBoxValue = selectedItem;
                
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
            string destFilePath = secondaryPathTextBox.Text;

            foreach (var item in primaryFileListBox.SelectedItems)
            {
                string selectedItemPath = Path.Combine(primaryPathTextBox.Text, item.ToString());
                selectedItems.Add(selectedItemPath);
            }
            foreach (var item in selectedItems)
            {
                FileAttributes fa = File.GetAttributes(item);
                string destDirPath = Path.Combine(destFilePath, Path.GetFileName(item));

                if (fa == FileAttributes.Directory)
                {
                    CopyAndMove cam = new CopyAndMove(item, destDirPath);
                    cam.CopyDirectory(item, destDirPath);
                }
                else
                {
                    CopyAndMove cam = new CopyAndMove(item, destFilePath);
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
