using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
