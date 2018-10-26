
using FootballEPL.Common;
using FootballEPL.Mapper;
using FootballEPL.Model;
using FootballEPL.Repositories;
using FootballEPL.Services;
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
                ICsvDataReader dataobj = new CsvDataReaderService(_logger);

                TeamRepository _teamRepo = new TeamRepository(dataobj);
                StringToFootballTeamMapper _strToFBTMapper = new StringToFootballTeamMapper(_logger);
                CsvFileValidatorService _csvValidator = new CsvFileValidatorService(_logger);
                FootballTeamService fbtService = new FootballTeamService();
                

                //Get data from file
                List<string> teamDetails = _teamRepo.GetTeamData();
                if(teamDetails.IsNullOrEmpty())
                {
                    _logger.Log("Data cound not be retrieved");
                    Console.ReadLine();
                    return;
                }

                //Validate file structure
                bool validationCheck = _csvValidator.ValidateDataFileStructure(teamDetails[0]);

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
                    var isDataValid = _csvValidator.ValidateData(footballTeams);

                    if (isDataValid)
                    {
                        var team = fbtService.GetTeamWithMinGoalDifference(footballTeams);

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
