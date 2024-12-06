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



    internal static partial class OutboxLoggers
    {
        [LoggerMessage(Level = LogLevel.Information, Message = "OutboxBackgroundService starting...")]
        internal static partial void LogStarting(this ILogger logger);

    }
}



