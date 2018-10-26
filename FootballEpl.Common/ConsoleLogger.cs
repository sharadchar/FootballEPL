using System;

namespace FootballEPL.Common
{
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Logs error from all classes
        /// </summary>
        /// <param name="message">Error message recieved from classes</param>
        public void Log(string message)
        {
            Console.WriteLine(message);
            //Console.ReadLine();
        }
    }
}
