using NUnit.Framework;
using IhsMarkitEval.Pages;
using IhsMarkitEval.Utilities;

namespace IhsMarkitEval.Tests
{
    [TestFixture(BrowserType.Chrome, Category = "Chrome")]
    [TestFixture(BrowserType.Firefox, Category = "Firefox")]
    public class UiTest : BaseTest
    {

        public UiTest(BrowserType browser) : base(browser) { }

        [TestCase(Description = "Checks output window text after clicking run button.")]
        public void TestOutputWindowTextAfterClickingRun()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.ClearOutputText();
            homePage.ClickRunButton();
            bool outputTextCorrect = homePage.VerifyOutputWindowText("Hello World");
            Assert.IsTrue(outputTextCorrect, "Output text is incorrect!");
        }

        [TestCase(Description = "Login modal displays after clicking save button when not logged in.")]
        public void TestLoginModalDisplaysAfterClickingSaveNoLogin()
        {
            HomePage homePage = new HomePage(Driver);
            LoginModal loginModal = homePage.ClickSaveButtonWhenNotLoggedIn();
            bool loginModalDisplayed = loginModal.VerifyLoginModalOpen();
            Assert.IsTrue(loginModalDisplayed, "Login modal failed to load!");
        }
    }
}