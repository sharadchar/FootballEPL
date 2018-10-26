using FootballEPL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEPL.Repository
{
    public class TeamRepository
    {        
        IDataHub datahub;
        public TeamRepository(IDataHub dataHub)
        {
            datahub = dataHub;            
        }

        /// <summary>
        /// This method fetch team with absolute score difference
        /// </summary>
        /// <param name="footballData"></param>
        /// <returns> Return Fteam</returns>
        public List<string> GetTeamData()
        {
            List<string> footballData = datahub.GetData() ; 
           
            return footballData;
        }
    }
}
