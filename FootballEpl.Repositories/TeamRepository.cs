using FootballEPL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEPL.Repositories
{
    public class TeamRepository
    {        
        ICsvDataReader _dataReader;
        public TeamRepository(ICsvDataReader dataReader)
        {
            _dataReader = dataReader;            
        }

        /// <summary>
        /// This method fetch team with absolute score difference
        /// </summary>
        /// <param name="footballData"></param>
        /// <returns> Return Fteam</returns>
        public List<string> GetTeamData()
        {
            List<string> footballData = _dataReader.GetData() ; 
           
            return footballData;
        }
    }
}
