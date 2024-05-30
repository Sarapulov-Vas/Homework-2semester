// <copyright file="Program.cs" company="Sarapuliv Vasiliy">
// Copyright (c) Sarapuliv Vasiliy. All rights reserved.
// </copyright>

namespace EscapeButton
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}