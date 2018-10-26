using FootballEPL.Common;
using FootballEPL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FootballEPL.Services
{
    public class CsvFileValidatorService
    {
        ILogger _logger;

        public CsvFileValidatorService(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This method takes a coma seperated column names string and validate the column names 
        /// as per the expected valid file columns
        /// </summary>
        /// <param name="csvDataColumns"></param>
        /// <returns>Returns a bool response about the validity of the input csvDataColumn list</returns>
        public bool ValidateDataFileStructure(string csvDataColumns)
        {
            if (string.IsNullOrWhiteSpace(csvDataColumns)) return false;

            //Check colum count and Column names of file are valid
            var headerColumns = csvDataColumns.Split(',').ToList().Select(x=>x.Trim());
            
            var headerColumnsCount = headerColumns.Count();
            if (headerColumnsCount == 9)
            {
                List<string> columnsNames = new List<string>() { "Team", "P", "W", "L", "D", "F", "A", "Pts" };

                bool iscolumnExist = true;
                try
                {
                    if (headerColumns != null)
                    {
                        foreach (string columnName in columnsNames)
                        {
                            if (!headerColumns.Contains(columnName))
                            {
                                iscolumnExist = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        iscolumnExist = false;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Log("Column name is not valid" + ex.InnerException);
                }
                return iscolumnExist;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method validate the data provided for F and A columns. Is the data is not an integer then this method result into a false 
        /// response else true.
        /// </summary>
        /// <param name="footballTeam"></param>
        /// <returns>return bool response</returns>
        public bool ValidateData(List<FootballTeam> footballTeam)
        {
            if (footballTeam.IsNullOrEmpty()) return false;
            
            try
            {
                foreach(var team in footballTeam)
                {
                    if(!int.TryParse(team.A,out int resultA) || !int.TryParse(team.F, out int resultF))
                    {
                        return false;
                    }
                }
            }
            catch(Exception Ex)
            {
                _logger.Log("Error happened while validating data. Exception: " + Ex.Message);
            }
            return true;
        }
    }
}
