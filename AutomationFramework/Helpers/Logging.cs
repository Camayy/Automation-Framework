using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Helpers
{
    public class Logging
    {
        private static string _logFile;
        private static StreamWriter _streamWriter = null;

        /// <summary>
        /// Creates the log file at current directory
        /// </summary>
        public static void CreateLogFile()
        {
            _logFile = string.Format("{0:yyyymmddhmmss}", DateTime.Now);
            string dir = Environment.CurrentDirectory.ToString() + "\\Logs";

            if (Directory.Exists(dir))
            {
                _streamWriter = File.AppendText(dir + _logFile + ".txt");
                _streamWriter.Write("File created: {0}", DateTime.Now);
            }
            else
            {
                Directory.CreateDirectory(dir);

                _streamWriter = File.AppendText(dir + _logFile + ".txt");
                _streamWriter.Write("File created: {0}", DateTime.Now);
                _streamWriter.Write("File Location: {0}", Environment.CurrentDirectory.ToString());
            }
        }

        /// <summary>
        /// Writes text to the log file
        /// </summary>
        /// <param name="message"></param>
        public static void Write(string message)
        {
            _streamWriter.Write("{0} -,{1}", message, DateTime.Now);
            _streamWriter.Flush();
        }

        //create file
            //check directory exists
        //write to file
        //save file
    }
}
