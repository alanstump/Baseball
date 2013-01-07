using Baseball.Lib.Managers;
using Baseball.Lib.Models;
using Baseball.Lib.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Baseball.Lib.Tests.Managers
{
    [TestFixture]
    public class RosterManagerTest
    {
        Mock<IPlayersRepository> _playersRepository;
        RosterManager _playersManager;

        [SetUp]
        public void Setup()
        {
            _playersRepository = new Mock<IPlayersRepository>();
            _playersManager = new RosterManager(_playersRepository.Object);
        }

        [Test]
        public void GetAll_CallsRepository()
        {
            var players = new List<Player> { new Player() };
            _playersRepository.Setup(x => x.GetAll()).Returns(players);

            var actual = _playersManager.GetAllPlayers();

            CollectionAssert.AreEqual(players, actual);
            _playersRepository.Verify(x => x.GetAll());
        }

        [Test]
        public void GetById_CallsRepository()
        {
            var player = new Player();
            _playersRepository.Setup(x => x.GetById(123)).Returns(player);

            var actual = _playersManager.GetPlayerById(123);

            Assert.AreEqual(player, actual);
            _playersRepository.Verify(x => x.GetById(123));
        }
    }
}
