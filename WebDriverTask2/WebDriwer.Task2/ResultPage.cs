using OpenQA.Selenium;

namespace WebDriwer.Task2
{
    public class ResultPage
    {
        private readonly IWebDriver _driver;

        private IWebElement Title => _driver.FindElement(By.ClassName("content__title"));
        private IWebElement Text => _driver.FindElement(By.ClassName("content__text"));

        public ResultPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetTitle()
        {
            return Title.Text;
        }

        public string GetText()
        {
            return Text.Text;
        }
    }
}
