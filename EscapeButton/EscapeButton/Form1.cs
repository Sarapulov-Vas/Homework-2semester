// <copyright file="Form1.cs" company="Sarapulov Vasiliy">
// Copyright (c) Sarapuliv Vasiliy. All rights reserved.
// </copyright>

namespace EscapeButton
{
    /// <summary>
    /// A class that implements a form.
    /// </summary>
    public partial class Form1 : Form
    {
        private Random rnd = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonReposition(object sender, EventArgs e)
        {
                this.button1.Location = new Point(
                    this.rnd.Next(this.Width - this.button1.Width),
                    this.rnd.Next(this.Height - this.button1.Height));

        }
    }
}
