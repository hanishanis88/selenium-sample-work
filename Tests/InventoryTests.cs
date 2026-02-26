using NUnit.Framework;
using selenium_sample_work.Base;
using selenium_sample_work.Pages;
using selenium_sample_work.Utilities;
using System.IO;

namespace selenium_sample_work.Tests
{
    public class InventoryTests : BaseTest
    {
        [Test, Retry(2)]
        public void AddRandomItemAndValidateTotal()
        {
            var loginPage = new LoginPage(driver);
            var inventoryPage = new InventoryPage(driver);

            // Login
            loginPage.Navigate();
            loginPage.Login("standard_user", "secret_sauce");

            // Add random item
            inventoryPage.AddRandomItemToCart();

            // Go to cart
            inventoryPage.ClickCart();

            // Verify item exists in cart
            Assert.That(
                inventoryPage.VerifyItemAdded(),
                Is.True,
                "Item was not added to cart"
            );

            // Screenshot (after cart loads)
            string screenshotsDir = Path.Combine(
                Directory.GetCurrentDirectory(),
                "screenshots"
            );

            Directory.CreateDirectory(screenshotsDir);

            Helpers.TakeScreenshot(
                driver,
                Path.Combine(screenshotsDir, "cart_screenshot.png")
            );
        }
    }
}