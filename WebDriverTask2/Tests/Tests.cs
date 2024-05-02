using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriwer.Task2;

namespace Tests
{
    public class Tests
    {
        [TestFixture]
        public class BringItOnTest
        {
            private const string Title = "how to gain dominance among developers";
            private const string Code = @"
            git config --global user.name  ""New Sheriff in Town""
            git reset $(git commit-tree HEAD^{tree} -m ""Legacy code"")
            git push origin master --force
            ";

            private IWebDriver _driver;
            private PastebinPage _pastebinPage;

            [SetUp]
            public void SetUp()
            {
                _driver = WebDriver();
                _pastebinPage = new PastebinPage(_driver);
            }

            [TearDown]
            public void TearDown()
            {
                _driver.Quit();
            }

            [Test]
            public void PostCode()
            {
                var response = _pastebinPage.PostCode(Title, Code);

                ClassicAssert.AreEqual("Bad Request (#400)", response.GetTitle());
                ClassicAssert.AreEqual("Unable to verify your data submission.", response.GetText());
            }

            private IWebDriver WebDriver()
            {
                var options = new ChromeOptions();
                options.AddArgument("--incognito");
                options.AddArgument("start-maximized");
                options.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2);
                var driver = new ChromeDriver(options);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                return driver;
            }
        }
    }
}
