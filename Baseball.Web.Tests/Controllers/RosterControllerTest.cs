using Baseball.Lib.Managers;
using Baseball.Lib.Models;
using Baseball.Web.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Baseball.Web.Tests.Controllers
{
    [TestFixture]
    public class RosterControllerTest
    {
        RosterController _rosterController;
        Mock<RosterManager> _rosterManager;

        [TestFixtureSetUp]
        public void Setup()
        {
            _rosterManager = new Mock<RosterManager>(null);
            _rosterController = new RosterController(_rosterManager.Object);
        }

        [Test]
        public void IndexGetAll_CallsPlayerManager()
        {
            var players = new List<Player> { new Player() };
            _rosterManager.Setup(x => x.GetAllPlayers()).Returns(players);

            var result = _rosterController.Index() as ViewResult;
            var actualPlayers = result.Model as List<Player>;

            Assert.IsNotNull(actualPlayers);
            CollectionAssert.AreEqual(players, actualPlayers);
            
            _rosterManager.Verify(x => x.GetAllPlayers());
        }
        
        [Test]
        public void IndexGetById_CallsPlayerManager()
        {
            var player = new Player {Id = 4};
            _rosterManager.Setup(x => x.GetPlayerById(4)).Returns(player);

            var result = _rosterController.Details(4) as ViewResult;
            var actual = result.Model as Player;

            Assert.IsNotNull(actual);
            Assert.AreEqual(player, actual);
            
            _rosterManager.Verify(x => x.GetPlayerById(4));
        }
        
        [Test]
        public void IndexGetById_PlayerDoesNotExist_ReturnsHttpNotFound()
        {
            _rosterManager.Setup(x => x.GetPlayerById(4)).Returns((Player)null);

            var result = _rosterController.Details(4) as HttpNotFoundResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(404 , result.StatusCode);
            
            _rosterManager.Verify(x => x.GetPlayerById(4));
        }
    }
}
