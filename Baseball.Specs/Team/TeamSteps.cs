using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Baseball.Lib.Models;
using Baseball.Lib.Repositories;
using Baseball.Specs.Repositories;
using Baseball.Web.Controllers;
using IocContainer;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Baseball.Specs.Team
{
    [Binding]
    public class TeamSteps
    {
        TeamStats _teamStats;

        public TeamSteps()
        {
            BaseballSpecsIocConfigurer.Configure();
        }
        
        [Before]
        public void Setup()
        {
            var playersRepository = Ioc.Get<IPlayersRepository>() as PlayersRepositoryStub;
            playersRepository.Players.Clear();
        }

        [Given(@"the team has not started any seasons")]
        public void GivenTheTeamHasNotStartedAnySeasons()
        {
        }

        [When(@"I get the teams current season totals")]
        public void WhenIGetTheTeamsCurrentSeasonTotals()
        {
            var result = Ioc.Get<TeamController>().Index() as ViewResult;

            if (result == null)
                throw new Exception("Unable to get team stats.");

            _teamStats = result.Model as TeamStats;
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
            Assert.AreEqual(0, _teamStats.TotalOnBasePercantage);
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
    }
}