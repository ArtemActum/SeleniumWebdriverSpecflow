Feature: SpecflowWithoutPOM

A short summary of the feature


Background: Pre-Condition
	# Given Step 
	Given Go to website
	And File a Bug Should be visible.


@tag1
Scenario: Login Specflow
	# Steps - A Given Step

	When I click on File a Bug Link.
	Then User should be at Login Page.
	When I provide the username, password and click on Login button.
	Then User should be at Bug Detail Page.
	When I click on Logout button.
	Then User should be logged out and should be at Home Page.

Scenario: Create Bug Specflow
	
	When I click on File a Bug Link.
	Then User should be at Login Page.
	When I provide the username, password and click on Login button.
	Then User should be at Bug Detail Page.
	When I provide the severity, hardware, platform and summary.
	And click on Submit button.
	Then Bug should get created.
	And User should be at Search Page.
	When I click on Logout button.
	Then User should be logged out and should be at Home Page.
