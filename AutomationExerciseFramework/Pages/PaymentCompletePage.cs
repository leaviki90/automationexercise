using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExerciseFramework.Pages
{
    class PaymentCompletePage
    {
        readonly IWebDriver _driver;
        public By orderPlacedTitle = By.XPath("//h2[@data-qa='order-placed']");
        //public By successMessage = By.XPath("//*[contains(text(),'Congratulations! Your order has been confirmed!')]");

        public PaymentCompletePage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(orderPlacedTitle));
        }
    }
}
