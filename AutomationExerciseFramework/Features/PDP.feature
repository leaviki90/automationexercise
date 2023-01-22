Feature: PDP
	As a user
	I want to be able to add products to cart
	So I can complete the purchase

@mytag
Scenario: User can add product to cart
	Given user opens products page
	And searches for "Winter Top" term
	And opens first search result
	When user clicks on Add to Cart button 
	And proceeds to cart
	Then shopping cart will be displayed with expected product inside



Scenario: User can submit a review on any product
    Given user opens products page
	And searches for "Winter Top" term
	And opens first search result
	And fills all the fields
	When user clicks on submit button
	Then receives feedback message