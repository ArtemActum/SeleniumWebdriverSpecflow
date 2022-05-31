Feature: Arguments

To demo passing of argument value from the feature file

• Given Keyword :- This keyword defines a preconditions of a scenario.
• And Keyword :- This keyword is used to provide the additional condition to the step. It can be used with Given, When & Then
• When Keyword :- This keyword defines an action that will be executed.
• Then Keyword :- This keyword defines the outcome of the previous step.
• But Keyword :- This Keyword defines negative condition added to the previous step
• Background Keyword :- This keyword defines the steps which are common across the scenario

Background: Pre-Condition
	# Given Step
	Given User is at Home Page with url "http://localhost:5001/"
	And File a Bug should be visible

	#@Smoke
Scenario: Login Arguments
	# Steps - A Given Step
	When I click on "File a Bug" Link
	Then User should be at Login Page with title "Log in to Bugzilla"
	When I provide the "artemminsadyrov@seznam.cz", "159357" and click on Login button
	Then User Should be at Enter Bug page with title "Enter Bug"
	When I click on Logout button at enter bug page
	Then User should be logged out and should be at Home Page

	Scenario: Create Bug Arguments
	When I click on "File a Bug" Link
	Then User should be at Login Page with title "Log in to Bugzilla"
	When I provide the "artemminsadyrov@seznam.cz", "159357" and click on Login button
	Then User Should be at Enter Bug page with title "Enter Bug"
	When I click on Testng link in the page
	Then User Should be at Bug Detail page with title "Enter Bug: Testng"
	When I provide the severity , hardware , platform , summary and desc
	| Severity | Hardware   | Platform | Summary     | Desc     |
	| critical | Macintosh | Other    | Summary - 1 | Desc - 1 |
	| major    | Other     | Linux    | Summary - 2 | Desc - 2 |
	And click on Submit button in page
	Then Bug should get created
	And User should be at Search page
	When I click on Logout button at bug detail page
	Then User should be logged out and should be at Home Page

	#@ignore
	#Použijte k předání různých argumentů do více kroků
Scenario Outline: Create Bug with scenario outline Arguments 
	When I click on "<flink>" Link
	Then User should be at Login Page with title "<lTitle>"
	When I provide the "<user>", "<pass>" and click on Login button
	Then User Should be at Enter Bug page with title "<eTitle>"
	When I click on Testng link in the page
	Then User Should be at Bug Detail page with title "<bTitle>"
	When I provide the "<Severity>" , "<Hardware>" , "<Platform>" , "<Summary>" and "<Desc>"
	And click on Submit button in page
	Then Bug should get created
	And User should be at Search page
	When I click on Logout button at bug detail page
	Then User should be logged out and should be at Home Page
	Examples: 
	| TestCase | flink      | lTitle             | user                      | pass   | eTitle    | bTitle            | Severity | Hardware   | Platform | Summary     | Desc     |
	| A        | File a Bug | Log in to Bugzilla | artemminsadyrov@seznam.cz | 159357 | Enter Bug | Enter Bug: Testng | critical | Macintosh | Other    | Summary - 1 | Desc - 1 |
	| B        | File a Bug | Log in to Bugzilla | artemminsadyrov@seznam.cz | 159357 | Enter Bug | Enter Bug: Testng | major    | Other     | Linux    | Summary - 2 | Desc - 2 |