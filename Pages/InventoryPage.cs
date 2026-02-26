using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using selenium_sample_work.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace selenium_sample_work.Pages
{
    public class InventoryPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IReadOnlyCollection<IWebElement> Items =>
            driver.FindElements(By.ClassName("inventory_item"));

        private IReadOnlyCollection<IWebElement> Prices =>
            driver.FindElements(By.ClassName("inventory_item_price"));

        private IWebElement CartButton =>
            driver.FindElement(By.ClassName("shopping_cart_link"));

        // Add a random item to cart
        public void AddRandomItemToCart()
        {
            var itemList = wait.Until(d =>
                Items.Where(i => i.Displayed).ToList()
            );

            int randomIndex = Helpers.GenerateRandomIndex(itemList.Count);

            var button = wait.Until(d =>
                itemList[randomIndex].FindElement(By.TagName("button"))
            );

            button.Click();
        }

        // Get all prices
        public List<double> GetPrices()
        {
            var priceElements = wait.Until(d => Prices.Any());

            return Prices
                .Select(p => double.Parse(p.Text.Replace("$", "")))
                .ToList();
        }

        // Click cart button
        public void ClickCart()
        {
            wait.Until(d => CartButton.Displayed);
            CartButton.Click();
        }

        // Verify item added
        public bool VerifyItemAdded()
        {
            return wait.Until(d =>
                d.FindElements(By.ClassName("cart_item")).Any()
            );
        }
    }
}