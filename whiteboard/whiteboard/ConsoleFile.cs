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

        List<MyRichTextBox> ListOfTextBox;

        RichTextBox Console;


        internal void ReturnConsoleVar( List<MyRichTextBox> ListOfTextBoxVar, RichTextBox ConsoleVar, Form1 form)
        {
            ListOfTextBox = ListOfTextBoxVar;

            Console = ConsoleVar;

            form.KeyDown -= Console_KeyDown;
            form.KeyDown += Console_KeyDown;

        }
        internal void Console_KeyDown(object sender, KeyEventArgs e)
        {
            Random rmd = new Random();
            
            switch (e.KeyCode)
            {
                case Keys.A:
                    Console.Text += $"\nsize of array {ListOfTextBox.Count},";
                    foreach (MyRichTextBox i in ListOfTextBox)
                    {
                        Console.Text += $" {i.uniqueID}";
                    }
                    break;
                case Keys.E:
                    Console.Text = Console.Text.Length > 0 ? Console.Text += $"\n {console_Script}" : console_Script;

                    break;
                case Keys.C:
                    Console.Text = string.Empty;
                    break;
                case Keys.P:

                    foreach(MyRichTextBox i in ListOfTextBox)
                    {
                        i.uniqueID = rmd.Next(0 , ListOfTextBox.Count);
                    }
                    break;
                

            }
        }

        internal void Console_Switch()
        {
            Console.Visible = !Console.Visible;
        }

        
    }
}

