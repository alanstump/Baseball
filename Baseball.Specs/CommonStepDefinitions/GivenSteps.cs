﻿using Baseball.Lib.Repositories;
using Baseball.Specs.Repositories;
using Baseball.Specs.Roster;
using IocContainer;
using TechTalk.SpecFlow;

namespace Baseball.Specs.CommonStepDefinitions
{
    [Binding]
    public class GivenSteps : Steps
    {
        [Given(@"there are no players on the team")]
        public void GivenThereAreNoPlayersOnTheTeam()
        {
        }

        [Given(@"the team has the following players:")]
        public void GivenTheTeamHasTheFollowingPlayers(Table table)
        {
            var players = PlayersHelper.CreateFrom(table);
            var playersRepositoryStub = Ioc.Get<IPlayersRepository>() as PlayersRepositoryStub;
            playersRepositoryStub.Players.AddRange(players);
        }
    }
}