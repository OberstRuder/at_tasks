using OpenQA.Selenium;

namespace WebDriwer.Task2
{
    public class PastebinPage
    {
        private const string HomepageUrl = "https://pastebin.com/";
        private const string XpathTenMinute = "/html/body/span[2]/span/span[2]/ul/li[3]";
        private readonly IWebDriver _driver;

        private IWebElement Text => _driver.FindElement(By.Id("postform-text"));
        private IWebElement Title => _driver.FindElement(By.Id("postform-name"));
        private IWebElement ExpirationContainer => _driver.FindElement(By.Id("select2-postform-expiration-container"));
        private IWebElement ExpirationTenMin => _driver.FindElement(By.XPath(XpathTenMinute));
        private IWebElement FormatContainer => _driver.FindElement(By.Id("select2-postform-format-container"));
        private IWebElement FormatBash => _driver.FindElement(By.XPath("//ul/li[text()[contains(.,'Bash')]]"));

        public PastebinPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl(HomepageUrl);
        }

        public ResultPage PostCode(string name, string code)
        {
            Title.SendKeys(name);
            FormatContainer.Click();
            FormatBash.Click();
            ExpirationContainer.Click();
            ExpirationTenMin.Click();
            Text.SendKeys(code);
            Text.Submit();

            return new ResultPage(_driver);
        }
    }
}
