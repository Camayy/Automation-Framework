Feature: Search
	Check if search function works 
	by using the search bar
	with the search button

@mytag
Scenario: Search for football items on amazon
	Given I have navigated to amazon website
	And I type football into the search bar
	When I press search
	Then items relating to football should show
