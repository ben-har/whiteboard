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
            Console.Location = new Point(5, 15);
            Console.Name = "Console";
            Console.ReadOnly = true;
            Console.ScrollBars = RichTextBoxScrollBars.Vertical;
            Console.Size = new Size(400, 300);
            Console.TabIndex = 0;
            Console.Text = "";
            Console.TextChanged += Console_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(1924, 1083);
            Controls.Add(Console);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "WhiteBoard";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox Console;
    }
}
