using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballEPL.Model;
using FootballEPL.Common;
using FootballEPL.Services;
using Moq;

namespace Validator.Tests
{
    
    [TestClass()]
    public class CsvFileValidatorServiceTests
    {
        private CsvFileValidatorService _csvFileValidator;
        
        Mock<ILogger> mockLogger;

        [TestInitialize]
        public void testInit()
        {
            mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Log(It.IsAny<string>()));

            _csvFileValidator = new CsvFileValidatorService(mockLogger.Object);
        }        

        [TestMethod()]
        public void FileStructure_HeaderStringEmptyTest()
        {
            //Setup
            string header = " ";

            //Act
            bool result = _csvFileValidator.ValidateDataFileStructure(header);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void FileStructure_HeaderValueAsNullTest()
        {
            //Setup
            string header = null;

            //Act
            bool result = _csvFileValidator.ValidateDataFileStructure(header);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void FileStructure_HeaderWithoutSpaceTest()
        {
            //Setup
            string header = "Team,P,W,L,D,F,-,A,Pts";

            //Act
            bool result = _csvFileValidator.ValidateDataFileStructure(header);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void FileStructure_HeaderWithSpaceTest()
        {
            //Setup
            string header = "Team, P, W  , L, D, F,  -   ,A,  Pts";

            //Act
            bool result = _csvFileValidator.ValidateDataFileStructure(header);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void FileStructure_ColumnOrderChangedTest()
        {
            //Setup
            string header = "Team, P, W  , A, D, F,  -   ,L ,  Pts";

            //Act
            bool result = _csvFileValidator.ValidateDataFileStructure(header);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void FileStructure_ExtraColumnTest()
        {
            //Setup
            string header = "Team,P,W,A,D,F,-,L,Pts,S";

            //Act
            bool result = _csvFileValidator.ValidateDataFileStructure(header);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void FileStructure_ChangedColumnNameTest()
        {
            //Setup
            string header = "Team,P,W,L1,D,F,-,A,Pts,S";

            //Act
            bool result = _csvFileValidator.ValidateDataFileStructure(header);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ValidateData_StringValueAScoreTest()
        {
            //Setup
            List<FootballTeam> footballTeams = new List<FootballTeam>
            {
                new FootballTeam
                {
                    Team="Test1", A="65A", D="56", F="25", L="45", P="43", Pts="23", W="21"
                },
                new FootballTeam
                {
                    Team="Test1", A="15", D="56", F="45a", L="45", P="43", Pts="23", W="21"
                },
            };

            //Act
            bool result = _csvFileValidator.ValidateData(footballTeams);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ValidateData_StringValueFScoreTest()
        {
            //Setup
            List<FootballTeam> footballTeams = new List<FootballTeam>
            {
                new FootballTeam
                {
                    Team="Test1", A="25", D="56", F="35", L="45", P="43", Pts="23", W="21"
                },
                new FootballTeam
                {
                    Team="Test2", A="45", D="56", F="45a", L="45", P="43", Pts="23", W="21"
                },                
                new FootballTeam
                {
                    Team="Test3", A="61", D="56", F="45", L="45", P="43", Pts="23", W="21"
                }
            };

            //Act
            bool result = _csvFileValidator.ValidateData(footballTeams);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ValidateData_StringValueFScoreMultiTest()
        {
            //Setup
            List<FootballTeam> footballTeams = new List<FootballTeam>
            {
                new FootballTeam
                {
                    Team="Test1", A="65", D="56", F="45", L="45", P="43", Pts="23", W="21"
                },
                new FootballTeam
                {
                    Team="Test2", A="55", D="56", F="45a", L="45", P="43", Pts="23", W="21"
                },
                new FootballTeam
                {
                    Team="Test3", A="35", D="56", F="15a", L="45", P="43", Pts="23", W="21"
                }
            };

            //Act
            bool result = _csvFileValidator.ValidateData(footballTeams);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ValidateData_ValidScoreTest()
        {
            //Setup
            List<FootballTeam> footballTeams = new List<FootballTeam>
            {
                new FootballTeam
                {
                    Team="Test1", A="65", D="56", F="45", L="45", P="43", Pts="23", W="21"
                },
                new FootballTeam
                {
                    Team="Test2", A="55", D="56", F="45", L="45", P="43", Pts="23", W="21"
                },
                new FootballTeam
                {
                    Team="Test3", A="35", D="56", F="15", L="45", P="43", Pts="23", W="21"
                }
            };

            //Act
            bool result = _csvFileValidator.ValidateData(footballTeams);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ValidateData_NoTeamTest()
        {
            //Setup
            List<FootballTeam> footballTeams = new List<FootballTeam>();

            //Act
            bool result = _csvFileValidator.ValidateData(footballTeams);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ValidateData_NullTeamTest()
        {
            //Setup
            List<FootballTeam> footballTeams = null;

            //Act
            bool result = _csvFileValidator.ValidateData(footballTeams);

            //Assert
            Assert.IsFalse(result);
        }
    }
}