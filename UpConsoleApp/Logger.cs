using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpConsoleApp
{
   public static class Logger
    {
        private static FileStream fileStream = null; 
        public static FileStream FileStream
        {
            get
            {
                if (fileStream == null)
                {
                    var logFilePath = "Log-" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + "." + "txt";
                    var logFileInfo = new FileInfo(logFilePath);
                    fileStream = new FileStream(logFilePath, FileMode.Append);
                    fileStream.Close();


                }
                return fileStream;
            }
        }
        public static void LogThis(string message)
        {
            StreamReader streamReader = new StreamReader(FileStream.Name);
            var OldLog = streamReader.ReadToEnd();
            streamReader.Close();

            var log = new StreamWriter(FileStream.Name);
            log.WriteLine(OldLog + message);
            log.Close();

        }

        public static void CreateLogFile()
        {
            
           
        }
    }
}
