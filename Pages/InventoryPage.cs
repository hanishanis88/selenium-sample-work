using OpenQA.Selenium;
using selenium_sample_work.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace selenium_sample_work.Pages
{
    public class InventoryPage
    {
        private readonly IWebDriver driver;

        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IReadOnlyCollection<IWebElement> Items => driver.FindElements(By.ClassName("inventory_item"));
        private IReadOnlyCollection<IWebElement> Prices => driver.FindElements(By.ClassName("inventory_item_price"));
        private IWebElement CartButton => driver.FindElement(By.ClassName("shopping_cart_link"));

        // Add a random item to cart
        public void AddRandomItemToCart()
        {
            var itemList = Items.ToList();
            int randomIndex = Helpers.GenerateRandomIndex(itemList.Count);
            var button = itemList[randomIndex].FindElement(By.TagName("button"));
            button.Click();
        }

        // Get all prices as double
        public List<double> GetPrices()
        {
            return Prices.Select(p => double.Parse(p.Text.Replace("$", ""))).ToList();
        }

        public void ClickCart()
        {
            CartButton.Click();
        }

        public bool VerifyItemAdded()
        {
            return driver.FindElements(By.ClassName("cart_item")).Count > 0;
        }
    }
}