Feature: Add task

@Tasks
Scenario: Add task with empty name should not be allowed
	Given I am on the main page
	Then Add should be disabled

@Tasks
Scenario: Add task with invalid name should not be allowed
	Given I am on the main page
	And I enter a task name containing just spaces
	Then Add should be disabled
		
@Tasks
Scenario: Add task with a duplicate name should not be allowed
	Given I am on the main page
	And I enter a task named New Task
	And I choose add
	And I enter a task named New Task
	Then Add should be disabled

@Tasks
Scenario: Add task with valid name should be allowed
	Given I am on the main page
	And I enter a task named New Task
	Then Add should be enabled

@Tasks
Scenario: Add task with unique name should add to list
	Given I am on the main page
	And I enter a task named New Task
	And I choose add
	Then the list should show New Task