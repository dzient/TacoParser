using System;
//-----------------------------------------------------------------
// TacoParser Exercise
//
// Name: David Zientara
// Date: 8-13-2022
// Comments: An exercise in parsing a CSV
// Made changes per the instructions
//----------------------------------------------------------------
// This class writes logging data to the console
namespace LoggingKata
{
    public class TacoLogger : ILog
    {
        // LogFatal
        // Writes a fatal error
        // PARAMS: log (string), exception (Exception)
        // RETURNS: Nothing
        public void LogFatal(string log, Exception exception = null)
        {
            Console.WriteLine($"Fatal: {log}, Exception {exception}");
        }
        // LogFatal
        // Writes a log error
        // PARAMS: log (string), exception (Exception)
        // RETURNS: Nothing
        public void LogError(string log, Exception exception = null)
        {
            Console.WriteLine($"Error: {log}, Exception {exception}");
        }
        // LogWarning
        // Indicates a warning
        // PARAMS: log (string)
        // RETURNS: Nothing
        public void LogWarning(string log)
        {
            Console.WriteLine($"Warning: {log}");
        }
        // LogInfo
        // Logs information to the console
        // PARAMS: log (string) 
        // RETURNS: Nothing
        public void LogInfo(string log)
        {
            Console.WriteLine($"Info: {log}");
        }
        // LogDebug
        // Logs debugging information to the console
        // PARAMS: log (string)
        // RETURNS: Nothing
        public void LogDebug(string log)
        {
            Console.WriteLine($"Debug: {log}");
        }
    }
}
