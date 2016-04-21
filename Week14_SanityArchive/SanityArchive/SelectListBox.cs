using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SanityArchive
{
    class SelectListBox
    {
        public ComboBox PrimaryDriveComboBox { get; set; }
        public ComboBox SecondaryDriveComboBox { get; set; }
        public TextBox PrimaryPathTextBox { get; set; }
        public TextBox SecondaryPathTextBox { get; set; }
        public ListBox PrimaryFileBox { get; set; }
        public ListBox SecondaryFileBox { get; set; }

        public SelectListBox(ComboBox pdComboBox, ComboBox sdComboBox, TextBox ppTextBox, TextBox spTextBox, ListBox pFileBox, ListBox sFileBox)
        {
            PrimaryDriveComboBox = pdComboBox;
            SecondaryDriveComboBox = sdComboBox;
            PrimaryPathTextBox = ppTextBox;
            SecondaryPathTextBox = spTextBox;
            PrimaryFileBox = pFileBox;
            SecondaryFileBox = sFileBox;
        }
    }
}
