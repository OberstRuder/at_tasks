using OpenQA.Selenium;

namespace WebDriwer.Task1
{
    public class PastebinPage
    {
        private IWebDriver driver;
        private IWebElement text;
        private IWebElement title;
        private IWebElement expirationContainer;
        private IWebElement expirationTenMin;

        public PastebinPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl("https://pastebin.com/");
            text = driver.FindElement(By.Id("postform-text"));
            title = driver.FindElement(By.Id("postform-name"));
            expirationContainer = driver.FindElement(By.Id("select2-postform-expiration-container"));
        }

        public void PostCode(string name, string code)
        {
            text.SendKeys(code);
            title.SendKeys(name);
            expirationContainer.Click();

            expirationTenMin = driver.FindElement(By.XPath("/html/body/span[2]/span/span[2]/ul/li[3]"));
            expirationTenMin.Click();
        }

        public string Code()
        {
            return text.GetAttribute("value");
        }

        public string Title()
        {
            return title.GetAttribute("value");
        }

        public string Expiration()
        {
            return expirationContainer.Text;
        }
    }
}
