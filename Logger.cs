using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_2
{
    public static class Logger
    {
        public static void Log(string type, string format, params object[] args)
        {
            using (var streamWriter = new StreamWriter("C:\\Users\\BaptisteM\\RiderProjects\\TP_2\\bin\\Debug\\Test_Plugin.txt", true))
            {
                streamWriter.WriteLine("[{0}][{1}] {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),string.Format(type, args) ,string.Format(format, args));
            }
        }
    }
}