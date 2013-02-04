using System;
using System.Collections.Generic;
using System.Linq;
using Baseball.Lib.Managers;
using Baseball.Lib.Models;
using Baseball.Lib.Repositories;
using Moq;
using NUnit.Framework;

namespace Baseball.Lib.Tests.Managers
{
    [TestFixture]
    public class TeamManagerTest
    {
        Mock<ITeamRepository> _teamRepository;
        Mock<IPlayerYearStatsRepository> _playerYearStatsRepository;
        TeamManager _teamManager;
        List<Team> _teams;
        List<PlayerYearStats> _playerYearStats;

        [SetUp]
        public void Setup()
        {
            _teams = new List<Team>();
            _playerYearStats = new List<PlayerYearStats>();

            _teamRepository = new Mock<ITeamRepository>();
            _playerYearStatsRepository = new Mock<IPlayerYearStatsRepository>();

            _teamManager = new TeamManager(_teamRepository.Object, _playerYearStatsRepository.Object);
        }

        [Test]
        public void NoTeamRecordsReturnsEmptyTeamStats()
        {
            _teamRepository.Setup(x => x.GetAll()).Returns(_teams);

            var teamStats = _teamManager.GetCurrentSeasonStats();

            AssertEmptyTeamStats(teamStats);
            _teamRepository.Verify(x => x.GetAll());
            _playerYearStatsRepository.Verify(x => x.GetAllForYear(It.IsAny<int>()), Times.Never());
        }

        [Test]
        public void TeamRecordExistsGetsPlayerStatsAndReturnsTeamStats()
        {
            AddTeamRecord(2012, true);
            _teamRepository.Setup(x => x.GetAll()).Returns(_teams);

            AddPlayerYearStatsRecordForYear(2012);
            _playerYearStatsRepository.Setup(x => x.GetAllForYear(2012)).Returns(_playerYearStats);

            var teamStats = _teamManager.GetCurrentSeasonStats();

            Assert.AreEqual(2012, teamStats.Year);
            CollectionAssert.AreEqual(new List<int> {2012}, teamStats.Seasons);
            CollectionAssert.AreEqual(_playerYearStats, teamStats.PlayerYearStats);

            _teamRepository.Verify(x => x.GetAll());
            _playerYearStatsRepository.Verify(x => x.GetAllForYear(2012));            
        }

        [Test]
        public void TeamRecordsExistUsesCurrentSeasonToGetCorrectPlayerStatsAndReturnsTeamStats()
        {
            AddTeamRecord(2013, true);
            AddTeamRecord(2012, false);
            AddTeamRecord(2011, false);
            _teamRepository.Setup(x => x.GetAll()).Returns(_teams);

            AddPlayerYearStatsRecordForYear(2013);
            _playerYearStatsRepository.Setup(x => x.GetAllForYear(2013)).Returns(_playerYearStats);

            var teamStats = _teamManager.GetCurrentSeasonStats();

            Assert.AreEqual(2013, teamStats.Year);
            CollectionAssert.AreEqual(new List<int> { 2011, 2012, 2013 }, teamStats.Seasons);
            CollectionAssert.AreEqual(_playerYearStats, teamStats.PlayerYearStats);

            _teamRepository.Verify(x => x.GetAll());
            _playerYearStatsRepository.Verify(x => x.GetAllForYear(2013));
            _playerYearStatsRepository.Verify(x => x.GetAllForYear(2012), Times.Never());
            _playerYearStatsRepository.Verify(x => x.GetAllForYear(2011), Times.Never());
        }

