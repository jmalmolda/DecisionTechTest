Feature: Scenario 1
	Given the	basket	has	1	bread,	1	butter	and	1	milk	when I	total	the	basket	then the	total	
	should	be	£2.95

@mytag
Scenario: 1 bread, 1 butter, 1 milk
	Given I have added a bread product to the basket
	And I have added a butter product to the basket
	And I have added a milk product to the basket
	When I get the total price
	Then the result should be £2.95
