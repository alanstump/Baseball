using System;
using System.Collections.Generic;
using System.Linq;
using Baseball.Lib.Models;
using NUnit.Framework;

namespace Baseball.Lib.Tests.Models
{
    [TestFixture]
    public class TeamStatsTest
    {
        Team _team;
        List<PlayerYearStats> _playerYearStats;
        List<int> _seasons;

        [SetUp]
        public void Setup()
        {
            _team = new Team
            {
                Year = 2012,
                Wins = 1,
                Losses = 1,
            };

            _seasons = new List<int> {2012, 2011};

            _playerYearStats = new List<PlayerYearStats>();
        }

        [Test]
        public void DefualtConstructorSetYearToCurrentYearAndSetDefaultValues()
        {
            var teamStats = new TeamStats();

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
            Assert.AreEqual(0, teamStats.TotalOnBasePercantage);
        }

        [Test]
        public void NoPlayerStatsMakesTotalsAllZero()
        {
            var teamStats = new TeamStats(_team, _playerYearStats, _seasons);

            Assert.AreEqual(_team.Year, teamStats.Year);
            Assert.AreEqual(_team.Wins, teamStats.Wins);
            Assert.AreEqual(_team.Losses, teamStats.Losses);
            CollectionAssert.AreEqual(_seasons, teamStats.Seasons);
            CollectionAssert.AreEqual(_playerYearStats, teamStats.PlayerYearStats);

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
            Assert.AreEqual(0, teamStats.TotalOnBasePercantage);
        }

        [Test]
        public void HavePlayerStatsAndAverageAndOnBasePercentageAreCalculated()
        {
            CreatePlayerStats(atBats: 4, hits: 1, walks: 0);
            CreatePlayerStats(atBats: 4, hits: 3, walks: 0);
            CreatePlayerStats(atBats: 3, hits: 0, walks: 1);

            var teamStats = new TeamStats(_team, _playerYearStats, _seasons);

            Assert.AreEqual(_team.Year, teamStats.Year);
            Assert.AreEqual(_team.Wins, teamStats.Wins);
            Assert.AreEqual(_team.Losses, teamStats.Losses);
            CollectionAssert.AreEqual(_seasons, teamStats.Seasons);
            CollectionAssert.AreEqual(_playerYearStats, teamStats.PlayerYearStats);

            Assert.AreEqual(11, teamStats.TotalAtBats);
            Assert.AreEqual(4, teamStats.TotalHits);
            Assert.AreEqual(1, teamStats.TotalWalks);
            Assert.AreEqual(4 / (decimal) 11, teamStats.TotalAverage);
            Assert.AreEqual(5 / (decimal) 11, teamStats.TotalOnBasePercantage);
        }

        void CreatePlayerStats(int atBats, int hits, int walks)
        {
            _playerYearStats.Add(new PlayerYearStats
            {
                AtBats = atBats,
                Hits = hits,
                Walks = walks
            });
        }
    }
}