using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchive
{
    public partial class AttributeEditorForm : Form
    {
        public AttributeEditorForm()
        {
            InitializeComponent();
            //Form1 mainForm = new Form1();
            //textBoxFileName.Text = mainForm.fileListBox.SelectedItem.ToString();
        }

        public string TextBoxValue
        {
            get { return textBoxFileName.Text; }
            set { textBoxFileName.Text = value; }
        }


    }
}
