Feature: JokeTests
	Simple tests of the Dad Joke API

Scenario: Get a random joke
	Given a joke already exists
	When the endpoint for a random joke is called
	Then a joke should be returned