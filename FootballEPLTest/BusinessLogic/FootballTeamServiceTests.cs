using FootballEPL.Model;
using FootballEPL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            var team = _footballTeamService.GetTeamWithMinGoalDifference(teams);

            //Assert
            Assert.IsNotNull(team);
            Assert.IsTrue(team[0].Team == "Test3");
            Assert.IsTrue(team[0].ScoreDiff == 20);
        }

        [TestMethod()]
        public void GetTeamWithMinGoalDiff_MultipleTeamTest()
        {
            //Setup
            List<FootballTeam> teams = new List<FootballTeam>
            {
                new FootballTeam
                {
                    Team="Test1", A="65", D="56", F="62", L="45", P="43", Pts="23", W="21"
                },
                new FootballTeam
                {
                    Team="Test2", A="55", D="56", F="25", L="45", P="43", Pts="23", W="21"
                },
                new FootballTeam
                {
                    Team="Test3", A="35", D="56", F="32", L="45", P="43", Pts="23", W="21"
                }
            };

            //Act
            var team = _footballTeamService.GetTeamWithMinGoalDifference(teams);

            //Assert
            Assert.IsNotNull(team);
            Assert.IsTrue(team.Count==2);
            Assert.IsTrue(team[0].Team == "Test1");
            Assert.IsTrue(team[0].ScoreDiff == 3);

            Assert.IsTrue(team[1].Team == "Test3");
            Assert.IsTrue(team[1].ScoreDiff == 3);
        }

        [TestMethod()]
        public void GetTeamWithMinGoalDiffNullTest()
        {
            //Setup
            List<FootballTeam> teams = null;

            //Act
            var team = _footballTeamService.GetTeamWithMinGoalDifference(teams);

            //Assert
            Assert.IsNull(team);
        }

        [TestMethod()]
        public void GetTeamWithMinGoalDiffEmptyTest()
        {
            //Setup
            List<FootballTeam> teams = new List<FootballTeam>();

            //Act
            var team = _footballTeamService.GetTeamWithMinGoalDifference(teams);

            //Assert
            Assert.IsNull(team);
        }
    }
}