using Microsoft.Extensions.Logging;
using System;

namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }



    internal static partial class generatedLoggers
    {
        [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "Message 1")]
        internal static partial void MyInfo(this ILogger logger);


        [LoggerMessage(EventId = 2, Level = LogLevel.Trace, Message = "Message 2")]
        internal static partial void MyDebug(this ILogger logger);
    }
}



