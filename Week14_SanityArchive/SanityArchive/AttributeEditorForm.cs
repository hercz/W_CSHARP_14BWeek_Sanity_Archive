using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchive
{
    public partial class AttributeEditorForm : Form
    {

        private string originalFileName;
        private string newFileName;

        public AttributeEditorForm()
        {
            InitializeComponent();
            if (File.GetAttributes("C:\\ArchiveTester\\test.jpg") == FileAttributes.Hidden)
            {
                checkBoxHidden.Checked = true;
            }

            if (File.GetAttributes("C:\\ArchiveTester\\test.jpg") == FileAttributes.ReadOnly)
            {
                checkBoxReadOnly.Checked = true;
            }
            if (File.GetAttributes("C:\\ArchiveTester\\test.jpg") == FileAttributes.Compressed)
            {
                checkBoxCompressed.Checked = true;
            }

            if (File.GetAttributes("C:\\ArchiveTester\\test.jpg") == FileAttributes.Encrypted)
            {
                checkBoxEncrypted.Checked = true;
            }

        }

        public void InstantiateCheckbox()
        {
            
        }

        public string TextBoxValue
        {
            get { return textBoxFileName.Text; }
            set { textBoxFileName.Text = value; }
        }

        private void textBoxFileName_GotFocus(object sender, EventArgs e)
        {
            originalFileName = textBoxFileName.Text;
        }

        private void textBoxFileName_TextChanged(object sender, EventArgs e)

        {
            newFileName = textBoxFileName.Text;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            File.Move(originalFileName, newFileName);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxReadOnly.Checked)
            {
                File.SetAttributes(originalFileName, FileAttributes.ReadOnly);
            }
            else
            {
                File.SetAttributes(originalFileName, ~FileAttributes.ReadOnly);
            }
        }
    }
}
