using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace SanityArchive
{
    public partial class SanityArchive : Form
    {
        public FileSize SizeOfFile { get; set; }
        public FileOperationHandler FileOperationHandler { get; set; }
        CopyAndMove cam = new CopyAndMove();

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
            string zipPath = secondaryPathTextBox.Text + "result.zip";
            string selectedItem = primaryPathTextBox.Text + primaryFileListBox.SelectedItem.ToString();

            try
            {
                using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update))
                {
                    archive.CreateEntryFromFile(selectedItem, primaryFileListBox.SelectedItem.ToString());
                }
                MessageBox.Show("Compression successful!");
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
        }

        private void buttonDecompress_Click_1(object sender, EventArgs e)
        {
            string extractPath = secondaryPathTextBox.Text;
            string selectedItem = primaryPathTextBox.Text + primaryFileListBox.SelectedItem.ToString();

            try
            {
                using (ZipArchive archive = ZipFile.Open(selectedItem, ZipArchiveMode.Update))
                {
                    archive.ExtractToDirectory(extractPath);
                }
                MessageBox.Show("Decompression successful!");
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (primaryFileListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a file from the list first!");
            }
            else
            {
                string filePath = primaryPathTextBox.Text;
                string fileName = primaryFileListBox.SelectedItem.ToString();
                AttributeEditorForm attributeEditorForm = new AttributeEditorForm(filePath, fileName);                
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
                FileOperationHandler.ShowDirsAndFiles(primaryFileListBox);



            }
            else
            {
                encrypOrDecrypt.DecryptFile(@selectedItem, @selectedItem.Substring(0, (selectedItem.Length - 4)));
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
                    cam.CopyDirectory(item, destDirPath);
                }
                else
                {
                    cam.CopyFile(item, destFilePath);
                }
            }

        }

        private void moveButton_Click(object sender, EventArgs e)
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
                    cam.MoveDirectory(item, destDirPath);
                }
                else
                {
                    cam.MoveFile(item, destFilePath);
                }
            }
        }

        

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchString = searchTextBox.Text;

           Search mySearch = new Search(primaryFileListBox, searchString);

        }


    }
}
