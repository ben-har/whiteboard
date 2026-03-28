using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace whiteboard
{
    public partial class Form1 : Form
    {

        List<MyRichTextBox> ListOfTextBox = new List<MyRichTextBox>();

        BoxControls boxcontrols = new BoxControls();

       
        int boxCounter = 0;

        const string console_Script = $" CONTROLS \n ctr enter makes a box \n ctr and D closes or opens console \n ctr and S saves the program \n ctr and L loads the program \n ctr and z deletes the last created object\n clicking on a box then pressing delete will delete that box\n clicking on a box then pressing r will resize the box \n clicking on a box and pressing m will move the box";

        int PreAdjX, PreAdjY;

        MyRichTextBox lastClickedBox;

        public Form1()
        {
            InitializeComponent();

        }

         
        internal class MyRichTextBox : RichTextBox
        {
            public int uniqueID { get; set; } = 0;



        }

        internal void Form1_Load(object sender, EventArgs e)
        {
           
            this.KeyPreview = true;
            this.MouseClick -= boxMath;
            this.MouseClick += boxMath;
            this.KeyDown -= Console_KeyDown;
            this.KeyDown += Console_KeyDown;

            Console.Text += console_Script;

            boxcontrols.AssignListenersOnStart(this);
            boxcontrols.ReturnVarsFromForm(this, ListOfTextBox, boxCounter);

        }
       

        internal void createTextBox()
        {
            boxcontrols.ReturnVarsFromForm(this, ListOfTextBox, boxCounter);

            int boxAdjX = PreAdjX / 2;
            int boxAdjy = PreAdjY / 2;

            Point CursorPos = Cursor.Position;
            Point LocalCursor = this.PointToClient(CursorPos);


            MyRichTextBox textBox = new MyRichTextBox();

            textBox.Click += myRichTextBox_Clicked;
            textBox.uniqueID = boxCounter;
            textBox.Location = new Point(LocalCursor.X - boxAdjX, LocalCursor.Y - boxAdjy);
            textBox.Size = new Size(PreAdjX, PreAdjY);


            this.Controls.Add(textBox);
            ListOfTextBox.Add(textBox);

            boxCounter++;







        }





        internal void myRichTextBox_Clicked(object sender, EventArgs e)
        {


            lastClickedBox = (MyRichTextBox)sender;

            int tempID = lastClickedBox.uniqueID + 1;




            lastClickedBox.KeyUp += (s, e) =>
            {


                if (lastClickedBox != null)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Delete:
                            for (int i = tempID; i < ListOfTextBox.Count; i++)
                            {
                                ListOfTextBox[i].uniqueID--;
                            }


                            ListOfTextBox.RemoveAt(lastClickedBox.uniqueID);

                            Controls.Remove(lastClickedBox);

                            lastClickedBox.Dispose();

                            boxCounter--;

                            lastClickedBox = null;
                            break;
                        case Keys.M:
                            int boxAdjX = PreAdjX / 2;
                            int boxAdjy = PreAdjY / 2;

                            Point CursorPos = Cursor.Position;
                            Point LocalCursor = this.PointToClient(CursorPos);

                            lastClickedBox.Location = new Point(LocalCursor.X - boxAdjX, LocalCursor.Y - boxAdjy);

                            lastClickedBox = null;
                            break;
                        case Keys.R:
                            lastClickedBox.Size = new Size(PreAdjX, PreAdjY);

                            lastClickedBox = null;
                            break;
                    }
                }


            };



        }

        bool breakPoint = false;

        Point pointOne = new Point();
        Point pointTwo = new Point();

        void boxMath(Object Sender, MouseEventArgs e)
        {


            Point CursorPos = Cursor.Position;
            Point LocalCursor = this.PointToClient(CursorPos);

            if (!breakPoint)
            {

                pointOne.X = LocalCursor.X;

                pointOne.Y = LocalCursor.Y;

                breakPoint = true;

                return;
            }
            else if (breakPoint)
            {

                pointTwo.X = LocalCursor.X;
                pointTwo.Y = LocalCursor.Y;
                breakPoint = false;
                boxMath(pointOne, pointTwo);
            }
            Console.Text = Console.Text.Length > 0 ? Console.Text + $"\ntime: {DateTime.Now} pointTwoValues are {pointTwo.X} and {pointTwo.Y} and pointOneValuesAre {pointOne.X} and {pointOne.Y}" : Console.Text + $"time: {DateTime.Now} pointTwoValues are {pointTwo.X} and {pointTwo.Y} and pointOneValuesAre {pointOne.X} and {pointOne.Y}";






        }

        void boxMath(Point point1, Point point2)
        {

            PreAdjX = point1.X - point2.X;

            PreAdjY = point1.Y - point2.Y;

            PreAdjX = PreAdjX < 0 ? PreAdjX * -1 : PreAdjX;

            PreAdjY = PreAdjY < 0 ? PreAdjY * -1 : PreAdjY;


        }





        internal void Console_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    Console.Text += $"size of array {ListOfTextBox.Count - 1},";
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

            }
        }

        internal void Console_Switch()
        {
           Console.Visible = !Console.Visible;
        }

        internal void Console_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

        
       

        




