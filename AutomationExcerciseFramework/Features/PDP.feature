Feature: PDP
	As a user
	I want to be able to add products to cart
	So I can compete the purchase

@mytag
Scenario: User can add products to cart
	Given user opens products page
		And searches for 'Winter Top'
		And opens first search result
	When user click on Add to Cart button
		And proceeds to cart
	Then shopping cart will be displayed with'(.*)' product inside