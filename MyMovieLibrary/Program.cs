using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMovieLibrary
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            checkInitialFolderConditions();
            Application.Run(new MainScreen());
        }

        private static void checkInitialFolderConditions()
        {
            if (Directory.Exists(Constants.tempImagesPath))
            {
                DirectoryInfo di = new DirectoryInfo(Constants.tempImagesPath);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }
            else
            {
                Directory.CreateDirectory(Constants.tempImagesPath);
            }
            if (!Directory.Exists(Constants.libraryImagesPath))
            {
                Directory.CreateDirectory(Constants.libraryImagesPath);
            }
        }
    }
}
