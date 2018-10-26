using FootballEPL.Common;
using FootballEPL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEPL.Services
{
    public class FootballTeamService
    {
        public FootballTeam GetTeamWithMinGoalDifference(List<FootballTeam> teams)
        {
            if (teams.IsNullOrEmpty()) return null;

            //Calculate difference between for and against goals
            teams.ForEach(x => x.ScoreDiff = Math.Abs(int.Parse(x.F) - int.Parse(x.A)));

            //Find minimum
            int minvalue = teams.Min(x => x.ScoreDiff.Value);
            return teams.Where(x => x.ScoreDiff == minvalue).FirstOrDefault();
        }
    }
}
