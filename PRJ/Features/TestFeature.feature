Feature: testfeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: search amazon
	Given I have navigated to amazon
	And I enter football
	When I click search
	Then the site will load the search
