#region File Header
/*[ Compilation unit ----------------------------------------------------------

   Component       : Browse files and directorys

   Name            : OperationHandler.cs

   Last Author     : Herczku Mihály Balázs

   Language        : C#

   Creation Date   :  2016.04.19.

   Description     : This class handle to browse files and directorys, and open text files.


               Copyright (C) Codecool Kft 2016 All Rights Reserved

-----------------------------------------------------------------------------*/
/*] END */
#endregion File Header
#region Used Namespaces -------
using System;
using System.IO;
using System.Windows.Forms;
#endregion Used Namespaces --

namespace SanityArchive
{
    public class FileOperationHandler
    {
        #region Public Propertys ---------------------------------------------------------------
        public ComboBox PrimaryDriveComboBox { get; set; }
        public ComboBox SecondaryDriveComboBox { get; set; }
        public TextBox PrimaryPathTextBox { get; set; }
        public TextBox SecondaryPathTextBox { get; set; }
        public ListBox PrimaryFileBox { get; set; }
        public ListBox SecondaryFileBox { get; set; }
        public string CurrentPath { get; set; }
        public DriveInfo[] AllDrives { get; } = DriveInfo.GetDrives();
        #endregion Public Propertys -----------------------------------------------------------------------
        #region Private Propertys ---------------------------------------------------------------
        private static string[] Drives
        {
            get
            {
                string[] drives = Directory.GetLogicalDrives();
                return drives;
            }
        }
        #endregion Private Propertys -----------------------------------------------------------------------

        #region Public methods -----------------------------------------------------------------------

        public void SetPathTextBox(ListBox fileListBox, TextBox pathTextBox)
        {
            if (fileListBox.SelectedItem == null) return;
            CurrentPath = pathTextBox.Text + fileListBox.SelectedItem + "\\";
            pathTextBox.Text = CurrentPath;
        }

        public void ShowDirsAndFiles(ListBox fileListBox)
        {

            if (fileListBox.SelectedItem == null) return;
            fileListBox.Items.Clear();
            try
            {
                string[] dirs = Directory.GetDirectories(CurrentPath);

                foreach (var dir in dirs)
                {
                    string dirName = Path.GetFileName(dir);
                    if (dirName != null) fileListBox.Items.Add(dirName);
                }
                string[] files = Directory.GetFiles(CurrentPath);
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    if (fileName != null) fileListBox.Items.Add(fileName);
                }
            }
            catch (Exception er)
            {
                if (!IfTextFileOpenTheFile())
                {
                    fileListBox.Items.Clear();
                    MessageBox.Show(er.Message);
                }
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

        public void FillFileListBoxFromComboBox(ListBox fileListBox, ComboBox driveComboBox)
        {
            fileListBox.Items.Clear();
            try
            {
                string[] dirs = Directory.GetDirectories(Drives[driveComboBox.SelectedIndex]);

                foreach (var dir in dirs)
                {
                    string dirName = Path.GetFileName(dir);
                    if (dirName != null) fileListBox.Items.Add(dirName);
                }

                string[] files = Directory.GetFiles(Drives[driveComboBox.SelectedIndex]);
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    if (fileName != null) fileListBox.Items.Add(fileName);
                }
            }
            catch (Exception er)
            {
                fileListBox.Items.Clear();
                MessageBox.Show(er.Message);
            }
        }
        #endregion Public methods -----------------------------------------------------------------------
        #region Private methods -----------------------------------------------------------------------
        private bool IfTextFileOpenTheFile()
        {
            if (CurrentPath.EndsWith(@".txt\"))
            {
                System.Diagnostics.Process.Start(CurrentPath);
                return true;
            }
            return false;
        }
        #endregion Private methods -----------------------------------------------------------------------
    }
}

