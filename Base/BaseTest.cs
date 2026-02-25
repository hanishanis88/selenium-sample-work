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

            // Headless if running in CI (GitHub Actions sets CI=true)
            var isCI = Environment.GetEnvironmentVariable("CI") == "true";
            if (isCI)
            {
                options.AddArgument("--headless");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
            }

            driver = new ChromeDriver(options);

            // Optional: maximize window locally
            if (!isCI)
            {
                driver.Manage().Window.Maximize();
            }
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