        [Test]
        public void TeamRecordsExistButCurrentSeasonIsNotSetUsesLatestYearToGetCorrectPlayerStatsAndReturnsTeamStats()
        {
            AddTeamRecord(2014, false);
            AddTeamRecord(2013, false);
            AddTeamRecord(2012, false);
            AddTeamRecord(2011, false);
            _teamRepository.Setup(x => x.GetAll()).Returns(_teams);

            AddPlayerYearStatsRecordForYear(2014);
            _playerYearStatsRepository.Setup(x => x.GetAllForYear(2014)).Returns(_playerYearStats);

            var teamStats = _teamManager.GetCurrentSeasonStats();

            Assert.AreEqual(2014, teamStats.Year);
            CollectionAssert.AreEqual(new List<int> { 2011, 2012, 2013, 2014 }, teamStats.Seasons);
            CollectionAssert.AreEqual(_playerYearStats, teamStats.PlayerYearStats);

            _teamRepository.Verify(x => x.GetAll());
            _playerYearStatsRepository.Verify(x => x.GetAllForYear(2014));
        }
        
        [Test]
        public void MultipleTeamRecordsExistsReturnsTeamStatsForGivenSeason()
        {
            AddTeamRecord(2013, true);
            AddTeamRecord(2012, false);
            AddTeamRecord(2011, false);
            _teamRepository.Setup(x => x.GetAll()).Returns(_teams);

            AddPlayerYearStatsRecordForYear(2012);
            _playerYearStatsRepository.Setup(x => x.GetAllForYear(2012)).Returns(_playerYearStats);

            var teamStats = _teamManager.GetSeasonStatsFor(2012);

            Assert.AreEqual(2012, teamStats.Year);
            CollectionAssert.AreEqual(new List<int> { 2011, 2012, 2013 }, teamStats.Seasons);
            CollectionAssert.AreEqual(_playerYearStats, teamStats.PlayerYearStats);

            _teamRepository.Verify(x => x.GetAll());
            _playerYearStatsRepository.Verify(x => x.GetAllForYear(2012));
        }

        [Test]
        public void TeamRecordForGivenSeasonDoesNotExistReturnsEmptyTeamStats()
        {
            AddTeamRecord(2012, false);
            _teamRepository.Setup(x => x.GetAll()).Returns(_teams);

            var teamStats = _teamManager.GetSeasonStatsFor(2013);

            AssertEmptyTeamStats(teamStats);
            _teamRepository.Verify(x => x.GetAll());
            _playerYearStatsRepository.Verify(x => x.GetAllForYear(It.IsAny<int>()), Times.Never());
        }

        void AddTeamRecord(int year, bool currentSeason)
        {
            _teams.Add(new Team
            {
                Year = year,
                Wins = 2,
                Losses = 1,
                CurrentSeason = currentSeason,
            });
        }

        void AddPlayerYearStatsRecordForYear(int year)
        {
            _playerYearStats.Add(new PlayerYearStats { Player = new Player(), Year = year });
        }

        static void AssertEmptyTeamStats(TeamStats teamStats)
        {
            Assert.IsNotNull(teamStats);
            Assert.AreEqual(DateTime.Now.Year, teamStats.Year);
            Assert.AreEqual(0, teamStats.Wins);
            Assert.AreEqual(0, teamStats.Losses);

            CollectionAssert.AreEqual(new List<int> { DateTime.Now.Year }, teamStats.Seasons);
            Assert.IsNotNull(teamStats.PlayerYearStats);
            Assert.IsFalse(teamStats.PlayerYearStats.Any());

            Assert.AreEqual(0, teamStats.TotalAtBats);
            Assert.AreEqual(0, teamStats.TotalRuns);
            Assert.AreEqual(0, teamStats.TotalHits);
            Assert.AreEqual(0, teamStats.TotalDoubles);
            Assert.AreEqual(0, teamStats.TotalTriples);
            Assert.AreEqual(0, teamStats.TotalHomeRuns);
            Assert.AreEqual(0, teamStats.TotalRunsBattedIn);
            Assert.AreEqual(0, teamStats.TotalWalks);
            Assert.AreEqual(0, teamStats.TotalStrikeOuts);
            Assert.AreEqual(0, teamStats.TotalAverage);
            Assert.AreEqual(0, teamStats.TotalOnBasePercentage);
        }
    }
}