using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          ////  ProcessStartInfo Startinfo = new ProcessStartInfo();
           ////  Startinfo.FileName = "Taskkill";
           ///// Startinfo.Arguments = "/t /f /im explorer.exe";
           //// Process.Start(Startinfo);

             Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}