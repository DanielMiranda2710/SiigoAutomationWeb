using OpenQA.Selenium;

namespace SpecFlowProject1.Framework.PageObjects
{
    public class HomePage
    {
        public static readonly By FirstShadowRootCreate = By.CssSelector("siigo-header-molecule");
        public static readonly By SecondShadowRootCreate = By.CssSelector("siigo-button-atom[data-id='header-create-button']");
        public static readonly By ShadowRootElementToInteractCreate = By.CssSelector("button");
        public static readonly By ShadowRootElementToInteractClients = By.CssSelector("a[data-value='Clientes']");
        public static readonly By SiigoValidation = By.XPath("//div[text()=' Inicio ']");
        public static readonly By CreateThirdValidation = By.XPath("//h2[text()='Crear un tercero']");
    }
}
