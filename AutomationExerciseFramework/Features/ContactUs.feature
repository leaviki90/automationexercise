﻿Feature: ContactUs
	As a user
	I want to be able to work with ontact Us section
	So I can message customer support

@mytag
Scenario: User can send message via contact form
	Given user opens contact us page
	When user enters all required fields
	  And user submits contact us form
	  And confirms the prompt message
	Then user will receive "Success! Your details have been submitted successfully." message
	
