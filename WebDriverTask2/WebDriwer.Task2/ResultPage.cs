using OpenQA.Selenium;

namespace WebDriwer.Task2
{
    public class ResultPage
    {
        private readonly IWebDriver _webDriver;

        private IList<IWebElement> PasteText => _webDriver.FindElements(By.XPath("//*[@class='de1']"));
        private IWebElement PasteTitle => _webDriver.FindElement(By.XPath("//*[@class='info-top']"));
        private IWebElement Expiration => _webDriver.FindElement(By.XPath("//*[@class='expire']"));
        private IWebElement SyntaxHighlighting => _webDriver.FindElement(By.XPath("//div[@class='left']/a[@class='btn -small h_800']"));

        public ResultPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetPasteText()
        {
            return string.Join("\n", PasteText.Select(element => element.Text));
        }

        public string GetPasteTitle()
        {
            return PasteTitle.Text;
        }

        public string GetSyntaxHighlighting()
        {
            return SyntaxHighlighting.Text;
        }
    }
}
