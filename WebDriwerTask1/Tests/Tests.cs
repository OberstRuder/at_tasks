using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriwer.Task1;

namespace Tests
{
    public class Tests
    {
        private IWebDriver driver;
        private PastebinPage pastebinPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            pastebinPage = new PastebinPage(driver);
        }

        [Test]
        public void Test_CreateNewPaste()
        {
            pastebinPage.PostCode("helloweb", "Hello from WebDriver");

            ClassicAssert.AreEqual("Hello from WebDriver", pastebinPage.Code());
            ClassicAssert.AreEqual("helloweb", pastebinPage.Title());
            ClassicAssert.AreEqual("10 Minutes", pastebinPage.Expiration());
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
