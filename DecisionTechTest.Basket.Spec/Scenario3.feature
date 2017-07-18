Feature: Scenario3
	Given the basket has 4 milk when I total the basket then the total should be £3.45

@mytag
Scenario: 4Milk
	Given I have added 4 milk products to the basket
	When I get the total price
	Then the result should be £3.45
