Feature: Roster
	In order to manage the roster
    As the team's manager
    I need to be able to view, add, edit, and remove players

Scenario: Get all players
    Given there are no players on the team
    When I get all players
    Then no players are returned

    Given the team has the following players:
    | First Name | Last Name |
    | Jay        | Cutler    |
    | Matt       | Forte     |
    When I get all players
    Then the following players are returned:
    | First Name | Last Name |
    | Jay        | Cutler    |
    | Matt       | Forte     |
    
Scenario: Get player by Id
    Given the team has the following players:
    | Id | Last Name |
    | 6  | Cutler    |
    | 22 | Forte     |
    When I get a player whose Id is 22
    Then the following player is returned:
    | Id | Last Name |
    | 22 | Forte     |

    Given there are no players on the team
    When I get a player whose Id is 9
    Then a not found status result is returned
    