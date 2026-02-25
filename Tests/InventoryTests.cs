using NUnit.Framework;
using selenium_sample_work.Base;
using selenium_sample_work.Pages;
using selenium_sample_work.Utilities;
using System.IO;

namespace selenium_sample_work.Tests
{
    public class InventoryTests : BaseTest
    {
        [Test, Retry(2)] // retry up to 2 times
        public void AddRandomItemAndValidateTotal()
        {
            var loginPage = new LoginPage(driver);
            var inventoryPage = new InventoryPage(driver);

            // Login
            loginPage.Navigate();
            loginPage.Login("standard_user", "secret_sauce");

            // Add random item
            inventoryPage.AddRandomItemToCart();
            inventoryPage.ClickCart();

            // Verify item added
            Assert.That(inventoryPage.VerifyItemAdded(), Is.True, "Item was not added to cart");

            // Validate total
            var prices = inventoryPage.GetPrices();
            var total = Helpers.CalculateCartTotal(prices);
            Assert.That(total, Is.GreaterThan(0), "Cart total should be greater than 0");

            // Take screenshot
            string screenshotsDir = Path.Combine(Directory.GetCurrentDirectory(), "screenshots");
            Directory.CreateDirectory(screenshotsDir);
            Helpers.TakeScreenshot(driver, Path.Combine(screenshotsDir, "cart_screenshot.png"));
        }
    }
}