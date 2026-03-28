using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static whiteboard.Form1;

namespace whiteboard
{
    internal class save_load
    {
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

        internal void saveSate(List<MyRichTextBox> ListOfTextBox)
        {
            Debug.WriteLine("opened save func from another file");
            //opes save dialog 
            using var sfd = new SaveFileDialog();
            // determinds the drop down menu like when you save an image it shows .png and .blah blah
            sfd.Filter = "Whiteboard Files (*.white)|*.white|JSON (*.json)|*.json";
            //if the user doesnt set a .file type then it will put in .white
            sfd.DefaultExt = "white";
            //if the user presses cancel then it will return so the save code wont run
            if (sfd.ShowDialog() != DialogResult.OK) return;

            //loop through our created list of boxes and store there vars in text
            //replace the multiple of Lists with one master list 
            var boxData = ListOfTextBox.Select(tb => new noteFile
            {
                ID = tb.uniqueID,
                X = tb.Location.X,
                Y = tb.Location.Y,
                W = tb.Size.Width,
                H = tb.Size.Height,
                Text = tb.Text,
                Type = 0,




            }).ToList();
            //serializes the data then writes it to the text file
            string json = JsonSerializer.Serialize(boxData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(sfd.FileName, json);
        }

        internal void loadState(List<MyRichTextBox> ListOfTextBox, int boxCounter, Form1 myform)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Whiteboard Files (*.white; *.json) | *.white; *.json";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            //clear the whiteboard  of richtext files and buttons again a master list would kick ass here
            foreach (var tb in ListOfTextBox)
            {
                myform.Controls.Remove(tb);
                tb.Dispose();
            }


            //clear the tracking list
            ListOfTextBox.Clear();

            boxCounter = 0;
            //read the file from disk and turn it into string
            string json = File.ReadAllText(ofd.FileName);

            //convert json back to memory //has to be the same type when saving
            var data = JsonSerializer.Deserialize<List<noteFile>>(json) ?? new();

            //using a forloop restore those vars back richtextfiles 
            foreach (var restorie in data)
            {
                MyRichTextBox tb = new MyRichTextBox();
                tb.Text = restorie.Text;
                tb.Click += myform.myRichTextBox_Clicked;
                tb.Location = new Point(restorie.X, restorie.Y);
                tb.Size = new Size(restorie.W, restorie.H);
                tb.uniqueID = restorie.ID;
                myform.Controls.Add(tb);
                ListOfTextBox.Add(tb);
                boxCounter++;

            }
        }
    
    
    }



}
