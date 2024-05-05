using OpenQA.Selenium;

namespace WebDriwer.Task2
{
    public class PastebinPage
    {
        private const string MainPageUrl = "https://pastebin.com/";
        private readonly IWebDriver _webDriver;

        private IWebElement PasteText => _webDriver.FindElement(By.XPath("//*[@id='postform-text']"));
        private IWebElement PasteTitle => _webDriver.FindElement(By.XPath("//*[@id='postform-name']"));
        private IWebElement ExpirationDropDown => _webDriver.FindElement(By.XPath("//*[@id='select2-postform-expiration-container']"));
        private IWebElement SyntaxHighlightingDropDown => _webDriver.FindElement(By.XPath("//*[@id='select2-postform-format-container']"));
        private IWebElement CreateNewPasteButton => _webDriver.FindElement(By.XPath("//*[@class='btn -big']"));

        public PastebinPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public PastebinPage OpenPage()
        {
            _webDriver.Navigate().GoToUrl(MainPageUrl);
            return this;
        }

        public PastebinPage SetPasteText(string text)
        {
            PasteText.SendKeys(text);
            return this;
        }

        public PastebinPage SelectPasteSyntaxHighlighting(string syntaxHighlighting)
        {
            SyntaxHighlightingDropDown.Click();
            var option = _webDriver.FindElement(By.XPath("//li[text()='" + syntaxHighlighting + "']"));
            option.Click();
            return this;
        }

        public PastebinPage SelectPasteExpiration(string expiration)
        {
            ExpirationDropDown.Click();
            var option = _webDriver.FindElement(By.XPath("//li[text()='" + expiration + "']"));
            option.Click();
            return this;
        }

        public PastebinPage SetPasteTitle(string title)
        {
            PasteTitle.SendKeys(title);
            return this;
        }

        public ResultPage CreateNewPaste()
        {
            CreateNewPasteButton.Click();
            return new ResultPage(_webDriver);
        }
    }
}
