using OpenQA.Selenium;

namespace SpecFlowProject1.Framework.PageObjects
{
    public class LoginPage
    {
        public static readonly By UsernameInput = By.Name("username-input");
        public static readonly By PasswordInput = By.Name("password-input");
        public static readonly By LoginButton = By.CssSelector("button");

        public static readonly By UsernameSiigoPosInput = By.Id("email");
        public static readonly By PasswordSiigoPosInput = By.Id("current-password");
        public static readonly By LoginSiigoPosButton = By.XPath("//*[contains(text(),'Ingresar')]");

    }
}
