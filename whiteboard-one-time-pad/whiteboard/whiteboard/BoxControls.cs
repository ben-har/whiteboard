using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static whiteboard.Form1;
using System.Diagnostics;


namespace whiteboard
{
    internal class BoxControls
    {
        Form1 FormHolder;

        List<MyRichTextBox> ListOfTextBoxHolder;

        int BoxCounterHolder;

        save_load mysave = new save_load();

        delThis mydel = new delThis();

        internal void AssignListenersOnStart(Form1 form)
        {
            form.KeyDown -= KeyEntered;
            form.KeyDown += KeyEntered;
        }

        internal void ReturnVarsFromForm(Form1 formVar,List<MyRichTextBox> ListOfTextBoxVar,int boxCounterVar)
        {
          FormHolder = formVar;
          ListOfTextBoxHolder = ListOfTextBoxVar;
          BoxCounterHolder = boxCounterVar;

            Debug.WriteLine($" the form is {FormHolder}, the ListofTextBoxes are {ListOfTextBoxHolder}, the BoxCounterHolder is at {BoxCounterHolder}");
        }
        void KeyEntered(object sender, KeyEventArgs e)
        {


            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.D:
                        FormHolder.Console_Switch();
                        break;
                    case Keys.Enter:
                        FormHolder.createTextBox();
                        break;
                    case Keys.Z:
                        mydel.DelLast(ListOfTextBoxHolder, BoxCounterHolder, FormHolder);
                        break;
                    case Keys.S:
                        mysave.saveSate(ListOfTextBoxHolder);
                        break;
                    case Keys.L:
                        mysave.loadState(ListOfTextBoxHolder, BoxCounterHolder, FormHolder);
                        break;

                }

            }




        }
    }
}

        
