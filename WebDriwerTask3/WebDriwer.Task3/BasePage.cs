using OpenQA.Selenium;


namespace WebDriwer.Task3
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
    }


}
