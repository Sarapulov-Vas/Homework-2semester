namespace GUICalculator
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
            tableLayoutPanel1 = new TableLayoutPanel();
            richTextBox1 = new RichTextBox();
            ClearCurrent = new Button();
            Clear = new Button();
            BackSpace = new Button();
            Number7 = new Button();
            Number8 = new Button();
            Number9 = new Button();
            Division = new Button();
            Number4 = new Button();
            Number5 = new Button();
            Number6 = new Button();
            Multiplication = new Button();
            Number1 = new Button();
            Number2 = new Button();
            Number3 = new Button();
            Subtraction = new Button();
            Number0 = new Button();
            Point = new Button();
            GetResult = new Button();
            Addition = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(richTextBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(Number7, 0, 2);
            tableLayoutPanel1.Controls.Add(Number8, 1, 2);
            tableLayoutPanel1.Controls.Add(Number9, 2, 2);
            tableLayoutPanel1.Controls.Add(Number4, 0, 3);
            tableLayoutPanel1.Controls.Add(Number5, 1, 3);
            tableLayoutPanel1.Controls.Add(Number6, 2, 3);
            tableLayoutPanel1.Controls.Add(Multiplication, 3, 3);
            tableLayoutPanel1.Controls.Add(Number1, 0, 4);
            tableLayoutPanel1.Controls.Add(Number2, 1, 4);
            tableLayoutPanel1.Controls.Add(Number3, 2, 4);
            tableLayoutPanel1.Controls.Add(Subtraction, 3, 4);
            tableLayoutPanel1.Controls.Add(Number0, 0, 5);
            tableLayoutPanel1.Controls.Add(Point, 1, 5);
            tableLayoutPanel1.Controls.Add(GetResult, 2, 5);
            tableLayoutPanel1.Controls.Add(Addition, 3, 5);
            tableLayoutPanel1.Controls.Add(ClearCurrent, 0, 1);
            tableLayoutPanel1.Controls.Add(Clear, 1, 1);
            tableLayoutPanel1.Controls.Add(BackSpace, 2, 1);
            tableLayoutPanel1.Controls.Add(Division, 3, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Size = new Size(525, 697);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            tableLayoutPanel1.SetColumnSpan(richTextBox1, 4);
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(3, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(519, 168);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // ClearCurrent
            // 
            ClearCurrent.Dock = DockStyle.Fill;
            ClearCurrent.Location = new Point(3, 177);
            ClearCurrent.Name = "ClearCurrent";
            ClearCurrent.Size = new Size(125, 98);
            ClearCurrent.TabIndex = 2;
            ClearCurrent.Text = "CE";
            ClearCurrent.UseVisualStyleBackColor = true;
            // 
            // Clear
            // 
            Clear.Dock = DockStyle.Fill;
            Clear.Location = new Point(134, 177);
            Clear.Name = "Clear";
            Clear.Size = new Size(125, 98);
            Clear.TabIndex = 3;
            Clear.Text = "C";
            Clear.UseVisualStyleBackColor = true;
            // 
            // BackSpace
            // 
            tableLayoutPanel1.SetColumnSpan(BackSpace, 2);
            BackSpace.Dock = DockStyle.Fill;
            BackSpace.Location = new Point(265, 177);
            BackSpace.Name = "BackSpace";
            BackSpace.Size = new Size(257, 98);
            BackSpace.TabIndex = 4;
            BackSpace.Text = "del";
            BackSpace.UseVisualStyleBackColor = true;
            // 
            // Number7
            // 
            Number7.Dock = DockStyle.Fill;
            Number7.Location = new Point(3, 281);
            Number7.Name = "Number7";
            Number7.Size = new Size(125, 98);
            Number7.TabIndex = 5;
            Number7.Text = "7";
            Number7.UseVisualStyleBackColor = true;
            // 
            // Number8
            // 
            Number8.Dock = DockStyle.Fill;
            Number8.Location = new Point(134, 281);
            Number8.Name = "Number8";
            Number8.Size = new Size(125, 98);
            Number8.TabIndex = 6;
            Number8.Text = "8";
            Number8.UseVisualStyleBackColor = true;
            // 
            // Number9
            // 
            Number9.Dock = DockStyle.Fill;
            Number9.Location = new Point(265, 281);
            Number9.Name = "Number9";
            Number9.Size = new Size(125, 98);
            Number9.TabIndex = 7;
            Number9.Text = "9";
            Number9.UseVisualStyleBackColor = true;
            // 
            // Division
            // 
            Division.Dock = DockStyle.Fill;
            Division.Location = new Point(396, 281);
            Division.Name = "Division";
            Division.Size = new Size(126, 98);
            Division.TabIndex = 8;
            Division.Text = "/";
            Division.UseVisualStyleBackColor = true;
            // 
            // Number4
            // 
            Number4.Dock = DockStyle.Fill;
            Number4.Location = new Point(3, 385);
            Number4.Name = "Number4";
            Number4.Size = new Size(125, 98);
            Number4.TabIndex = 9;
            Number4.Text = "4";
            Number4.UseVisualStyleBackColor = true;
            // 
            // Number5
            // 
            Number5.Dock = DockStyle.Fill;
            Number5.Location = new Point(134, 385);
            Number5.Name = "Number5";
            Number5.Size = new Size(125, 98);
            Number5.TabIndex = 10;
            Number5.Text = "5";
            Number5.UseVisualStyleBackColor = true;
            // 
            // Number6
            // 
            Number6.Dock = DockStyle.Fill;
            Number6.Location = new Point(265, 385);
            Number6.Name = "Number6";
            Number6.Size = new Size(125, 98);
            Number6.TabIndex = 11;
            Number6.Text = "6";
            Number6.UseVisualStyleBackColor = true;
            // 
            // Multiplication
            // 
            Multiplication.Dock = DockStyle.Fill;
            Multiplication.Location = new Point(396, 385);
            Multiplication.Name = "Multiplication";
            Multiplication.Size = new Size(126, 98);
            Multiplication.TabIndex = 12;
            Multiplication.Text = "*";
            Multiplication.UseVisualStyleBackColor = true;
            // 
            // Number1
            // 
            Number1.Dock = DockStyle.Fill;
            Number1.Location = new Point(3, 489);
            Number1.Name = "Number1";
            Number1.Size = new Size(125, 98);
            Number1.TabIndex = 13;
            Number1.Text = "1";
            Number1.UseVisualStyleBackColor = true;
            // 
            // Number2
            // 
            Number2.Dock = DockStyle.Fill;
            Number2.Location = new Point(134, 489);
            Number2.Name = "Number2";
            Number2.Size = new Size(125, 98);
            Number2.TabIndex = 14;
            Number2.Text = "2";
            Number2.UseVisualStyleBackColor = true;
            // 
            // Number3
            // 
            Number3.Dock = DockStyle.Fill;
            Number3.Location = new Point(265, 489);
            Number3.Name = "Number3";
            Number3.Size = new Size(125, 98);
            Number3.TabIndex = 15;
            Number3.Text = "3";
            Number3.UseVisualStyleBackColor = true;
            // 
            // Subtraction
            // 
            Subtraction.Dock = DockStyle.Fill;
            Subtraction.Location = new Point(396, 489);
            Subtraction.Name = "Subtraction";
            Subtraction.Size = new Size(126, 98);
            Subtraction.TabIndex = 16;
            Subtraction.Text = "-";
            Subtraction.UseVisualStyleBackColor = true;
            // 
            // Number0
            // 
            Number0.Dock = DockStyle.Fill;
            Number0.Location = new Point(3, 593);
            Number0.Name = "Number0";
            Number0.Size = new Size(125, 101);
            Number0.TabIndex = 17;
            Number0.Text = "0";
            Number0.UseVisualStyleBackColor = true;
            // 
            // Point
            // 
            Point.Dock = DockStyle.Fill;
            Point.Location = new Point(134, 593);
            Point.Name = "Point";
            Point.Size = new Size(125, 101);
            Point.TabIndex = 18;
            Point.Text = ",";
            Point.UseVisualStyleBackColor = true;
            // 
            // GetResult
            // 
            GetResult.Dock = DockStyle.Fill;
            GetResult.Location = new Point(265, 593);
            GetResult.Name = "GetResult";
            GetResult.Size = new Size(125, 101);
            GetResult.TabIndex = 19;
            GetResult.Text = "=";
            GetResult.UseVisualStyleBackColor = true;
            // 
            // Addition
            // 
            Addition.Dock = DockStyle.Fill;
            Addition.Location = new Point(396, 593);
            Addition.Name = "Addition";
            Addition.Size = new Size(126, 101);
            Addition.TabIndex = 20;
            Addition.Text = "+";
            Addition.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 697);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Calculator";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private RichTextBox richTextBox1;
        private Button ClearCurrent;
        private Button Clear;
        private Button BackSpace;
        private Button Number7;
        private Button Number8;
        private Button Number9;
        private Button Division;
        private Button Number4;
        private Button Number5;
        private Button Number6;
        private Button Multiplication;
        private Button Number1;
        private Button Number2;
        private Button Number3;
        private Button Subtraction;
        private Button Number0;
        private Button Point;
        private Button GetResult;
        private Button Addition;
    }
}
