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

        ConsoleFile Console;

        List<MyRichTextBox> ListOfTextBoxHolder;

        int BoxCounterHolder;

        save_load mysave = new save_load();

        delThis mydel = new delThis();

      

        internal void ReturnVarsFromForm(Form1 formVar,List<MyRichTextBox> ListOfTextBoxVar,int boxCounterVar)
        {
          FormHolder = formVar;
          ListOfTextBoxHolder = ListOfTextBoxVar;
          BoxCounterHolder = boxCounterVar;
          formVar.KeyDown -= KeyEntered;
          formVar.KeyDown += KeyEntered;

           
        }
        void KeyEntered(object sender, KeyEventArgs e)
        {


            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.D:
                        Console.Console_Switch();
                        break;
                    case Keys.Enter:
                        FormHolder.mouseCreateTextBox();
                        break;
                    case Keys.Z:
                        mydel.DelLast(ListOfTextBoxHolder, BoxCounterHolder, FormHolder);
                        break;
                    case Keys.S:
                        mysave.saveSate(ListOfTextBoxHolder);
                        break;
                    case Keys.T:
                        mysave.loadState(ListOfTextBoxHolder, BoxCounterHolder, FormHolder);
                        break;

                }

            }




        }
    }
}

        
