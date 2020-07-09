using System;
using System.Collections;

namespace LogManeger
{
    public interface ILog
    {
        void Log(LogLevel level, Type type, Exception exception, Hashtable parameters = null);
        void Log(LogLevel level, Type type, string message, Hashtable parameters = null);
    }
}