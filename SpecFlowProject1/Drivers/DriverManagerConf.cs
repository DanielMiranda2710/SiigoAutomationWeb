using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace BaseProject.Framework.Utils
{
    public static class DriverManagerConf
    {
        private static IWebDriver? driver;

        public static IWebDriver Driver(string url)
        {
            if (driver is null)
            {
                string browserName = "chrome";
                switch (browserName.ToLower())
                {
                    case "chrome":
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        ChromeOptions options = new ChromeOptions();
                        options.AddArguments("incognito");
                        options.AddArguments("--start-fullscreen");
                        driver = new ChromeDriver(options);
                        break;

                    case "firefox":
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        firefoxOptions.AddArguments("--private");
                        firefoxOptions.AddArguments("--maximized");
                        driver = new FirefoxDriver(firefoxOptions);
                        break;

                    case "safari":
                        var nodeUrlS = new Uri("http://localhost:4445/ui#");
                        SafariOptions safariOptions = new SafariOptions();
                        break;

                    case "edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        EdgeOptions edgeOptions = new EdgeOptions();
                        edgeOptions.AddArguments("incognito");
                        edgeOptions.AddArguments("--start-fullscreen");
                        driver = new EdgeDriver(edgeOptions);
                        break;

                    default:
                        throw new Exception("Unsupported browser");
                }
                driver.Url = url;
            }
            return driver;
        }
    }
}




