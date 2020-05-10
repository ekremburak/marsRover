using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MarsRover.Utility
{
    public static class Logger
    {
        public static DirectoryInfo DirectoryInfo { get; private set; }

        private static DirectoryInfo CreateDirectory()
        {

            string basePath = "Logs";


            //basePath = "Logs";//mac test 

            //basePath += "\\" + DateTime.Now.Date.ToString("yyyyMMdd");

            if (!Directory.Exists(basePath))
            {
                return Directory.CreateDirectory(basePath);
            }

            return new DirectoryInfo(basePath);
        }


        public static void WriteToFile(string text)
        {
            try
            {
                DirectoryInfo = CreateDirectory();

                string path = Path.Combine(DirectoryInfo.FullName, $"MarsRoverLog_{DateTime.Now.Date.ToString("ddMMyyyy")}.txt");
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"{DateTime.Now} {text}");
                    sw.Close();
                }
            }
            finally
            {
                
            }
        }

    }
}
