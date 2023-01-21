using AutomationExerciseFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExerciseFramework.Pages
{
    class CartPage 
    {
        readonly IWebDriver _driver;
        public By cartInfoTable = By.Id("cart_info_table");
        public By proceedBtn = By.CssSelector(".btn.check_out");
        public CartPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(cartInfoTable));
        }
    }
}
