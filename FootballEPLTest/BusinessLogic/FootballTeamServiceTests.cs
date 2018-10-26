using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballEPL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballEPL.Model;

namespace BusinessLogic
{
    [TestClass()]
    public class FootballTeamServiceTests
    {
        FootballTeamService _footballTeamService;

        [TestInitialize]
        public void testInit()
        {
            _footballTeamService = new FootballTeamService();
        }

        [TestMethod()]
        public void GetTeamWithMinGoalDiffTest()
        {
            //Setup
            List<FootballTeam> teams = new List<FootballTeam>
            {
                new FootballTeam
                {
                    Team="Test1", A="65", D="56", F="42", L="45", P="43", Pts="23", W="21"
                },
                new FootballTeam
                {
                    Team="Test2", A="55", D="56", F="25", L="45", P="43", Pts="23", W="21"
                },
                new FootballTeam
                {
                    Team="Test3", A="35", D="56", F="15", L="45", P="43", Pts="23", W="21"
                }
            };

            //Act
            FootballTeam team = _footballTeamService.GetTeamWithMinGoalDifference(teams);

            //Assert
            Assert.IsNotNull(team);
            Assert.IsTrue(team.Team == "Test3");
            Assert.IsTrue(team.ScoreDiff == 20);
        }

        [TestMethod()]
        public void GetTeamWithMinGoalDiffNullTest()
        {
            //Setup
            List<FootballTeam> teams = null;

            //Act
            FootballTeam team = _footballTeamService.GetTeamWithMinGoalDifference(teams);

            //Assert
            Assert.IsNull(team);
        }

        [TestMethod()]
        public void GetTeamWithMinGoalDiffEmptyTest()
        {
            //Setup
            List<FootballTeam> teams = new List<FootballTeam>();

            //Act
            FootballTeam team = _footballTeamService.GetTeamWithMinGoalDifference(teams);

            //Assert
            Assert.IsNull(team);
        }
    }
}