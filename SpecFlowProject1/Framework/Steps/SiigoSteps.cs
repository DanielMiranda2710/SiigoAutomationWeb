using OpenQA.Selenium;
using SpecFlowProject1.Framework.Models;
using SpecFlowProject1.Framework.PageObjects;
using SpecFlowProject1.Framework.Utils;

namespace SpecFlowProject1.Framework.Steps
{
    public class SiigoSteps : SiigoFramework
    {

        DataInjection Data { get; set; } = new();

        public void LoginJsonFileSuccessfully()
        {
            SiigoCreateReport("Login to Siigo App");
            SiigoLogInfo("Login Successfully");
            SiigoSimpleClick(LoginPage.UsernameInput);
            SiigoWrite(LoginPage.UsernameInput, SiigoReadDataFromJson("username"));
            SiigoSimpleClick(LoginPage.PasswordInput);
            SiigoWrite(LoginPage.PasswordInput, SiigoReadDataFromJson("password"));
            SiigoScreenshotReport();
            SiigoSimpleClick(LoginPage.LoginButton); 
            SiigoVisibleElementAssert(HomePage.SiigoValidation);
            SiigoManageDoubleShadowRoot(HomePage.FirstShadowRootCreate, HomePage.SecondShadowRootCreate, HomePage.ShadowRootElementToInteractCreate);
            SiigoManageOneShadowRoot(HomePage.FirstShadowRootCreate, HomePage.ShadowRootElementToInteractClients);
            SiigoEndReport();

        }

        public void ValidationClients()
        {
            SiigoCreateReport("Client options validation");
            SiigoLogInfo("Client options");
            SiigoHighlightVisible(HomePage.CreateThirdValidation);
            SiigoScreenshotReport();
            SiigoEndReport();
        }

        public void LoginJsonFileSuccessfullySiigoPos()
        {
            SiigoGoToURL(Data.SiigoPosURL);
            SiigoWaitFor(5000);
            SiigoActionsSendTab();
            SiigoWrite(LoginPage.UsernameSiigoPosInput, SiigoReadDataFromJson("username"));
            SiigoActionsSendTab();
            SiigoWrite(LoginPage.PasswordSiigoPosInput, SiigoReadDataFromJson("password"));
            SiigoWrite(LoginPage.PasswordSiigoPosInput, Keys.Enter);
        }
    }
}
