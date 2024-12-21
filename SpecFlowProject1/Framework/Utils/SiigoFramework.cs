using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BaseProject.Framework.Utils;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject1.Framework.Models;

namespace SpecFlowProject1.Framework.Utils
{
    public class SiigoFramework
    {
        string dateHour = DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss");

        public IWebDriver driver;
        private static ExtentReports Reports { get; set; } = new();
        private static ExtentTest extentTest;
        DataInjection Data { get; set; } = new();    

        public SiigoFramework()
        {
            driver = DriverManagerConf.Driver(Data.SiigoURL);
        }

        private ExtentReports SauronStartReporting()
        {
            if (extentTest == null)
            {
                Reports = new ExtentReports();
                var spark = new ExtentSparkReporter(Data.EvidencesFilepath + dateHour + ".html");
                Reports.AttachReporter(spark);
            }
            return Reports;
        }

        public void SiigoCreateReport(string testName)
        {
            extentTest = SauronStartReporting().CreateTest(testName);
        }

        public void SiigoEndReport()
        {
            SauronStartReporting().Flush();
        }

        public void SiigoLogInfo(string info)
        {
            extentTest.Info(info);
        }

        public void SiigoLogPass(string info)
        {
            extentTest.Pass(info);
        }

        public void SiigoLogFail(string info)
        {
            extentTest.Fail(info);
        }

        public void SiigoLogScreenshoot(string info, string image)
        {
            extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }

        public void SiigoScreenshotReport()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Passed:
                    SiigoLogFail($"Test has passed {message}");
                    break;
                case TestStatus.Skipped:
                    SiigoLogInfo($"Test has skipped {message}");
                    break;
                case TestStatus.Failed:
                    SiigoLogInfo($"Test has failed {message}");
                    break;
                default:
                    break;
            }
            SiigoLogScreenshoot("Screenshot Evidence", SiigoGetScreenshot());
        }

        private string SiigoGetScreenshot()
        {
            var file = ((ITakesScreenshot)driver).GetScreenshot();
            var img = file.AsBase64EncodedString;
            return img;
        }
        public WebDriverWait SiigoDriverExplicitWait()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(40));
        }

        public void SiigoWaitFor(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        public void SiigoVisibleElementAssert(By by)
        {
            SiigoDriverExplicitWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            Assert.That(driver.FindElement(by).Enabled);
            SiigoWaitFor(400);
        }

        public void SiigoTextEqualAssert(By by, string expectedString)
        {
            SiigoVisibleElementAssert(by);
            SiigoWaitFor(400);
            Assert.Equals(driver.FindElement(by).Text, expectedString);
        }

        public void SiigoComparisonTwoTextsAssert(string str, string expectedString)
        {
            Assert.Equals(str, expectedString);
        }

        public void SiigoClickJS(By by)
        {
            SiigoDriverExplicitWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            SiigoWaitFor(200);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(by));
        }

        public void SiigoSimpleClick(By by)
        {
            SiigoDriverExplicitWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            driver.FindElement(by).Click();
        }

        public void SiigoClickWebElementJS(WebElement webElement)
        {
            SiigoWaitFor(200);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", webElement);
        }

        public void SiigoWrite(By by, string text)
        {
            SiigoVisibleElementAssert(by);
            SiigoWaitFor(200);
            //driver.FindElement(by).Clear();
            driver.FindElement(by).SendKeys(text);
        }

        public void SiigoWriteJS(By by, string text)
        {
            SiigoVisibleElementAssert(by);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].value += arguments[1];", driver.FindElement(by), text);
        }

        public string SiigoReadDataFromJson(string key)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Data.JsonFilepath)
            .AddJsonFile(Data.FileNameJson)
            .Build();
            return configuration[key];
        }

        public void SiigoHighlightVisible(By by)
        {
            SiigoVisibleElementAssert(by);
            SiigoWaitFor(100);
            var jsDriver = (IJavaScriptExecutor)driver;
            string script = @"arguments[0].style.cssText = ""border-width: 4px; border-style: solid; border-color: green""; ";
            jsDriver.ExecuteScript(script, new object[] { driver.FindElement(by) });
        }

        public void SiigoManageDoubleShadowRoot(By byBeforeShadowRoot, By bySecondShadowRoot, By byElementToInteract)
        {
            IWebElement ShadowHost = driver.FindElement(byBeforeShadowRoot);
            var firstShadowRoot = ShadowHost.GetShadowRoot();
            IWebElement secondShadowHost = firstShadowRoot.FindElement(bySecondShadowRoot);
            var secondShadowRoot = secondShadowHost.GetShadowRoot();
            IWebElement buttonElement = secondShadowRoot.FindElement(byElementToInteract);
            buttonElement.Click();
        }

        public void SiigoManageOneShadowRoot(By byShadowRoot, By byElementToInteract)
        {
            IWebElement ShadowHost = driver.FindElement(byShadowRoot);
            var firstShadowRoot = ShadowHost.GetShadowRoot();
            IWebElement elementToInteract = firstShadowRoot.FindElement(byElementToInteract);
            elementToInteract.Click();
        }

        public void SiigoMoveMouseToElementAndClick(By by)
        {
            SiigoVisibleElementAssert(by);
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(by)).Perform();
            actions.MoveToElement(driver.FindElement(by)).Click().Perform();
        }

        public void SiigoActionsSendTab()
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Tab).Perform();
        }

        public void SiigoGoToURL(string url)
        {
            driver.Url = url;
        }
    }
}
