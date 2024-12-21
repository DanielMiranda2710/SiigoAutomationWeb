Feature: Login Successfully

Login success

@Testers
Scenario: Login successfully in Siigo app
	Given Open the browser in the URL
	When Enter the correct credentials
	Then Go to clients option

	Scenario: Login successfully in Siigo Pos app
	Given Open the browser in the URL
	When Enter the correct credentials in the siigo pos
	Then Create the input document, interacting with the options: Products, Generic product, Charge
