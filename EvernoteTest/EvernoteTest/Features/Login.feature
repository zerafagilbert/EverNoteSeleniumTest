Feature: Login
	In order to validate a successful login
	I want to match the correct user once logged in

@firefox
Scenario: SuccessfulLogin
	//Using Sign in
	Given I have visted https://evernote.com/
	When I confirn the page is loaded
	And I have to click on sign button
	Then the new page should be https://www.evernote.com/Login.action

	When login page is loaded fill email with gilbert.zerafa@gmail.com
	And I press the continue button
	Then I should see the password field
	When the password field is displayed fill it with Test123!
	And I press the sign-in button
	Then the new page should contain https://www.evernote.com/Home.action 

	When I click on the account image
	And the username should be gilbert.zerafa@gmail.com

@firefox 
Scenario: FailLoginNoCreds
	Given I have visted https://evernote.com/
	When I confirn the page is loaded
	And I have to click on sign button
	Then the new page should be https://www.evernote.com/Login.action

	When I press the continue button
	Then I should see an error Required data missing

