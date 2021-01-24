Feature: SmsService

Scenario: Throw Exception When The SmsClient Retrunes Any Error
	Given we have a command to send
	And client is returning an error
	When SmsService try to send command
	Then the exception '<error>' should be Thrown
	Examples:
	| error |
	| Failed To send phone number {0} and message {1} |

Scenario: Throw Exception When The EventPublisher Retrunes Any Error
	Given client is returning no errors
	And we have a command to send
	And eventpublisher is returning an error
	When SmsService try to raise event
	Then the exception '<error>' should be Thrown
	Examples: 
	| error |
	| Failed To raise Sms Sent Event to phone number {0} and message {1} |

Scenario: No Exception Is Thrown When The EventPublisher And SmsClient Retrunes No Error
	Given client is returning no errors
	And EventPublisher is returning no errors
	And we have a command to send
	When SmsService try to raise event
	Then no exception should be Thrown 
	And eventpublisher and client is called
