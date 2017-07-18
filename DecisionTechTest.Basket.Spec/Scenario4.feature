	Feature: Scenario4
		Given the basket has 2 butter, 1 bread and 8 milk when I total the basket then the total

		should be £9.00

@mytag
Scenario: 2 Butter 1 Bread 8 Milk
	Given I have added 2 butter products to the basket
	And I have added 1 bread products to the basket
	And I have added 8 milk products to the basket
	When I get the total price
	Then the result should be £9.00
