using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static whiteboard.Form1;
using System.Diagnostics;

namespace whiteboard
{
    internal class MovementFile
    {

        Form1 formVar;

        List<MyRichTextBox> ListOfTextBoxVar;

        MyRichTextBox LastClickedBoxVar;

        internal void LastClickedBoxPassThrough(MyRichTextBox LastClickedBoxHandler)
        {
            LastClickedBoxVar = LastClickedBoxHandler;
        }


        internal void MovementVarHandler(Form1 formHandler, List<MyRichTextBox> ListOfTextBoxHandler, MyRichTextBox LastClickedBoxHandler)
        {

            ListOfTextBoxVar = ListOfTextBoxHandler;

            formVar = formHandler;

            LastClickedBoxVar = LastClickedBoxHandler;

            formHandler.KeyDown -= WASDMovemet_KeyDown;
            formHandler.KeyDown += WASDMovemet_KeyDown;
        }

        void WASDMovemet_KeyDown(Object sender, KeyEventArgs e)
        {
            //based on the input we should move all the objects except the console and any other ui elements this will be scuffed
            if(e.Control)
                switch (e.KeyCode)
                {
                    case Keys.W:
                        foreach (MyRichTextBox r in ListOfTextBoxVar)
                        {
                            FlipPrivliges(true);
                            //Debug.WriteLine("input detected");
                            r.Location = new Point(r.Location.X, r.Location.Y - 10);


                        }
                        break;
                    case Keys.A:
                        foreach (MyRichTextBox r in ListOfTextBoxVar)
                        {
                            FlipPrivliges(true);
                            r.Location = new Point(r.Location.X - 10, r.Location.Y);

                        }
                        break;
                    case Keys.S:
                        foreach (MyRichTextBox r in ListOfTextBoxVar)
                        {
                            FlipPrivliges(true);
                            r.Location = new Point(r.Location.X, r.Location.Y + 10);

                        }
                        break;
                    case Keys.D:
                        foreach (MyRichTextBox r in ListOfTextBoxVar)
                        {
                            FlipPrivliges(true);
                            r.Location = new Point(r.Location.X + 10, r.Location.Y);


                        }
                        break;




                }
            FlipPrivliges(false);


        }

        void FlipPrivliges(bool Right)
        {
            if(LastClickedBoxVar != null)
            {
                LastClickedBoxVar.ReadOnly = Right;


            }
            
        }
        
    }
}
