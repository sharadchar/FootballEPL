using FootballEPL.BusinessLogic;
using FootballEPL.Common;
using FootballEPL.Mapper;
using FootballEPL.Model;
using FootballEPL.Repository;
using FootballEPL.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEPL
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger _logger = new ConsoleLogger();
            try
            {
                IDataHub dataobj = new CSVDataReader(_logger);

                TeamRepository _teamRepo = new TeamRepository(dataobj);
                StringToFootballTeamMapper _strToFBTMapper = new StringToFootballTeamMapper(_logger);
                Validator.Validator _validator = new Validator.Validator(_logger);
                FootballTeamBL fbBL = new FootballTeamBL();
                

                //Get data from file
                List<string> teamDetails = _teamRepo.GetTeamData();
                if(teamDetails.IsNullOrEmpty())
                {
                    _logger.Log("Data cound not be retrieved");
                    Console.ReadLine();
                    return;
                }

                //Validate file structure
                bool validationCheck = _validator.ValidateDataFileStructure(teamDetails[0]);

                if (validationCheck)
                {
                    List<FootballTeam> footballTeams = _strToFBTMapper.Map(teamDetails);

                    if(footballTeams ==  null)
                    {
                        _logger.Log("Mapper would not map the team details provided");
                        Console.ReadLine();
                        return;
                    }

                    //Validate Data
                    var isDataValid = _validator.ValidateData(footballTeams);

                    if (isDataValid)
                    {
                        var team = fbBL.GetTeamWithMinGoalDifference(footballTeams);

                        //Present Result
                        Console.WriteLine("Team Name :" + team.Team);
                        Console.WriteLine("The smallest difference in ‘for’ and ‘against’ goals:" + team.ScoreDiff);
                        Console.ReadLine();
                    }
                    else
                    {
                        _logger.Log("Data is invalid!!");
                    }
                }
                else
                {
                    _logger.Log("Invalid File structure!!");
                }
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
