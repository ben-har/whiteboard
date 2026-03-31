namespace whiteboard
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Console = new RichTextBox();
            SuspendLayout();
            // 
            // Console
            // 
            Console.BackColor = SystemColors.WindowText;
            Console.BorderStyle = BorderStyle.None;
            Console.DetectUrls = false;
            Console.Font = new Font("Segoe UI Variable Small Semibol", 9F);
            Console.ForeColor = Color.FromArgb(0, 64, 0);
            Console.Location = new Point(4, 11);
            Console.Margin = new Padding(3, 2, 3, 2);
            Console.Name = "Console";
            Console.ReadOnly = true;
            Console.ScrollBars = RichTextBoxScrollBars.Vertical;
            Console.Size = new Size(350, 225);
            Console.TabIndex = 0;
            Console.Text = "";
           
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(1684, 812);
            Controls.Add(Console);
            Name = "Form1";
            Text = "WhiteBoard";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox Console;
    }
}
