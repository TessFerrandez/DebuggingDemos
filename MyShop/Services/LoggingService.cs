using System;
using System.IO;

namespace MyShop.Services
{
    public class LoggingService
    {
        public static void WriteToLog(string message, string file)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.WriteLine("____________________________");
                    sw.WriteLine(DateTime.Now.ToLongTimeString());
                    sw.WriteLine("____________________________");
                    sw.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
            }
        }
    }
}