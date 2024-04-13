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
            RichTextBox1 = new RichTextBox();
            Number7 = new Button();
            Number8 = new Button();
            Number9 = new Button();
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
            ClearCurrent = new Button();
            Clear = new Button();
            BackSpace = new Button();
            Division = new Button();
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
            tableLayoutPanel1.Controls.Add(RichTextBox1, 0, 0);
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
            tableLayoutPanel1.Size = new Size(478, 644);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // RichTextBox1
            // 
            tableLayoutPanel1.SetColumnSpan(RichTextBox1, 4);
            RichTextBox1.Dock = DockStyle.Fill;
            RichTextBox1.Enabled = false;
            RichTextBox1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 204);
            RichTextBox1.Location = new Point(3, 3);
            RichTextBox1.Name = "RichTextBox1";
            RichTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            RichTextBox1.Size = new Size(472, 155);
            RichTextBox1.TabIndex = 0;
            RichTextBox1.Text = "0";
            RichTextBox1.Resize += RichTextBox1_Resize;
            // 
            // Number7
            // 
            Number7.Dock = DockStyle.Fill;
            Number7.Font = new Font("Segoe UI", 18F);
            Number7.Location = new Point(3, 260);
            Number7.Name = "Number7";
            Number7.Size = new Size(113, 90);
            Number7.TabIndex = 5;
            Number7.Text = "7";
            Number7.UseVisualStyleBackColor = true;
            Number7.Click += Number7_Click;
            // 
            // Number8
            // 
            Number8.Dock = DockStyle.Fill;
            Number8.Font = new Font("Segoe UI", 18F);
            Number8.Location = new Point(122, 260);
            Number8.Name = "Number8";
            Number8.Size = new Size(113, 90);
            Number8.TabIndex = 6;
            Number8.Text = "8";
            Number8.UseVisualStyleBackColor = true;
            Number8.Click += Number8_Click;
            // 
            // Number9
            // 
            Number9.Dock = DockStyle.Fill;
            Number9.Font = new Font("Segoe UI", 18F);
            Number9.Location = new Point(241, 260);
            Number9.Name = "Number9";
            Number9.Size = new Size(113, 90);
            Number9.TabIndex = 7;
            Number9.Text = "9";
            Number9.UseVisualStyleBackColor = true;
            Number9.Click += Number9_Click;
            // 
            // Number4
            // 
            Number4.Dock = DockStyle.Fill;
            Number4.Font = new Font("Segoe UI", 18F);
            Number4.Location = new Point(3, 356);
            Number4.Name = "Number4";
            Number4.Size = new Size(113, 90);
            Number4.TabIndex = 9;
            Number4.Text = "4";
            Number4.UseVisualStyleBackColor = true;
            Number4.Click += Number4_Click;
            // 
            // Number5
            // 
            Number5.Dock = DockStyle.Fill;
            Number5.Font = new Font("Segoe UI", 18F);
            Number5.Location = new Point(122, 356);
            Number5.Name = "Number5";
            Number5.Size = new Size(113, 90);
            Number5.TabIndex = 10;
            Number5.Text = "5";
            Number5.UseVisualStyleBackColor = true;
            Number5.Click += Number5_Click;
            // 
            // Number6
            // 
            Number6.Dock = DockStyle.Fill;
            Number6.Font = new Font("Segoe UI", 18F);
            Number6.Location = new Point(241, 356);
            Number6.Name = "Number6";
            Number6.Size = new Size(113, 90);
            Number6.TabIndex = 11;
            Number6.Text = "6";
            Number6.UseVisualStyleBackColor = true;
            Number6.Click += Number6_Click;
            // 
            // Multiplication
            // 
            Multiplication.Dock = DockStyle.Fill;
            Multiplication.Font = new Font("Segoe UI", 18F);
            Multiplication.Location = new Point(360, 356);
            Multiplication.Name = "Multiplication";
            Multiplication.Size = new Size(115, 90);
            Multiplication.TabIndex = 12;
            Multiplication.Text = "*";
            Multiplication.UseVisualStyleBackColor = true;
            Multiplication.Click += Multiplication_Click;
            // 
            // Number1
            // 
            Number1.Dock = DockStyle.Fill;
            Number1.Font = new Font("Segoe UI", 18F);
            Number1.Location = new Point(3, 452);
            Number1.Name = "Number1";
            Number1.Size = new Size(113, 90);
            Number1.TabIndex = 13;
            Number1.Text = "1";
            Number1.UseVisualStyleBackColor = true;
            Number1.Click += Number1_Click;
            // 
            // Number2
            // 
            Number2.Dock = DockStyle.Fill;
            Number2.Font = new Font("Segoe UI", 18F);
            Number2.Location = new Point(122, 452);
            Number2.Name = "Number2";
            Number2.Size = new Size(113, 90);
            Number2.TabIndex = 14;
            Number2.Text = "2";
            Number2.UseVisualStyleBackColor = true;
            Number2.Click += Number2_Click;
            // 
            // Number3
            // 
            Number3.Dock = DockStyle.Fill;
            Number3.Font = new Font("Segoe UI", 18F);
            Number3.Location = new Point(241, 452);
            Number3.Name = "Number3";
            Number3.Size = new Size(113, 90);
            Number3.TabIndex = 15;
            Number3.Text = "3";
            Number3.UseVisualStyleBackColor = true;
            Number3.Click += Number3_Click;
            // 
            // Subtraction
            // 
            Subtraction.Dock = DockStyle.Fill;
            Subtraction.Font = new Font("Segoe UI", 18F);
            Subtraction.Location = new Point(360, 452);
            Subtraction.Name = "Subtraction";
            Subtraction.Size = new Size(115, 90);
            Subtraction.TabIndex = 16;
            Subtraction.Text = "-";
            Subtraction.UseVisualStyleBackColor = true;
            Subtraction.Click += Subtraction_Click;
            // 
            // Number0
            // 
            Number0.Dock = DockStyle.Fill;
            Number0.Font = new Font("Segoe UI", 18F);
            Number0.Location = new Point(3, 548);
            Number0.Name = "Number0";
            Number0.Size = new Size(113, 93);
            Number0.TabIndex = 17;
            Number0.Text = "0";
            Number0.UseVisualStyleBackColor = true;
            Number0.Click += Number0_Click;
            // 
            // Point
            // 
            Point.Dock = DockStyle.Fill;
            Point.Font = new Font("Segoe UI", 18F);
            Point.Location = new Point(122, 548);
            Point.Name = "Point";
            Point.Size = new Size(113, 93);
            Point.TabIndex = 18;
            Point.Text = ",";
            Point.UseVisualStyleBackColor = true;
            Point.Click += Point_Click;
            // 
            // GetResult
            // 
            GetResult.Dock = DockStyle.Fill;
            GetResult.Font = new Font("Segoe UI", 18F);
            GetResult.Location = new Point(241, 548);
            GetResult.Name = "GetResult";
            GetResult.Size = new Size(113, 93);
            GetResult.TabIndex = 19;
            GetResult.Text = "=";
            GetResult.UseVisualStyleBackColor = true;
            GetResult.Click += GetResult_Click;
            // 
            // Addition
            // 
            Addition.Dock = DockStyle.Fill;
            Addition.Font = new Font("Segoe UI", 18F);
            Addition.Location = new Point(360, 548);
            Addition.Name = "Addition";
            Addition.Size = new Size(115, 93);
            Addition.TabIndex = 20;
            Addition.Text = "+";
            Addition.UseVisualStyleBackColor = true;
            Addition.Click += Addition_Click;
            // 
            // ClearCurrent
            // 
            ClearCurrent.Dock = DockStyle.Fill;
            ClearCurrent.Font = new Font("Segoe UI", 18F);
            ClearCurrent.Location = new Point(3, 164);
            ClearCurrent.Name = "ClearCurrent";
            ClearCurrent.Size = new Size(113, 90);
            ClearCurrent.TabIndex = 2;
            ClearCurrent.Text = "CE";
            ClearCurrent.UseVisualStyleBackColor = true;
            ClearCurrent.Click += ClearCurrent_Click;
            // 
            // Clear
            // 
            Clear.Dock = DockStyle.Fill;
            Clear.Font = new Font("Segoe UI", 18F);
            Clear.Location = new Point(122, 164);
            Clear.Name = "Clear";
            Clear.Size = new Size(113, 90);
            Clear.TabIndex = 3;
            Clear.Text = "C";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += Clear_Click;
            // 
            // BackSpace
            // 
            tableLayoutPanel1.SetColumnSpan(BackSpace, 2);
            BackSpace.Dock = DockStyle.Fill;
            BackSpace.Font = new Font("Segoe UI", 18F);
            BackSpace.Location = new Point(241, 164);
            BackSpace.Name = "BackSpace";
            BackSpace.Size = new Size(234, 90);
            BackSpace.TabIndex = 4;
            BackSpace.Text = "del";
            BackSpace.UseVisualStyleBackColor = true;
            BackSpace.Click += BackSpace_Click;
            // 
            // Division
            // 
            Division.Dock = DockStyle.Fill;
            Division.Font = new Font("Segoe UI", 18F);
            Division.Location = new Point(360, 260);
            Division.Name = "Division";
            Division.Size = new Size(115, 90);
            Division.TabIndex = 8;
            Division.Text = "/";
            Division.UseVisualStyleBackColor = true;
            Division.Click += Division_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 644);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(400, 500);
            Name = "Form1";
            Text = "Calculator";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private RichTextBox RichTextBox1;
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
