using OpenQA.Selenium;


namespace Framework
{
    public abstract class BasePage
    {
        protected readonly IWebDriver WebDriver;

        protected BasePage(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
        }

        public abstract BasePage OpenPage();

        protected void SwitchToTab(string originalTab, int numberOfWindows)
        {
            WaitUtil.WaitForOpenNewTab(WebDriver, 10, numberOfWindows);
            var windowHandles = WebDriver.WindowHandles;
            var newTab = windowHandles.First(windowHandle => !originalTab.Equals(windowHandle));
            WebDriver.SwitchTo().Window(newTab);
        }

        public string GetPagetitle() {
            return WebDriver.Title;
        }
    }


}
