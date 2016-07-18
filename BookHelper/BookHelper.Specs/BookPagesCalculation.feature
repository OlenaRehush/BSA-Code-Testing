Feature: BookPagesCalculation

Scenario: Calculate left pages of book with few page ranges
	Given I have created a book with 10 pages
	And I have added page range from 3 to 4
	And I have added page range from 6 to 8
	When I ask how many pages left
	Then the book shows 5 pages
