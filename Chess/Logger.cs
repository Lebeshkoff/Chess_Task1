using System;
using System.Collections.Generic;

namespace Chess
{
    public static class Logger
    {
        private static List<string> _logList = new List<string>();

        public static void AddActionToLog(string log)
        {
            _logList.Add(log);
        }

        public static List<string> GetLogList()
        {
            return _logList;
        }
    }
}