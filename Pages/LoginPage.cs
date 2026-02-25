using OpenQA.Selenium;

namespace selenium_sample_work.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement UsernameInput => driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordInput => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("login-button"));
        private IWebElement ErrorMessage => driver.FindElement(By.CssSelector("h3[data-test='error']"));

        public void Navigate()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        public void Login(string username, string password)
        {
            UsernameInput.Clear();
            UsernameInput.SendKeys(username);
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
            LoginButton.Click();
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }
    }
}