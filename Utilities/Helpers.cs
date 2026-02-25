using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace selenium_sample_work.Utilities
{
    public static class Helpers
    {
        private static readonly Random random = new Random();

        // Generate a random index
        public static int GenerateRandomIndex(int length)
        {
            return random.Next(length);
        }

        // Calculate total price from a list of doubles
        public static double CalculateCartTotal(List<double> prices)
        {
            return prices.Sum();
        }

        // Take screenshot
        public static void TakeScreenshot(IWebDriver driver, string fileName)
        {
            try
            {
                if (driver is ITakesScreenshot screenshotDriver)
                {
                    Screenshot screenshot = screenshotDriver.GetScreenshot();
                    screenshot.SaveAsFile(fileName); // save as .png by filename
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to take screenshot: {ex.Message}");
            }
        }
    }
}