using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using selenium_sample_work.Utilities;
using System;
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

        public void AddRandomItemToCart()
        {
            var itemList = Items.ToList();
            int randomIndex = Helpers.GenerateRandomIndex(itemList.Count);
            var button = itemList[randomIndex].FindElement(By.TagName("button"));
            button.Click();
        }

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
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.Until(ExpectedConditions.ElementExists(By.ClassName("cart_item")));
                return driver.FindElements(By.ClassName("cart_item")).Count > 0;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}