using System.Web.Mvc;
using Baseball.Lib.Managers;
using Baseball.Lib.Models;
using Baseball.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Baseball.Web.Tests.Controllers
{
    [TestFixture]
    public class TeamControllerTest
    {
        TeamController _teamController;
        Mock<TeamManager> _teamManager;

        [SetUp]
        public void Setup()
        {
            _teamManager = new Mock<TeamManager>(null, null);
            _teamController = new TeamController(_teamManager.Object);
        }

        [Test]
        public void Index_CallsTeamManager_ReturnsTeamStatsView()
        {
            var teamStats = new TeamStats();
            _teamManager.Setup(x => x.GetCurrentSeasonStats()).Returns(teamStats);

            var result = _teamController.Index() as ViewResult;
            var actualTeamStats = result.Model as TeamStats;

            Assert.IsNotNull(actualTeamStats);
            Assert.AreEqual(teamStats, actualTeamStats);

            _teamManager.Verify(x => x.GetCurrentSeasonStats());
        }
    }
}