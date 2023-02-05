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

Scenario: User can add products to cart and proceed to checkout
	Given user opens sign in page
		And enters correct credentials
		And user subbmits login form
		And user opens products page
		And searches for 'Winter Top'
		And opens first search result
	When user click on Add to Cart button
		And proceeds to cart
		And user clicks on Procced to checkout button
		And enters his comment in window
		And clicks on Place Order button
	When enters all required fields
		And clicks on Pay and Confirm button
	Then user will get confirmation message

Scenario: User can submit review on any product
	Given user opens products page
		And searches for 'Winter Top'
		And opens first search result
	When enters name and email adress
		And writes review
		And clicks on Submit button
	Then he gets Thank you for your review message