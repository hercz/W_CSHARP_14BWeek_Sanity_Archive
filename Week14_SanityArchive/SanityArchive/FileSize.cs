#region File Header
/*[ Compilation unit ----------------------------------------------------------

   Component       : Compute the size of selected or multiple selected files

   Name            : FileSize.cs

   Last Author     : Herczku Mihály Balázs

   Language        : C#

   Creation Date   :  2016.04.19.

   Description     : This class handle to compute the size of a selected file.


               Copyright (C) Codecool Kft 2016 All Rights Reserved

-----------------------------------------------------------------------------*/
/*] END */
#endregion File Header

#region Used Namespaces ---------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
#endregion Used Namespaces --


namespace SanityArchive
{
    public class FileSize
    {
        #region Public Propertys ---------------------------------------------------------------
        public ListBox FileListBox { get; }
        public TextBox SizeTextBox { get; }
        public TextBox PathTextBox { get; }
        public string FilePath { get; private set; }
        public List<string> CurrentPaths { get; set; }
        #endregion Public Propertys -----------------------------------------------------------------------

        #region Public Contstructor and methods ---------------------------------------------------------------
        public FileSize(TextBox pathTextBox, ListBox fileListBox, TextBox sizeTextBox)
        {
            PathTextBox = pathTextBox;
            FileListBox = fileListBox;
            SizeTextBox = sizeTextBox;
        }

        public void FillFileSizeTextBox()
        {
            SizeTextBox.Clear();
            CurrentPaths = new List<string>();
            long allsize = 0;
            foreach (var item in FileListBox.SelectedItems)
            {
                CurrentPaths.Add(PathTextBox.Text + item);
            }
            foreach (var path in CurrentPaths)
            {
                if (File.Exists(path))
                {
                    allsize += GetFileSize(path);
                }
                else
                {
                    SizeTextBox.Clear();
                }
            }
            GetSizeInValue(allsize);
        }
        #endregion Public Contstructor and methods -----------------------------------------------------------------------
        
        #region Private methods ---------------------------------------------------------------
        private long GetFileSize(string path)
        {
            FilePath = path;
            FileInfo file = new FileInfo(FilePath);
            long size = file.Length;
            return size;
        }

        private void GetSizeInValue(long allsize)
        {
            if (allsize < 1024)
            {
                SizeTextBox.Text = $"{allsize} byte";
            }
            else if (allsize < 1048576)
            {
                var sizeInKb = Convert.ToDouble(allsize);
                sizeInKb = sizeInKb / 1024;
                SizeTextBox.Text = $"{sizeInKb:F2} KB";
            }
            else
            {
                var sizeInMb = Convert.ToDouble(allsize);
                sizeInMb = sizeInMb / 1024 / 1024;
                SizeTextBox.Text = $"{sizeInMb:F2} MB";
            }
        }
        #endregion Private methods -----------------------------------------------------------------------

    }
}

