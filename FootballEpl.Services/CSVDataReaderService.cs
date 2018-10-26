using FootballEPL.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FootballEPL.Services
{
    public class CsvDataReaderService : ICsvDataReader
    {
        private ILogger _logger;
        private string _filePath;

        public CsvDataReaderService(ILogger logger, string filePath)
        {
            _logger = logger;
            _filePath = filePath;
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
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    string result = sr.ReadToEnd();
                    dataread = result.Split('\n').ToList();
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
