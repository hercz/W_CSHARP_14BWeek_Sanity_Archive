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
        public string CurrentPath { get; set; }
        public long SizeOfFileInByte { get; private set; }
        public double SizeOfFileInKbMb { get; private set; }

        public FileSize(TextBox pathTextBox,ListBox fileListBox, TextBox sizeTextBox)
        {
            PathTextBox = pathTextBox;
            FileListBox = fileListBox;
            SizeTextBox = sizeTextBox;
        }

        public void FillFileSizeTextBox()
        {
            SizeTextBox.Clear();
            CurrentPath = PathTextBox.Text + FileListBox.SelectedItem;
            if (File.Exists(CurrentPath))
            {
                GetFileSize(CurrentPath);
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
            SizeOfFileInByte = file.Length;
            if (SizeOfFileInByte < 1024)
            {
                SizeTextBox.Text = $"{SizeOfFileInByte} byte";
            }
            else if (SizeOfFileInByte < 1048576)
            {
                SizeOfFileInKbMb = SizeOfFileInByte / 1024f;
                SizeTextBox.Text = $"{SizeOfFileInKbMb:F2} KB";
            }
            else
            {
                SizeOfFileInKbMb = SizeOfFileInByte / 1024f / 1024f;
                SizeTextBox.Text = $"{SizeOfFileInKbMb:F2} MB";
            }


        }
    }
}

