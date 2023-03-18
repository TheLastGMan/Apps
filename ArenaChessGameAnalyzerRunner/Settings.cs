using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzerRunner
{
    class Settings
    {
        private static string getSetting(string name)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(name))
                return ConfigurationManager.AppSettings[name];
            else
                throw new Exception("Unable to find setting: " + name);
        }

        public static string PickupFolder
        {
            get { return getSetting("PickupFolder"); }
        }

        public static string DropFolder
        {
            get { return getSetting("DropFolder"); }
        }

        public static string ErrorFolder
        {
            get { return getSetting("ErrorFolder"); }
        }

        public static string EcoFile
        {
            get { return getSetting("EcoFile"); }
        }

        public static string ArenaExe
        {
            get { return getSetting("ArenaExe"); }
        }

        public static string AnalysisExe
        {
            get { return getSetting("AnalysisExe"); }
        }

        public static int SecondsPerMove
        {
            get { return int.Parse(getSetting("SecondsPerMove")); }
        }

        public static int LastMoveNumber
        {
            get { return int.Parse(getSetting("LastMoveNumber")); }
        }
        public static int RetryCount
        {
            get { return int.Parse(getSetting("RetryCount")); }
        }

        public static int ServiceSleepIntervalMinutes
        {
            get { return int.Parse(getSetting("ServiceSleepIntervalMinutes")); }
        }
    }
}
