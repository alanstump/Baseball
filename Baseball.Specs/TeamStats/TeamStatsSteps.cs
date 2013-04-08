using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Baseball.Lib.Repositories;
using Baseball.Specs.Helpers;
using Baseball.Specs.Repositories;
using Baseball.Web.Controllers;
using IocContainer;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Baseball.Specs.TeamStats
{
    [Binding]
    public class TeamStatsSteps
    {
        Lib.Models.TeamStats _teamStats;

        public TeamStatsSteps()
        {
            BaseballSpecsIocConfigurer.Configure();
        }
        
        [Before]
        public void Setup()
        {
            var playersRepository = Ioc.Get<IPlayersRepository>() as PlayersRepositoryStub;
            playersRepository.Players.Clear();
            var playerYearStatsRepositoryStub = Ioc.Get<IPlayerYearStatsRepository>() as PlayerYearStatsRepositoryStub;
            playerYearStatsRepositoryStub.PlayerYearStats.Clear();
            var teamRepositoryStub = Ioc.Get<ITeamRepository>() as TeamRepositoryStub;
            teamRepositoryStub.Teams.Clear();
        }

        [Given(@"the team has not started any seasons")]
        public void GivenTheTeamHasNotStartedAnySeasons()
        {
        }

        [Given(@"the team has the following seasons:")]
        public void GivenTheTeamHasTheFollowingSeasons(Table table)
        {
            var teams = TeamHelper.CreateFrom(table);
            var teamRepositoryStub = Ioc.Get<ITeamRepository>() as TeamRepositoryStub;
            teamRepositoryStub.Teams.AddRange(teams);
        }
        
        [Given(@"the team has the following player stat records:")]
        public void GivenTheTeamHasTheFollowingPlayerStatRecords(Table table)
        {
            var playerStats = PlayerYearStatsHelper.CreateFrom(table);
            var playerYearStatsRepositoryStub = Ioc.Get<IPlayerYearStatsRepository>() as PlayerYearStatsRepositoryStub;
            playerYearStatsRepositoryStub.PlayerYearStats.AddRange(playerStats);
        }

        [When(@"I get the teams current season totals")]
        public void WhenIGetTheTeamsCurrentSeasonTotals()
        {
            GetSeasonStats();
        }

        [When(@"I get the teams season totals for (\d+)")]
        public void WhenIGetTheTeamsSeasonTotalsFor(int season)
        {
            GetSeasonStats(season);
        }

        [Then(@"the year is (.*)")]
        public void ThenTheYearIs(string year)
        {
            var expectedYear = CastYearToInt(year);
            Assert.AreEqual(expectedYear, _teamStats.Year);
        }

        [Then(@"the team has (\d+) wins")]
        public void ThenTheTeamHasWins(int wins)
        {
            Assert.AreEqual(wins, _teamStats.Wins);
        }

        [Then(@"the team has (\d+) losses")]
        public void ThenTheTeamHasLosses(int losses)
        {
            Assert.AreEqual(losses, _teamStats.Losses);
        }

        [Then(@"the team has the seasons (.*)")]
        public void ThenTheTeamHasTheSeasons(string years)
        {
            var expectedSeasons = GetSeasonsFrom(years);
            CollectionAssert.AreEqual(expectedSeasons, _teamStats.Seasons);
        }

        [Then(@"the team does not have any player stats")]
        public void ThenTheTeamDoesNotHaveAnyPlayerStats()
        {
            Assert.IsFalse(_teamStats.PlayerYearStats.Any());
        }

        [Then(@"the team has the following player stats:")]
        public void ThenTheTeamHasTheFollowingPlayerStats(Table table)
        {
            var expectedPlayerStats = PlayerYearStatsHelper.CreateFrom(table);
            CollectionAssert.AreEqual(expectedPlayerStats, _teamStats.PlayerYearStats);
        }

        [Then(@"the team batting totals are all zero")]
        public void ThenTheTeamBattingTotalsAreAllZero()
        {
            Assert.AreEqual(0, _teamStats.TotalAtBats);
            Assert.AreEqual(0, _teamStats.TotalRuns);
            Assert.AreEqual(0, _teamStats.TotalHits);
            Assert.AreEqual(0, _teamStats.TotalDoubles);
            Assert.AreEqual(0, _teamStats.TotalTriples);
            Assert.AreEqual(0, _teamStats.TotalHomeRuns);
            Assert.AreEqual(0, _teamStats.TotalRunsBattedIn);
            Assert.AreEqual(0, _teamStats.TotalWalks);
            Assert.AreEqual(0, _teamStats.TotalStrikeOuts);
            Assert.AreEqual(0, _teamStats.TotalAverage);
            Assert.AreEqual(0, _teamStats.TotalOnBasePercentage);
        }

        [Then(@"the team batting totals are the following:")]
        public void ThenTheTeamBattingTotalsAreTheFollowing(Table table)
        {
            TeamStatsHelper.Compare(table, _teamStats);
        }

        static IEnumerable<int> GetSeasonsFrom(string years)
        {
            return years.Split(',').Select(CastYearToInt).ToList();
        }

        static int CastYearToInt(string year)
        {
            return IsCurrentYear(year) ? DateTime.Now.Year : int.Parse(year);
        }

        static bool IsCurrentYear(string year)
        {
            return year.ToLower() == "currentyear";
        }

        void GetSeasonStats(int? season = null)
        {
            var result = Ioc.Get<TeamStatsController>().Index(season) as ViewResult;

            if (result == null)
                throw new Exception("Unable to get team stats.");

            _teamStats = result.Model as Lib.Models.TeamStats;
        }
    }
}