using System;
//-----------------------------------------------------------------
// TacoParser Exercise
//
// Name: David Zientara
// Date: 8-13-2022
// Comments: An exercise in parsing a CSV
// Made changes per the instructions
// Create an Ilog interface 
//----------------------------------------------------------------
namespace LoggingKata
{
    public interface ILog
    {
        void LogFatal(string log, Exception exception = null);
        void LogError(string log, Exception exception = null);
        void LogWarning(string log);
        void LogInfo(string log);
        void LogDebug(string log);
    }
}
