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
        public void AdjustFileAttributes()
        {
            AttributeEditorForm form = new AttributeEditorForm();
            if (File.GetAttributes("C:\\ArchiveTester\\bi.jpg") == FileAttributes.Hidden)
            {
                form.checkBoxHidden.Checked = true;
            }

            if (File.GetAttributes("C:\\ArchiveTester\\bi.jpg") == FileAttributes.ReadOnly)
            {
                form.checkBoxReadOnly.Checked = true;
            }

        }
    }
}
