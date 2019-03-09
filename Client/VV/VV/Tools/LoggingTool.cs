using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.Tools
{

    /// <summary>
    /// Simple file logging, should work for this application
    /// </summary>
    class LoggingTool
    {
        private String logFileWithLocation;
        private String logfileDirectory;
        private String logFileSave;


        public LoggingTool()
        {
            logfileDirectory = $"{Directory.GetCurrentDirectory()}\\LogData";
            logFileWithLocation = $"{logfileDirectory}\\logfile.txt";
            logFileSave = $"{logfileDirectory}\\logfile.txt.bak";
            // Check if the directory exists
            if (!Directory.Exists(logfileDirectory))
            {
                Directory.CreateDirectory(logfileDirectory);
            }
        }

        public void Write(String txt)
        {
            // get rid of old stuff
            if(File.Exists(logFileWithLocation))
            {
                long fileLength = new System.IO.FileInfo(logFileWithLocation).Length;
                if (fileLength > 3000)
                {
                    File.Delete(logFileSave);
                    System.IO.File.Move(logFileWithLocation, logFileSave);
                    File.Delete(logFileWithLocation);
                }
            }
            // write new stuff
            File.AppendAllText(logFileWithLocation, txt);
        }

    }
}
