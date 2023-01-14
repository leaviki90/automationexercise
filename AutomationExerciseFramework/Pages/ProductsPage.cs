using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExerciseFramework.Pages
{
    class ProductsPage
    {
        readonly IWebDriver _driver;
        public By advertisement = By.Id("advertisement");
        public By searchInput = By.Id("search_product");
        public By searchBtn = By.Id("submit_search");
        public By viewProduct = By.XPath("//a[contains(@href, 'product_details')]");
        
        public ProductsPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(advertisement)); 
        }
    }
}
