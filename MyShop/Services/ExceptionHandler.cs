using System;

namespace MyShop.Services
{
    public class ExceptionHandler
    {
        public static void LogException(Exception ex)
        {
            LoggingService.WriteToLog(ex.Message, @"c:\log.txt");
        }
    }
}