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
        



        public FileOperationHandler(ComboBox pdComboBox, ComboBox sdComboBox, TextBox ppTextBox, TextBox spTextBox, ListBox pFileBox, ListBox sFileBox)
        {
            PrimaryDriveComboBox = pdComboBox;
            SecondaryDriveComboBox = sdComboBox;
            PrimaryPathTextBox = ppTextBox;
            SecondaryPathTextBox = spTextBox;
            PrimaryFileBox = pFileBox;
            SecondaryFileBox = sFileBox;
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
    }
}
