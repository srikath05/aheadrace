Feature: Create and Login ondemand application
	

@mytag
Scenario: Create and Login in Ondemand application and  Import Participants. 
	Given I navigate to application.
	When I enter username and password.
	| UserName | Password |
	| admin  | passwords |
	And I click on Login.
	Then verify the failure message 'Sorry, unrecognized username or password.' is displayed.
	When Navigate to Request new password page.
	Then Verify user able to navigated to Request new passord page.
	When Enter email address "ganjisrikanth0528@gmail.com" and click Email new password.
	And I enter with correct credentials.
	| UserName | Password |
	| qatestuser  | RNNrq5dubcCNKtBwhALO |
	And Navigate to "People " and select "Users" option.
	Then Verify user able to navigate Users "Add user" page.
	When I click on "Import Participants".
	Then verify user is in Import Participants page by a Field on the page "Add participants to group ".
	When I click on Browse option and upload the file.
	And I click on "Import" option.
	Then verify with the " Created 1 user." message in the page.


