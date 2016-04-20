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
    class FileSize
    {
        public ListBox FileListBox { get; private set; }
        public TextBox SizeTextBox { get; private set; }
        public string FilePath { get; private set; }
        public double SizeOfFile { get; private set; }

        public FileSize(ListBox fileListBox, TextBox sizeTextBox)
        {
            FileListBox = fileListBox;
            SizeTextBox = sizeTextBox;
        }

        public void FillFileSizeTextBox()
        {
            SizeTextBox.Text = SizeOfFile.ToString(CultureInfo.CurrentCulture);
        }
        public void GetFileSize()
        {
            FileInfo file = new FileInfo(FilePath);
            SizeOfFile = file.Length;
        }
        public void GetFilePath()
        {
            string path = FileListBox.SelectedIndex.ToString();
            if (File.Exists(path))
            {
                FilePath = path;
            }
        }
    }
}

