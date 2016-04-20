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
                FilePath = path;
                FileInfo file = new FileInfo(FilePath);
                SizeOfFile = file.Length;
                SizeTextBox.Text = SizeOfFile.ToString();
            }
            else
            {
                SizeTextBox.Clear();    
            }
            
            
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

