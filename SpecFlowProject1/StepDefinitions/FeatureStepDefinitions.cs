using SpecFlowProject1.Framework.Steps;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class FeatureStepDefinitions
    {
        SiigoSteps Siigo { get; set; } = new();

        [Given(@"Open the browser in the URL")]
        public void GivenOpenTheBrowserInTheURL()
        {

        }

        [When(@"Enter the correct credentials")]
        public void WhenEnterTheCorrectCredentials()
        {
            Siigo.LoginJsonFileSuccessfully();
        }

        [Then(@"Go to clients option")]
        public void ThenGoToClientsOption()
        {
            Siigo.ValidationClients();
        }

        [When(@"Enter the correct credentials in the siigo pos")]
        public void WhenEnterTheCorrectCredentialsInTheSiigoPos()
        {
            Siigo.LoginJsonFileSuccessfullySiigoPos();
        }

        [Then(@"Create the input document, interacting with the options: Products, Generic product, Charge")]
        public void ThenCreateTheInputDocumentInteractingWithTheOptionsProductsGenericProductCharge()
        {
        }


    }
}
