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
        SanityArchive mainForm = new SanityArchive();
        FileOperationHandler fileHandler = new FileOperationHandler();
        
        private string originalFileName;
        private string newFileName;
        

        public AttributeEditorForm()
        {
            InitializeComponent();
        }

        public AttributeEditorForm(string filePath)
        {
            InitializeComponent();
            textBoxFileName.Text = filePath;
            originalFileName = textBoxFileName.Text;

            if (File.GetAttributes(originalFileName) == FileAttributes.Hidden)
            {
                checkBoxHidden.Checked = true;
            }

            if (File.GetAttributes(originalFileName) == FileAttributes.ReadOnly)
            {
                checkBoxReadOnly.Checked = true;
            }
            if (File.GetAttributes(originalFileName) == FileAttributes.Compressed)
            {
                checkBoxCompressed.Checked = true;
            }

            if (File.GetAttributes(originalFileName) == FileAttributes.Encrypted)
            {
                checkBoxEncrypted.Checked = true;
            }
        }

        private void textBoxFileName_TextChanged(object sender, EventArgs e)

        {
            newFileName = textBoxFileName.Text;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            File.Move(originalFileName, newFileName);
            //fileHandler.FillFileListBoxFromComboBox(fileHandler.PrimaryFileBox, fileHandler.PrimaryDriveComboBox);
            mainForm.primaryFileListBox.Update();
            Close();
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

        private void checkBoxHidden_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHidden.Checked)
            {
                File.SetAttributes(originalFileName, FileAttributes.Hidden);
            }
            else
            {
                File.SetAttributes(originalFileName, ~FileAttributes.Hidden);
            }
        }
    }
}
