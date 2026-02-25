using NUnit.Framework;
using selenium_sample_work.Base;
using selenium_sample_work.Pages;

namespace selenium_sample_work.Tests
{
    public class LoginTests : BaseTest
    {
        [Test]
        public void ValidUser_Should_LoginSuccessfully()
        {
            var loginPage = new LoginPage(driver);

            loginPage.Navigate();
            loginPage.Login("standard_user", "secret_sauce");

            Assert.That(driver.Url, Does.Contain("inventory"));
        }

        [Test]
        public void LockedOutUser_Should_ShowErrorMessage()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Navigate();

            // Use locked out user credentials
            string lockedOutUsername = "locked_out_user";
            string password = "secret_sauce";

            loginPage.Login(lockedOutUsername, password);

            // Assert error message
            string errorMessage = loginPage.GetErrorMessage();
            Assert.That(errorMessage, Does.Contain("locked out"), "Expected 'locked out' message for locked out user");
        }
    }
}