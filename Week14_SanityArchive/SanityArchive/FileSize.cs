using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchive
{
    public class FileSize
    {
        public ListBox FileListBox { get; private set; }
        public TextBox SizeTextBox { get; private set; }
        public string FilePath { get; private set; }
        public long SizeOfFile { get; private set; }

        public FileSize(ListBox fileListBox, TextBox sizeTextBox)
        {
            FileListBox = fileListBox;
            SizeTextBox = sizeTextBox;
        }

        public void FillFileSizeTextBox()
        {
            SizeTextBox.Clear();
            string path = FileListBox.SelectedItem.ToString();
            if (File.Exists(path))
            {
                GetFileSize(path);
            }
            else
            {
                SizeTextBox.Clear();
            }
        }

        private void GetFileSize(string path)
        {
            FilePath = path;
            FileInfo file = new FileInfo(FilePath);
            SizeOfFile = file.Length;
            if (SizeOfFile < 1024)
            {
                SizeTextBox.Text = SizeOfFile + @" byte";
            }
            else if (SizeOfFile < 1048576)
            {
                SizeOfFile = SizeOfFile/1024;
                SizeTextBox.Text = SizeOfFile + @" KB";
            }
            else
            {
                SizeOfFile = SizeOfFile / 1024 / 1024;
                SizeTextBox.Text = SizeOfFile + @" MB";
            }


        }
    }
}

