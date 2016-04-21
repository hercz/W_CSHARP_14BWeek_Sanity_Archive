using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SanityArchive
{
    public class FileOperationHandler
    {
        public ComboBox PrimaryDriveComboBox { get; set; }
        public ComboBox SecondaryDriveComboBox { get; set; }
        public TextBox PrimaryPathTextBox { get; set; }
        public TextBox SecondaryPathTextBox { get; set; }
        public ListBox PrimaryFileBox { get; set; }
        public ListBox SecondaryFileBox { get; set; }

        public string CurrentPath { get; set; }


        public FileOperationHandler(ComboBox pdComboBox, ComboBox sdComboBox, TextBox ppTextBox, TextBox spTextBox,
            ListBox pFileBox, ListBox sFileBox)
        {
            PrimaryDriveComboBox = pdComboBox;
            SecondaryDriveComboBox = sdComboBox;
            PrimaryPathTextBox = ppTextBox;
            SecondaryPathTextBox = spTextBox;
            PrimaryFileBox = pFileBox;
            SecondaryFileBox = sFileBox;
        }

        public void SetPathTextBox(ListBox fileListBox,  TextBox pathTextBox)
        {
            CurrentPath = pathTextBox.Text + fileListBox.SelectedItem + "\\";            
            pathTextBox.Text = CurrentPath;            
        }

        public void ShowDirsAndFiles(ListBox fileListBox)
        {
            fileListBox.Items.Clear();
            try
            {
                string[] dirs = Directory.GetDirectories(CurrentPath);

                foreach (var dir in dirs)
                {
                    string dirName = Path.GetFileName(dir);
                    fileListBox.Items.Add(dirName);
                }

                string[] files = Directory.GetFiles(CurrentPath);
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    fileListBox.Items.Add(fileName);
                }
            }
            catch (Exception er)
            {
                fileListBox.Items.Clear();
                MessageBox.Show(er.Message);
            }
        }

        public void OpenPrimaryTextBox()
        {
            CurrentPath = PrimaryPathTextBox.Text + PrimaryFileBox.SelectedItem + "\\";
            PrimaryFileBox.Items.Clear();
            PrimaryPathTextBox.Text = CurrentPath;
            ShowDirsAndTexts1();
        }

        public void OpenSecondaryTextBox()
        {
            CurrentPath = SecondaryPathTextBox.Text + SecondaryFileBox.SelectedItem + "\\";
            SecondaryFileBox.Items.Clear();
            SecondaryPathTextBox.Text = CurrentPath;
            ShowDirsAndTexts2();
        }

        public void ShowDirsAndTexts1()
        {
            try
            {
                string[] dirs = Directory.GetDirectories(CurrentPath);

                foreach (var dir in dirs)
                {
                    string dirName = Path.GetFileName(dir);
                    PrimaryFileBox.Items.Add(dirName);
                }

                string[] files = Directory.GetFiles(CurrentPath);
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    PrimaryFileBox.Items.Add(fileName);
                }
            }
            catch (Exception er)
            {
                PrimaryFileBox.Items.Clear();
                MessageBox.Show(er.Message);
            }
        }
        private void ShowDirsAndTexts2()
        {
            try
            {
                string[] dirs = Directory.GetDirectories(CurrentPath);

                foreach (var dir in dirs)
                {
                    string dirName = Path.GetFileName(dir);
                    SecondaryFileBox.Items.Add(dirName);
                }

                string[] files = Directory.GetFiles(CurrentPath);
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    SecondaryFileBox.Items.Add(fileName);
                }
            }
            catch (Exception er)
            {
                SecondaryFileBox.Items.Clear();
                MessageBox.Show(er.Message);
            }
        }

        public void SetPrimaryPath()
        {
            PrimaryPathTextBox.Text = PrimaryDriveComboBox.SelectedItem.ToString();
        }

        public void SetSecondaryPath()
        {
            SecondaryPathTextBox.Text = SecondaryDriveComboBox.SelectedItem.ToString();
        }

        public void FillPrimaryDriveComboBox()
        {
            string[] drives = Directory.GetLogicalDrives();
            foreach (var drive in drives)
            {
                PrimaryDriveComboBox.Items.Add(drive);
            }
        }

        public void FillPrimaryFileBox()
        {
            string[] drives = Directory.GetLogicalDrives();

            try
            {
                string[] dirs = Directory.GetDirectories(drives[PrimaryDriveComboBox.SelectedIndex]);

                foreach (var dir in dirs)
                {
                    string dirName = Path.GetFileName(dir);
                    PrimaryFileBox.Items.Add(dirName);
                }

                string[] files = Directory.GetFiles(drives[PrimaryDriveComboBox.SelectedIndex]);
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    PrimaryFileBox.Items.Add(fileName);
                }
            }
            catch (Exception er)
            {
                PrimaryFileBox.Items.Clear();
                MessageBox.Show(er.Message);
            }

        }
        public void FillSecondaryDriveComboBox()
        {
            string[] drives = Directory.GetLogicalDrives();
            foreach (var drive in drives)
            {
                SecondaryDriveComboBox.Items.Add(drive);
            }
        }
        public void FillSecondaryFileBox()
        {
            string[] drives = Directory.GetLogicalDrives();

            try
            {
                string[] dirs = Directory.GetDirectories(drives[SecondaryDriveComboBox.SelectedIndex]);

                foreach (var dir in dirs)
                {
                    string dirName = Path.GetFileName(dir);
                    SecondaryFileBox.Items.Add(dirName);
                }

                string[] files = Directory.GetFiles(drives[SecondaryDriveComboBox.SelectedIndex]);
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    SecondaryFileBox.Items.Add(fileName);
                }
            }
            catch (Exception er)
            {
                SecondaryFileBox.Items.Clear();
                MessageBox.Show(er.Message);
            }
        }
    }
}

