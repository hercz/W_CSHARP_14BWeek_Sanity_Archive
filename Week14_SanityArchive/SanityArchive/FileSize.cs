using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SanityArchive
{
    public class FileSize
    {
        public ListBox FileListBox { get; }
        public TextBox SizeTextBox { get; }
        public TextBox PathTextBox { get; }
        public string FilePath { get; private set; }
        public List<string> CurrentPaths { get; set; }

        public FileSize(TextBox pathTextBox,ListBox fileListBox, TextBox sizeTextBox)
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
    }
}

