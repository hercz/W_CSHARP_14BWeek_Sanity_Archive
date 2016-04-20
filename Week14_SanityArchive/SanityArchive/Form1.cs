using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            getDrives();
        }



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
    }
}
