using FootballEPL.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FootballEPL.Services
{
    public class CsvDataReaderService : ICsvDataReader
    {
        ILogger _logger;

        public CsvDataReaderService(ILogger logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Get list of Fteam with validation check
        /// </summary>
        /// <returns> Return list of Fteam</returns>
        public List<string> GetData()
        {
            List<string> dataread ;
            try
            {
                //Get embedded resource file
                var resourceName = "FootballEPL.Files.football.csv";
                var assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string result = reader.ReadToEnd();
                        dataread = result.Split('\n').ToList();
                    }
                }

                return dataread;
            }
            catch (Exception ex)
            {
                _logger.Log("File reading error.");
            }

            return null;
        }
    }
}
