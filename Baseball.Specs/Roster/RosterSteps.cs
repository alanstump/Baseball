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

namespace Baseball.Specs.Roster
{
    [Binding]
    public class RosterSteps
    {
        IEnumerable<Player> _returnedPlayers;
        readonly PlayersRepositoryStub _playersRepository;
        HttpNotFoundResult _httpNotFoundResult;
        Player _player;

        public RosterSteps()
        {
            BaseballSpecsIocConfigurer.Configure();
            _playersRepository = Ioc.Get<IPlayersRepository>() as PlayersRepositoryStub;
        }
        
        [Before]
        public void Setup()
        {
            _playersRepository.Players.Clear();
            _player = null;
            _httpNotFoundResult = null;
        }

        [Given(@"there are no players on the team")]
        public void GivenThereAreNoPlayersOnTheTeam()
        {
        }

        [Given(@"the team has the following players:")]
        public void GivenTheTeamHasTheFollowingPlayers(Table table)
        {
            var players = PlayersHelper.CreateFrom(table);
            _playersRepository.Players.AddRange(players);
        }

        [When(@"I get all players")]
        public void WhenIGetThePlayersOnTheTeam()
        {
            var result = Ioc.Get<RosterController>().Index() as ViewResult;

            if (result == null)
                throw new Exception("Unable to get roster.");

            _returnedPlayers = result.Model as List<Player>;
        }

        [When(@"I get a player whose Id is (\d+)")]
        public void WhenIGetAPlayerWhoseIdIs(int playerId)
        {
            var result = Ioc.Get<RosterController>().Details(playerId);

            if (result as ViewResult != null)
            {
                var viewResult = result as ViewResult;
                _player = viewResult.Model as Player;
            }
            else
                _httpNotFoundResult = result as HttpNotFoundResult;
        }

        [Then(@"no players are returned")]
        public void ThenNoPlayersAreReturned()
        {
            Assert.AreEqual(0, _returnedPlayers.Count());
        }

        [Then(@"the following players are returned:")]
        public void ThenTheFollowingPlayersAreReturned(Table table)
        {
            var players = PlayersHelper.CreateFrom(table);
            CollectionAssert.AreEqual(players, _returnedPlayers);
        }

        [Then(@"the following player is returned:")]
        public void ThenTheFollowingPlayerIsReturned(Table table)
        {
            var players = PlayersHelper.CreateFrom(table);
            Assert.AreEqual(players.First(), _player);
        }

        [Then(@"a not found status result is returned")]
        public void ThenANotFoundStatusResultIsReturned()
        {
            Assert.IsNotNull(_httpNotFoundResult);
            Assert.AreEqual(404, _httpNotFoundResult.StatusCode);
        }
    }
}
