Feature: Authentication
As a user
I want to be able to authenticate to the app
So I can work with restricted web app content

@mytag
Scenario: User can log in
	Given user opens sign in page
	And enters correct credentials
	When user subbmits login form
	Then user will be logged in

Scenario: User can sign up
	Given user opens sign in page
		And enters 'Mirza' name and valid email address
		And user clicks on SignUp button
	When user fills in required fields
		And submits the signup form
	Then user will get 'Account Created!' success mesage
		And user will be logged in

Scenario: User can delete account
	Given user opens sign in page
		And enters 'Mirza' name and valid email address
		And user clicks on SignUp button
		And user fills in required fields
		And submits the signup form
		And user will get 'Account Created!' success mesage
	When user clicks on Delete Account button
	Then user will get 'Account Deleted!' success message