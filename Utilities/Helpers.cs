using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace selenium_sample_work.Utilities
{
    public static class Helpers
    {
        public static void TakeScreenshot(IWebDriver driver, string filePath)
        {
            if (driver is ITakesScreenshot screenshotDriver)
            {
                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                if (Path.GetExtension(filePath).ToLower() != ".png")
                    filePath += ".png";

                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile(filePath);
            }
        }

        public static int GenerateRandomIndex(int max)
        {
            return new Random().Next(0, max);
        }

        public static double CalculateCartTotal(List<double> prices)
        {
            return prices.Sum();
        }
    }
}