using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSS.Helper
{
    public static class FileHelper
    {
        public static string GetAppDir()
        {
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string appDir = Path.Combine(directory, typeof(Program).Assembly.GetName().Name);
            Directory.CreateDirectory(appDir);
            return appDir;
        }

    }
}
