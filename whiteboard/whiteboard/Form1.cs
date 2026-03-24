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

        save_load mysave = new save_load();

        delThis mydel = new delThis();

        int boxCounter = 0;

        int x, y;

        MyRichTextBox lastClickedBox;

        public Form1()
        {
            InitializeComponent();

        }


        internal class MyRichTextBox : RichTextBox
        {
            public int uniqueID { get; set; } = 0;



        }


        internal class noteFile
        {
            public int ID { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public int W { get; set; }

            public int H { get; set; }

            public string Text { get; set; } = string.Empty;

            public int Type { get; set; }

            public string function { get; set; } = string.Empty;
        }

        internal void Form1_Load(object sender, EventArgs e)
        {
            this.KeyDown += KeyEntered;
            this.KeyPreview = true;
            this.MouseClick += boxMath;

        }

        void KeyEntered(object sender, KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == Keys.Enter)
            {

                createTextBox();

            }
            if (e.Control && e.KeyCode == Keys.Z)
            {
                mydel.DelLast(ListOfTextBox, boxCounter, this);


            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                mysave.saveSate(ListOfTextBox);
            }
           
            if (e.Control && e.KeyCode == Keys.L)
            {
                mysave.loadState(ListOfTextBox, boxCounter, this);
            }




        }

        
        void createTextBox()
        {
            int boxAdjX = x / 2;
            int boxAdjy = y / 2;

            Point CursorPos = Cursor.Position;
            Point LocalCursor = this.PointToClient(CursorPos);


            MyRichTextBox textBox = new MyRichTextBox();

            textBox.Click += myRichTextBox_Clicked;
            textBox.uniqueID = boxCounter;
            textBox.Location = new Point(LocalCursor.X - boxAdjX, LocalCursor.Y - boxAdjy);
            textBox.Size = new Size(x, y);
            

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

                if (e.KeyCode == Keys.Delete && lastClickedBox != null)
                {



                    for (int i = tempID; i < ListOfTextBox.Count; i++)
                    {
                        ListOfTextBox[i].uniqueID--;
                    }


                    ListOfTextBox.RemoveAt(lastClickedBox.uniqueID);

                    Controls.Remove(lastClickedBox);

                    lastClickedBox.Dispose();

                    boxCounter--;

                    lastClickedBox = null;

                    


                }
                if(e.KeyCode == Keys.M && lastClickedBox != null)
                {
                    int boxAdjX = x / 2;
                    int boxAdjy = y / 2;

                    Point CursorPos = Cursor.Position;
                    Point LocalCursor = this.PointToClient(CursorPos);

                    lastClickedBox.Location = new Point(LocalCursor.X - boxAdjX, LocalCursor.Y - boxAdjy);

                    lastClickedBox = null;

                }
                if(e.KeyCode == Keys.R && lastClickedBox != null)
                {

                    lastClickedBox.Size = new Size(x,y);

                    lastClickedBox = null;
                }



            };



        }

        bool breakPoint = false;

        int[] pointOne = new int[2];
        int[] pointTwo = new int[2];

        void boxMath(Object Sender, MouseEventArgs e)
        {


            Point CursorPos = Cursor.Position;
            Point LocalCursor = this.PointToClient(CursorPos);

            if (!breakPoint)
            {

                pointOne[0] = LocalCursor.X;

                pointOne[1] = LocalCursor.Y;

                breakPoint = true;
                
                return;
            }
            else if (breakPoint)
            {

                pointTwo[0] = LocalCursor.X;
                pointTwo[1] = LocalCursor.Y;
                breakPoint = false;
                boxMath(pointOne, pointTwo);
            }






        }

        void boxMath(int[] arr1, int[] arr2)
        {

            x = arr1[0] - arr2[0];

            y = arr1[1] - arr2[1];

            x = x < 0 ? x * -1 : x;

            y = y < 0 ? y * -1 : y;

            Debug.WriteLine($"x is {x} and y is {y}");
        }
        
        void reInstateBox(string text , int x , int y , bool flip ) 
        {

        }


    }

}

        
       

        




