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
    internal class BoxControls
    {
        Form1 FormHolder;


        List<MyRichTextBox> ListOfTextBoxHolder;

      

        save_load mysave = new save_load();

        delThis mydel = new delThis();

        

        internal void ReturnVarsFromForm(Form1 formVar,List<MyRichTextBox> ListOfTextBoxVar)
        {
          FormHolder = formVar;
          ListOfTextBoxHolder = ListOfTextBoxVar;
         
          formVar.KeyDown -= KeyEntered;
          formVar.KeyDown += KeyEntered;

           
        }
        void KeyEntered(object sender, KeyEventArgs e)
        {


            if (e.Control)
            {
                switch (e.KeyCode)
                {
                   
                    case Keys.Enter:
                        FormHolder.mouseCreateTextBox();
                        break;
                    case Keys.Z:
                        mydel.DelLast(ListOfTextBoxHolder, FormHolder);
                        break;
                    case Keys.F:
                        mysave.saveSate(ListOfTextBoxHolder);
                        break;
                    case Keys.L:
                        mysave.loadState(ListOfTextBoxHolder, FormHolder);
                        break;
                    case Keys.X:
                        Thread SanityCheckThread = new Thread(FormHolder.ArraySanityCheck);
                        SanityCheckThread.Start();
                        break;



                }

            }




        }
    }
}

        
