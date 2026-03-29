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

        BoxControls boxcontrolsFile = new BoxControls();

        ConsoleFile consolefile = new ConsoleFile();

        save_load SaveFile = new save_load();

        drawingTools drawingFile = new drawingTools(); 
       
        int boxCounter = 0;


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





            boxcontrolsFile.ReturnVarsFromForm(this, ListOfTextBox, boxCounter);

            consolefile.ReturnConsoleVar(ListOfTextBox, Console ,this );

            SaveFile.ValuePassThrough(this);

            drawingFile.DrawingValuesPassThrough(this);


        }
       

        internal void mouseCreateTextBox()
        {
            boxcontrolsFile.ReturnVarsFromForm(this, ListOfTextBox, boxCounter);

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
        void AutoCompleteBox()
        {
            boxcontrolsFile.ReturnVarsFromForm(this, ListOfTextBox, boxCounter);

            int boxAdjX = PreAdjX;
            int boxAdjy = PreAdjY;

            MyRichTextBox textBox = new MyRichTextBox();

            textBox.Click += myRichTextBox_Clicked;
            textBox.uniqueID = boxCounter;
            textBox.Location = new Point(100, 100);
            textBox.Size = new Size(PreAdjX, PreAdjY);
            Debug.WriteLine(textBox.Location);

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
                            Thread ArraySanityThread = new Thread(ArraySanityCheck);
                            ArraySanityThread.Start();

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
                            if(PreAdjX != 0)
                            {
                                lastClickedBox.Size = new Size(PreAdjX, PreAdjY);

                                lastClickedBox = null;
                            }
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

                PlacePanels(pointOne, pointTwo, true);
                return;
            }
            else if (breakPoint)
            {

                pointTwo.X = LocalCursor.X;
                pointTwo.Y = LocalCursor.Y;
                breakPoint = false;
                PlacePanels(pointOne, pointTwo, false);
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
        //works but doesnt show a soild box at the edges
        List<Panel> ListOfPanels = new List<Panel>();
        void PlacePanels(Point pointOne, Point pointTwo, bool BreakPoint)
        {
            

            Panel panel = new Panel();
            
            panel.BackColor = Color.Black;

            panel.Location = BreakPoint ? pointOne : pointTwo;

            panel.Size = new Size(10, 10);
            
            this.Controls.Add(panel);
            ListOfPanels.Add(panel);
            if(!BreakPoint) 
            { 
               // Debug.WriteLine("entered");
                foreach(Panel p in ListOfPanels)
                {
                    this.Controls.Remove(p);
                    
                }
                
            }
        
                
        }

       

        internal void ArraySanityCheck()
        {
           
            //this functions purpose is to loop through the array in a for loop then invoke anything that needs to be changed
            for (int i = 0; i < ListOfTextBox.Count; i++)
            {
                
                for (int j = i + 1; j < ListOfTextBox.Count  - 1; j++)
                {
                    if (ListOfTextBox[i].uniqueID >= ListOfTextBox[j].uniqueID )
                    {
                        boxCounter = 0;

                        foreach(MyRichTextBox r in ListOfTextBox)
                        {
                            r.uniqueID = boxCounter;
                            boxCounter++;
                        }


                    }






                }




            }
            
        }

      


       

        internal void Console_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

        
       

        




