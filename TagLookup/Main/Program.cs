using System;
using System.Windows.Forms;

namespace TagLookup
{
    static class Program
    {
        // used by the configuration files to pass a generic type argument
        public static object obj;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new TagLookup() );
        }
    }
}
