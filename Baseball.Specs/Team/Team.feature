Feature: Team
	As a manager, player, or fan
	I want to be able to view the team's record and statistics

Scenario: Get Current/Latest Team Totals
    Given there are no players on the team
    And the team has not started any seasons
    When I get the teams current season totals
    Then the year is CurrentYear
    And the team has 0 wins
    And the team has 0 losses
    And the team has the seasons CurrentYear
    And the team does not have any player stats
    And the team batting totals are all zero


Scenario: Get Team Totals by Year

Scenario: Individual Stats Leaders for Season (Hits, HR, RBI, AVG, ???)