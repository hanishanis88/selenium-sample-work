using NUnit.Framework;
using selenium_sample_work.Base;
using selenium_sample_work.Pages;
using selenium_sample_work.Utilities;

namespace selenium_sample_work.Tests
{
    public class InventoryTests : BaseTest
    {
        [Test, Retry(2)]
        public void AddRandomItemAndValidateTotal()
        {
            var loginPage = new LoginPage(Driver);
            var inventoryPage = new InventoryPage(Driver);

            loginPage.Navigate();
            loginPage.Login("standard_user", "secret_sauce");

            inventoryPage.AddRandomItemToCart();
            inventoryPage.ClickCart();

            Assert.That(inventoryPage.VerifyItemAdded(), Is.True, "Item was not added to cart");

            var prices = inventoryPage.GetPrices();
            var total = Helpers.CalculateCartTotal(prices);
            Assert.That(total, Is.GreaterThan(0), "Cart total should be greater than 0");
        }
    }
}