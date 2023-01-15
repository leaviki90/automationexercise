Feature: Authentication
	As a user
	I want to be able to authenticate to the app
	so I can work with restricted web app content

@mytag
Scenario: User can log in
	Given user opens sign in page
	And enters correct credentials
	When user submits the form
	Then user will be logged in

Scenario: User can sign up
  Given user opens sign in page
     And enters "Lea" name and valid email address
     And user clicks on SignUp button
  When user fills in all required fields
     And submits the signUp form
  Then user will get "Account Created!" success message
     And user will be logged in

	 Scenario: User can delete their account
  Given user can register account with "Lea" name
     #And enters "Lea" name and valid email address
     #And user clicks on SignUp button
     #And user fills in all required fields
     #And submits the signUp form
	 When user selects option for deleting the account
     Then user will get "Account Deleted!" message
     