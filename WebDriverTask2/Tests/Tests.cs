using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriwer.Task2;

namespace Tests
{
    public class Tests
    {
        [TestFixture]
        public class Test
        {
            public const string PasteText = "git config --global user.name  \"New Sheriff in Town\"\n" +
                                        "git reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")\n" +
                                        "git push origin master --force";
            public const string SyntaxHighlighting = "Bash";
            public const string PasteTitle = "how to gain dominance among developers";
            public const string PasteExpiration = "10 Minutes";
            public const string PageTitle = PasteTitle;

            private IWebDriver _webDriver;

            [SetUp]
            public void SetUp()
            {
                _webDriver = new ChromeDriver();
                _webDriver.Manage().Window.Maximize();
            }

            [Test]
            public void CreateNewPasteTest()
            {
                var page = new PastebinPage(_webDriver);
                var result = page.OpenPage()
                    .SetPasteText(PasteText)
                    .SelectPasteSyntaxHighlighting(SyntaxHighlighting)
                    .SelectPasteExpiration(PasteExpiration)
                    .SetPasteTitle(PasteTitle)
                .CreateNewPaste();

                ClassicAssert.AreEqual(PageTitle, result.GetPasteTitle());
                ClassicAssert.AreEqual(SyntaxHighlighting, result.GetSyntaxHighlighting());
                ClassicAssert.AreEqual(PasteText, result.GetPasteText());
            }

            [TearDown]
            public void TearDown()
            {
                _webDriver?.Quit();
            }
        }
    }
}
