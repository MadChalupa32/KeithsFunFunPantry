using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KeithsFunFunPantry.CS
{
    public enum LogLevel { Info, Warning, Error};
    public static class Logging
    {
        public static void WriteLog(LogLevel l, string message)
        {
            string logString = GetTimestamp(DateTime.Now) + " - " + l.ToString() + ": " + message + "\n";
            File.AppendAllText("log.txt", logString);
        }
        private static string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy-MM-dd HH:mm:ss:ffff");
        }
    }
}
