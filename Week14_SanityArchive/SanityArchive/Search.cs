using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchive
{
    class Search
    {

        public Search(ListBox myListBox , String searchString)
        {
            myListBox.SelectionMode = SelectionMode.MultiExtended;
            ClearSelectedMode(myListBox);

            int x = -1;
            if (searchString.Length != 0)
            {
                do
                {
                    x = myListBox.FindString(searchString, x);
                    if (x != -1)
                    {
                        if (myListBox.SelectedIndices.Count > 0)
                        {
                            if (x == myListBox.SelectedIndices[0])
                                return;
                        }
                        myListBox.SetSelected(x, true);
                    }

                } while (x != -1);
            }


        }


        private void ClearSelectedMode(ListBox myListBox)
        {
            for (int i = 0; i < myListBox.Items.Count; i++)
            {
                myListBox.SetSelected(i, false);
            }
        }




    }
}
