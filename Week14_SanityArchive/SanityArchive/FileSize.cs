using System.IO;
using System.Windows.Forms;

namespace SanityArchive
{
    public class FileSize
    {
        public ListBox FileListBox { get; }
        public TextBox SizeTextBox { get; }
        public string FilePath { get; private set; }
        public long SizeOfFileInByte { get; private set; }
        public double SizeOfFileInKbMb { get; private set; }

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
            SizeOfFileInByte = file.Length;
            if (SizeOfFileInByte < 1024)
            {
                SizeTextBox.Text = SizeOfFileInByte + @" byte";
            }
            else if (SizeOfFileInByte < 1048576)
            {
                SizeOfFileInKbMb = SizeOfFileInByte / 1024f;
                SizeTextBox.Text = SizeOfFileInKbMb + @" KB";
            }
            else
            {
                SizeOfFileInKbMb = SizeOfFileInByte / 1024f / 1024f;
                SizeTextBox.Text = SizeOfFileInKbMb + @" MB";
            }


        }
    }
}

