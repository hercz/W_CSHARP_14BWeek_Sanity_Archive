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
            SanityArchive mainForm = new SanityArchive();
            string fileToRename = mainForm.primaryFileListBox.SelectedItem.ToString();
            
            FileStream originalFile = File.Create(fileToRename);
            //File.Move();
            
        }
    }
}
