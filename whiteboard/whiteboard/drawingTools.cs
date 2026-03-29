using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace whiteboard
{
    internal class drawingTools
    {

        Form1 myform;

        bool mybool;

        internal void DrawingValuesPassThrough(Form1 myformHandler )
        {
            myformHandler.MouseUp-= Drawing_MouseMove;
            myformHandler.MouseUp += Drawing_MouseMove;

            myform = myformHandler;
        }

        internal void ControlsValuesPassThrough(bool DrawingFlip)
        {
            mybool = DrawingFlip;


        }

        void Drawing_MouseMove(object sender, MouseEventArgs e)
        {
           
           if(mybool)
           {
                Point GlobalCursor = Cursor.Position;
                Point LocalCursor = myform.PointToClient(GlobalCursor);

                Panel CurrentPanel = new Panel();

                CurrentPanel.Size = new Size(10, 10);
                CurrentPanel.Location = new Point(LocalCursor.X, LocalCursor.Y);
                CurrentPanel.BackColor = Color.Black;

                myform.Controls.Add(CurrentPanel);
           }





        }

    }
}
