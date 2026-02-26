using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace selenium_sample_work.Base
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();

            // Detect CI (GitHub Actions sets CI=true)
            bool isCI = Environment.GetEnvironmentVariable("CI") == "true";

            if (isCI)
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
                options.AddArgument("--window-size=1920,1080");
            }

            driver = new ChromeDriver(options);

            // Explicit wait for page load
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

            if (!isCI)
            {
                driver.Manage().Window.Maximize();
            }

            // Navigate once per test
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}