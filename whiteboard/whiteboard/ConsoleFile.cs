using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static whiteboard.Form1;

namespace whiteboard
{
    internal class ConsoleFile
    {
        const string console_Script = $" CONTROLS \n ctr enter makes a box \n ctr and D closes or opens console \n ctr and S saves the program \n ctr and L loads the program \n ctr and z deletes the last created object\n clicking on a box then pressing delete will delete that box\n clicking on a box then pressing r will resize the box \n clicking on a box and pressing m will move the box";

        List<MyRichTextBox> ListOfTextBoxVar;

        RichTextBox ConsoleVar;

       


        internal void ReturnConsoleVar( List<MyRichTextBox> ListOfTextBoxHolder, RichTextBox ConsoleHolder, Form1 formHolder)
        {
            ListOfTextBoxVar = ListOfTextBoxHolder;

            ConsoleVar = ConsoleHolder;

            formHolder.KeyDown -= Console_KeyDown;
            formHolder.KeyDown += Console_KeyDown;

        }
        internal void Console_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.Control)
           {
                switch (e.KeyCode)
                {
                    case Keys.P:
                        ConsoleVar.Text += $"\nsize of array {ListOfTextBoxVar.Count},";
                        foreach (MyRichTextBox i in ListOfTextBoxVar)
                        {
                            ConsoleVar.Text += $" {i.uniqueID}";
                        }
                        break;
                    case Keys.O:
                        ConsoleVar.Text = ConsoleVar.Text.Length > 0 ? ConsoleVar.Text += $"\n {console_Script}" : console_Script;

                        break;
                    case Keys.I:
                        ConsoleVar.Text = string.Empty;
                        break;

                    case Keys.U:
                        Console_Switch();
                        break;


                        

                }


           }
        }

        internal void Console_Switch()
        {
            ConsoleVar.Visible = !ConsoleVar.Visible;
        }

        
    }
}

