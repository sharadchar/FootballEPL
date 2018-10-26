using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballEPL.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballEPL.Common;
using Moq;

namespace Mapper
{
    [TestClass()]
    public class MapperTests
    {
        private Mock<ILogger> mockLogger;
        private IBaseMapper _stringToFootballTeamMapper;

        [TestInitialize]
        public void testInit()
        {
            mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Log(It.IsAny<string>()));

            _stringToFootballTeamMapper = new StringToFootballTeamMapper(mockLogger.Object);
        }

        [TestMethod()]
        public void Map_teamDataNullTest()
        {
            //Setup
            List<string> teamsData = null;            

            

            //Act
            var result = _stringToFootballTeamMapper.Map(teamsData);

            //Assert
            Assert.IsTrue(result == null);
        }

        [TestMethod()]
        public void Map_teamDataEmptyTest()
        {
            //Setup
            List<string> teamsData = new List<string>();

            //Act
            var result = _stringToFootballTeamMapper.Map(teamsData);

            //Assert
            Assert.IsTrue(result == null);
        }

        [TestMethod()]
        public void Map_teamDataTest()
        {
            //Setup
            List<string> teamsData = new List<string>
            {
                "Team,P,W,L,D  ,F, -   ,A,Pts",
                "2. Liverpool,38,24,8,6,67,-,30,80",
                "-------------------------------------------------------",
                "18. Ipswich,38,9,9,20,41,-,64,36"
            };

            //Act
            var result = _stringToFootballTeamMapper.Map(teamsData);

            //Assert
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Count == 2);

            Assert.IsTrue(result[0].Team == "2. Liverpool");
            Assert.IsTrue(result[0].P == "38");
            Assert.IsTrue(result[0].W == "24");
            Assert.IsTrue(result[0].L == "8");
            Assert.IsTrue(result[0].D == "6");            
            Assert.IsTrue(result[0].F == "67");
            Assert.IsTrue(result[0].A == "30");
            Assert.IsTrue(result[0].Pts == "80");

            Assert.IsTrue(result[1].Team == "18. Ipswich");
            Assert.IsTrue(result[1].P == "38");
            Assert.IsTrue(result[1].W == "9");
            Assert.IsTrue(result[1].L == "9");
            Assert.IsTrue(result[1].D == "20");
            Assert.IsTrue(result[1].F == "41");
            Assert.IsTrue(result[1].A == "64");
            Assert.IsTrue(result[1].Pts == "36");
        }
    }
}