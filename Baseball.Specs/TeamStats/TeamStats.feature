Feature: Team
	As a manager, player, or fan
	I want to be able to view the team's record and statistics

Scenario: Get current team totals when no players or seasons created
    Given there are no players on the team
    And the team has not started any seasons
    When I get the teams current season totals
    Then the year is CurrentYear
    And the team has 0 wins
    And the team has 0 losses
    And the team has the seasons CurrentYear
    And the team does not have any player stats
    And the team batting totals are all zero
    
Scenario: Get current team totals when no players exist but season does
    Given there are no players on the team
    And the team has the following seasons:
    | Year | Wins | Losses | Current Season |
    | 2012 | 20   | 5      | False          |
    | 2013 | 0    | 0      | True           |
    When I get the teams current season totals
    Then the year is 2013
    And the team has 0 wins
    And the team has 0 losses
    And the team has the seasons 2012,2013
    And the team does not have any player stats
    And the team batting totals are all zero

Scenario: Get current team totals when player stats don't exist for current season
    Given the team has the following player stat records:
    | Last Name | Year | ABs | Hits |
    | Cutler    | 2012 | 25  | 5    |
    | Forte     | 2013 | 0   | 0    |
    And the team has the following seasons:
    | Year | Wins | Losses | Current Season |
    | 2012 | 20   | 5      | False          |
    | 2013 | 0    | 0      | True           |
    When I get the teams current season totals
    Then the year is 2013
    And the team has 0 wins
    And the team has 0 losses
    And the team has the seasons 2012,2013
    And the team has the following player stats:
    | Last Name | Year | ABs | Hits | Average | On Base Percentage |
    | Forte     | 2013 | 0      | 0    | .000    | .000               |
    And the team batting totals are all zero

Scenario: Current team totals calculated correctly for current season
    Given the team has the following player stat records:
    | Last Name | Year | ABs | Hits | Doubles | Triples | Home Runs | RBIs | Walks | Runs | Strike Outs |
    | Joe       | 2013 | 25  | 15   | 3       | 1       | 3         | 20   | 0     | 11   | 0           |
    | John      | 2013 | 25  | 10   | 2       | 0       | 0         | 5    | 0     | 7    | 0           |
    | Jay       | 2013 | 22  | 18   | 5       | 0       | 2         | 14   | 3     | 15   | 0           |
    | Jared     | 2013 | 25  | 5    | 1       | 0       | 0         | 2    | 0     | 4    | 3           |
    | Jacob     | 2013 | 24  | 12   | 2       | 0       | 1         | 10   | 1     | 9    | 0           |
    And the team has the following seasons:
    | Year | Wins | Losses | Current Season |
    | 2013 | 12   | 4      | True           |
    When I get the teams current season totals
    Then the year is 2013
    And the team has 12 wins
    And the team has 4 losses
    And the team has the seasons 2013
    And the team has the following player stats:
    | Last Name | Year | ABs | Hits | Doubles | Triples | Home Runs | RBIs | Walks | Runs | Strike Outs | Average | On Base Percentage |
    | Joe       | 2013 | 25  | 15   | 3       | 1       | 3         | 20   | 0     | 11   | 0           | .600    | .600               |
    | John      | 2013 | 25  | 10   | 2       | 0       | 0         | 5    | 0     | 7    | 0           | .400    | .400               |
    | Jay       | 2013 | 22  | 18   | 5       | 0       | 2         | 14   | 3     | 15   | 0           | .720    | .840               |
    | Jared     | 2013 | 25  | 5    | 1       | 0       | 0         | 2    | 0     | 4    | 3           | .200    | .200               |
    | Jacob     | 2013 | 24  | 12   | 2       | 0       | 1         | 10   | 1     | 9    | 0           | .500    | .640               |
    And the team batting totals are the following:
    | ABs | Hits | Doubles | Triples | Home Runs | RBIs | Walks | Runs | Strike Outs | Average | On Base Percentage |
    | 121 | 60   | 13      | 1       | 6         | 51   | 4     | 46   | 3           | .496    | .512               |

Scenario: Get specific season stats
    Given the team has the following player stat records:
    | Last Name | Year | ABs | Hits | Doubles | Triples | Home Runs | RBIs | Walks | Runs | Strike Outs |
    | Joe       | 2012 | 25  | 15   | 3       | 1       | 3         | 20   | 0     | 11   | 0           |
    | John      | 2012 | 25  | 10   | 2       | 0       | 0         | 5    | 0     | 7    | 0           |
    | Jay       | 2012 | 22  | 18   | 5       | 0       | 2         | 14   | 3     | 15   | 0           |
    | Jared     | 2013 | 25  | 5    | 1       | 0       | 0         | 2    | 0     | 4    | 3           |
    | Jacob     | 2013 | 24  | 12   | 2       | 0       | 1         | 10   | 1     | 9    | 0           |
    And the team has the following seasons:
    | Year | Wins | Losses | Current Season |
    | 2012 | 20   | 5      | False          |
    | 2013 | 3    | 22     | True           |
    When I get the teams season totals for 2012
    Then the year is 2012
    And the team has 20 wins
    And the team has 5 losses
    And the team has the seasons 2012,2013
    And the team has the following player stats:
    | Last Name | Year | ABs | Hits | Doubles | Triples | Home Runs | RBIs | Walks | Runs | Strike Outs | Average | On Base Percentage |
    | Joe       | 2012 | 25  | 15   | 3       | 1       | 3         | 20   | 0     | 11   | 0           | .600    | .600               |
    | John      | 2012 | 25  | 10   | 2       | 0       | 0         | 5    | 0     | 7    | 0           | .400    | .400               |
    | Jay       | 2012 | 22  | 18   | 5       | 0       | 2         | 14   | 3     | 15   | 0           | .720    | .840               |
    And the team batting totals are the following:
    | ABs | Hits | Doubles | Triples | Home Runs | RBIs | Walks | Runs | Strike Outs | Average | On Base Percentage |
    | 72  | 43   | 10      | 1       | 5         | 39   | 3     | 33   | 0           | .597    | .613               |

Scenario: Individual Stats Leaders for Season (Hits, HR, RBI, AVG, ???)