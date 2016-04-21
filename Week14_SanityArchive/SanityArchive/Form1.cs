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

        public Form1()
        {
            InitializeComponent();
            SizeOfFile = new FileSize(fileListBox, fileSize_Textbox);
            getDrives();
        }
        private Archiving ar = new Archiving();
        private string source;

        void getDrives()
        {
            string[] drives = System.IO.Directory.GetLogicalDrives();

            foreach (string str in drives)
            {
                comboBox1.Items.Add(str);
                comboBox2.Items.Add(str);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fileListBox.Items.Clear();
                pathTextBox1.Text = comboBox1.Text;
                string[] directoryList = Directory.GetDirectories(pathTextBox1.Text);
                foreach (string str in directoryList)
                {
                    fileListBox.Items.Add(str);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Not existed driver!");
            }
        }





        private void fileList_DoubleClick(object sender, MouseEventArgs e)
        {
            getFiles(fileListBox.SelectedItem.ToString(), "O");
        }






        public void getFiles(string selectedFolder, string filemode)
        {
            try
            {
                string[] directoryList = Directory.GetDirectories(@selectedFolder);
                string[] fileList = Directory.GetFiles(@selectedFolder);
                pathTextBox1.Text = @selectedFolder;
                fileListBox.Items.Clear();
                foreach (var directory in directoryList)
                {
                    fileListBox.Items.Add(directory);
                }
                foreach (var file in fileList)
                {
                    fileListBox.Items.Add(file);
                }
            }
            catch (Exception)
            {
                if (filemode.Equals("O"))
                {
                    MessageBox.Show("This is not directory.");
                }

            }
        }





        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fileListBox2.Items.Clear();
                pathTextBox2.Text = comboBox2.Text;
                string[] directoryList = Directory.GetDirectories(pathTextBox2.Text);
                foreach (string str in directoryList)
                {
                    fileListBox2.Items.Add(str);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Not existed driver!");
            }
        }



        private void fileList2_DoubleClick(object sender, MouseEventArgs e)
        {
            getFiles2(fileListBox2.SelectedItem.ToString(), "O");
        }




        public void getFiles2(string selectedFolder, string filemode)
        {
            try
            {
                string[] directoryList = Directory.GetDirectories(@selectedFolder);
                string[] fileList = Directory.GetFiles(@selectedFolder);
                pathTextBox2.Text = @selectedFolder;
                fileListBox2.Items.Clear();
                foreach (var directory in directoryList)
                {
                    fileListBox2.Items.Add(directory);
                }
                foreach (var file in fileList)
                {
                    fileListBox2.Items.Add(file);
                }
            }
            catch (Exception)
            {
                if (filemode.Equals("O"))
                {
                    MessageBox.Show("This is not directory.");
                }

            }
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
            string selectedItem = fileListBox.SelectedItem.ToString();
            EncryptionAndDecryption encrypOrDecrypt = new EncryptionAndDecryption();

            if (encryptionButton.Text.Equals("Encryption")) 
            {
               encrypOrDecrypt.EncryptFile(@selectedItem, @selectedItem + ".enc");

            }
            else
            {
                encrypOrDecrypt.DecryptFile(@selectedItem, @selectedItem.Substring(0, (selectedItem.Length - 4 )));
            }




        }

       
    }
}
