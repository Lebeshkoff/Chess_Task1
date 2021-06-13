using System;
using System.Collections.Generic;

namespace Chess
{
    /// <summary>
    /// Class who may save logs
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// List with logs
        /// </summary>
        private static List<string> _logList = new List<string>();

        /// <summary>
        /// Add information to log 
        /// </summary>
        /// <param name="log">Log information</param>
        public static void AddActionToLog(string log)
        {
            _logList.Add(log);
        }

        /// <summary>
        /// Use for get logs
        /// </summary>
        /// <returns>List of strings</returns>
        public static List<string> GetLogList()
        {
            return _logList;
        }
    }
}