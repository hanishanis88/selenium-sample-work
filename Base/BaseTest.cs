using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using selenium_sample_work.Utilities;

namespace selenium_sample_work.Base
{
    public class BaseTest
    {
        private IWebDriver driverInstance;

        protected IWebDriver Driver => driverInstance;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();

            // Headless if running in CI
            bool isCI = Environment.GetEnvironmentVariable("CI") == "true";
            if (isCI)
            {
                options.AddArgument("--headless");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
            }

            driverInstance = new ChromeDriver(options);

            // Maximize locally
            if (!isCI)
            {
                driverInstance.Manage().Window.Maximize();
            }
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                // Take screenshot if test failed
                if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
                {
                    string screenshotsDir = Path.Combine(Directory.GetCurrentDirectory(), "screenshots");
                    Directory.CreateDirectory(screenshotsDir);
                    string screenshotPath = Path.Combine(screenshotsDir, $"{TestContext.CurrentContext.Test.Name}.png");
                    Helpers.TakeScreenshot(driverInstance, screenshotPath);
                    Console.WriteLine($"Screenshot saved to {screenshotPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to take screenshot: {ex.Message}");
            }
            finally
            {
                driverInstance?.Quit();
                driverInstance?.Dispose();
            }
        }
    }
}