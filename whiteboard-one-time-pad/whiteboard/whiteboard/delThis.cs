using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static whiteboard.Form1;

namespace whiteboard
{
    internal class delThis
    {
        
        internal void DelLast(List<MyRichTextBox> textLastOne, int boxCounter, Form1 myform)
        {

            if (textLastOne.Count == 0) return;


            myform.Controls.Remove(textLastOne[textLastOne.Count - 1]);


            textLastOne[textLastOne.Count - 1].Dispose();


            textLastOne.RemoveAt(textLastOne.Count - 1);


            boxCounter--;
        }
    }
}
