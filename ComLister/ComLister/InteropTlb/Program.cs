// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Saxo Bank A/S">
//   Tester App
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace ComLister
{
    /// <summary>
    /// The main app starting point
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ComListerForm());
        }
    }
}
