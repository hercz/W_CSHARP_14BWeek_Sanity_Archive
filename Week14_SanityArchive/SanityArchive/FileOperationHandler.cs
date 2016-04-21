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
        public DriveInfo[] AllDrives { get; } = DriveInfo.GetDrives();
        private static string[] Drives
        {
            get
            {
                string[] drives = Directory.GetLogicalDrives();
                return drives;
            }
        }


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

        public void SetPathTextBoxFromComboBox(ComboBox selectedDrive, TextBox pathTextBox)
        {
            pathTextBox.Text = selectedDrive.SelectedItem.ToString();
        }

        public void FillComboBox(ComboBox driveComboBox)
        {
            foreach (var drive in Drives)
            {
                driveComboBox.Items.Add(drive);
            }
        }

        public void FillFileListBoxFromComboBox(ListBox fileListBox)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(Drives[PrimaryDriveComboBox.SelectedIndex]);

                foreach (var dir in dirs)
                {
                    string dirName = Path.GetFileName(dir);
                    fileListBox.Items.Add(dirName);
                }

                string[] files = Directory.GetFiles(Drives[PrimaryDriveComboBox.SelectedIndex]);
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

    }
}

