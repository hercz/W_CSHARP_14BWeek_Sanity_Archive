using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchive
{
    public class AttributeEditor
    {
        public void FileRenamer()
        {
            Form1 mainForm = new Form1();
            string fileToRename = mainForm.fileListBox.SelectedItem.ToString();
            
            FileStream originalFile = File.Create(fileToRename);
            //File.Move();
            
        }
    }
}
