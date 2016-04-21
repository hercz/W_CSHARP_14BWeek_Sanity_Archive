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
        }

        public string TextBoxValue
        {
            get { return textBoxFileName.Text; }
            set { textBoxFileName.Text = value; }
            
        }

        private void textBoxFileName_TextChanged(object sender, EventArgs e)

        {
            newFileName = textBoxFileName.Text;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //textBoxFileName.Text = String.Empty;
            File.Move(originalFileName, newFileName);
            //AttributeEditor editor = new AttributeEditor();
            //editor.FileRenamer();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
