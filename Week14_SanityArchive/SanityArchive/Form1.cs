using System;
using System.Drawing.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace SanityArchive
{
    public partial class Form1 : Form

    {
        public FileSize SizeOfFile { get; set; }
        public FileOperationHandler FileOperationHandler { get; set; }

        public Form1()
        {
            InitializeComponent();
            SizeOfFile = new FileSize(fileListBox, fileSize_Textbox);
            FileOperationHandler = new FileOperationHandler(comboBox1, comboBox2, pathTextBox1, pathTextBox2, fileListBox, fileListBox2);
            FileOperationHandler.FillPrimaryDriveComboBox();
            FileOperationHandler.FillSecondaryDriveComboBox();
        }
        private Archiving ar = new Archiving();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileOperationHandler.FillPrimaryFileBox();
            FileOperationHandler.SetPrimaryPath();
        }


        private void fileList_DoubleClick(object sender, MouseEventArgs e)
        {
            FileOperationHandler.Open();
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileOperationHandler.FillSecondaryFileBox();
        }



        private void fileList2_DoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void compressButton_Click(object sender, EventArgs e)
        {
            if (fileListBox.SelectedItem.ToString().EndsWith(".gz"))
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

        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = fileListBox.SelectedItem.ToString().ToLower();

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

        private void editButton_Click(object sender, EventArgs e)
        {
            AttributeEditorForm attributeEditorForm = new AttributeEditorForm();
            if (fileListBox.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a file first!");
            }
            else
            {
                attributeEditorForm.TextBoxValue = fileListBox.SelectedItem.ToString();
                attributeEditorForm.ShowDialog();
            }
        }

        private void encryptionButton_Click(object sender, EventArgs e)
        {
            string selectedItem = pathTextBox1.Text + fileListBox.SelectedItem.ToString();
            EncryptionAndDecryption encrypOrDecrypt = new EncryptionAndDecryption();

            if (encryptionButton.Text.Equals("Encryption"))
            {
                encrypOrDecrypt.EncryptFile(@selectedItem, @selectedItem + ".enc");
                fileListBox.Items.Clear();
                FileOperationHandler.ShowDirsAndTexts();

            }
            else
            {
                encrypOrDecrypt.DecryptFile(@selectedItem, @selectedItem.Substring(0, (selectedItem.Length - 4)));
                fileListBox.Items.Clear();
                FileOperationHandler.ShowDirsAndTexts();
            }
        }
    }
}
