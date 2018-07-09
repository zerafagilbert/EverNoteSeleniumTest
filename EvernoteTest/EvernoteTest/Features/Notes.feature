Feature: Notes
	In order to create a Note
	I want to confirm that the note is created in the Notes List

@firefox 
@chrome
Scenario: CreateNote
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

	When I click on the add note button
	And I confirm that a new note is provided
	And I enter Title1 note title
	Then I click on the done button

	When I see the note list 
	Then I confirm that the new note Title1 is added
		
	When I click on the account image
	And I will logout

@chrome
Scenario: NoteStillListedAfterLogOut
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

	When I click on the add note button
	And I confirm that a new note is provided
	And I enter Title2 note title
	Then I click on the done button

	When I click on the account image
	And I will logout
	Then I shall be directed to page https://evernote.com/logged-out/
	When I have to click on sign button
	Then the new page should be https://www.evernote.com/Login.action

	When login page is loaded fill email with gilbert.zerafa@gmail.com
	And I press the continue button
	Then I should see the password field
	When the password field is displayed fill it with Test123!
	And I press the sign-in button
	Then the new page should contain https://www.evernote.com/Home.action 

	When I see the note list 
	Then I confirm that the new note Title2 is added
