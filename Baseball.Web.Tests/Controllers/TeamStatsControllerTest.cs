using System.Web.Mvc;
using Baseball.Lib.Managers;
using Baseball.Lib.Models;
using Baseball.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Baseball.Web.Tests.Controllers
{
    [TestFixture]
    public class TeamStatsControllerTest
    {
        TeamStatsController _teamStatsController;
        Mock<TeamManager> _teamManager;

        [SetUp]
        public void Setup()
        {
            _teamManager = new Mock<TeamManager>(null, null);
            _teamStatsController = new TeamStatsController(_teamManager.Object);
        }

        [Test]
        public void NoSeasonGivenCallsTeamManagerAndReturnsTeamStatsView()
        {
            var teamStats = new TeamStats();
            _teamManager.Setup(x => x.GetCurrentSeasonStats()).Returns(teamStats);

            var result = _teamStatsController.Index() as ViewResult;
            
            Assert.IsNotNull(result);
            
            var actualTeamStats = result.Model as TeamStats;

            Assert.IsNotNull(actualTeamStats);
            Assert.AreEqual(teamStats, actualTeamStats);

            _teamManager.Verify(x => x.GetCurrentSeasonStats());
        }
        
        [Test]
        public void SeasonGivenCallsTeamManagerWithSeasonValueReturnsTeamStatsView()
        {
            var teamStats = new TeamStats();
            _teamManager.Setup(x => x.GetSeasonStatsFor(2013)).Returns(teamStats);

            var result = _teamStatsController.Index(2013) as ViewResult;
            
            Assert.IsNotNull(result);

            var actualTeamStats = result.Model as TeamStats;

            Assert.IsNotNull(actualTeamStats);
            Assert.AreEqual(teamStats, actualTeamStats);

            _teamManager.Verify(x => x.GetSeasonStatsFor(2013));
        }
    }
}