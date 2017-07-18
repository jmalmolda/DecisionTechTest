Feature: Scenario2
	Given the basket has 2 butter and 2 bread when I total the basket then the total should be
	£3.10

@mytag
Scenario: Add two numbers
	Given I have added 2 butter products to the basket
	And I have added 2 bread products to the basket
	When I get the total price
	Then the result should be £3.10
