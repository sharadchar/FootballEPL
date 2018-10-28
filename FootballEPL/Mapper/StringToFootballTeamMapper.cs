using FootballEPL.Common;
using FootballEPL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballEPL.Mapper
{
    public class StringToFootballTeamMapper : IBaseMapper
    {
        private ILogger _logger;

        public StringToFootballTeamMapper(ILogger logger)
        {
            _logger = logger;
        }        

        /// <summary>
        /// This method maps the string data read from the file to the list of football entity 
        /// </summary>
        /// <param name="teamsData"></param>
        /// <returns></returns>
        public List<FootballTeam> Map(List<string> teamsData)
        {
            if (teamsData.IsNullOrEmpty()) return null;

            List<FootballTeam> result = new List<FootballTeam>();
            try
            {
                if (teamsData.IsNullOrEmpty())
                {
                    _logger.Log("Data is not provided");
                    return null;
                }
                else
                {
                    foreach (var data in teamsData)
                    {
                        data.Replace('-', ' ');
                    }

                    var header = teamsData[0].Split(',').ToList().Select(x => x.Trim()).ToList();
                    teamsData = teamsData.Select(x => x.Replace('-', ' ')).ToList();

                    teamsData.Remove(teamsData.ElementAt(0));

                    foreach (var data in teamsData)
                    {
                        if (string.IsNullOrWhiteSpace(data))
                        {
                            continue;
                        }

                        var dataSplit = data.Split(',').ToList().Select(x => x.Trim()).ToArray();

                        FootballTeam team = new FootballTeam();
                        team.Team = dataSplit[header.FindIndex(x => x == "Team")];
                        team.P = dataSplit[header.FindIndex(x => x == "P")];
                        team.W = dataSplit[header.FindIndex(x => x == "W")];
                        team.L = dataSplit[header.FindIndex(x => x == "L")];
                        team.D = dataSplit[header.FindIndex(x => x == "D")];
                        team.F = dataSplit[header.FindIndex(x => x == "F")];
                        team.A = dataSplit[header.FindIndex(x => x == "A")];
                        team.Pts = dataSplit[header.FindIndex(x => x == "Pts")];

                        result.Add(team);
                    }
                    return result;
                }
            }
            catch(Exception ex)
            {
                _logger.Log("Error: Mapping error " + ex.Message);
                return null;
            }
        }
    }
}
