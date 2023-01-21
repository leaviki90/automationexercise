using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExerciseFramework.Pages
{
    class CheckoutPage
    {
        readonly IWebDriver _driver;
        public By chekcoutInfo = By.ClassName("checkout-information");
        public By messageArea = By.ClassName("form-control");
        public By placeOrderBtn = By.CssSelector(".btn.check_out");

        public CheckoutPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(chekcoutInfo));
        }
    }
}
