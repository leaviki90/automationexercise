using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExerciseFramework.Pages
{
    class PaymentPage
    {
        readonly IWebDriver _driver;
        public By paymentInfo = By.ClassName("payment-information");
        public By paymentForm = By.Id("payment-form");
        public By cardName = By.XPath("//input[@name='name_on_card']");
        public By cardNumber = By.XPath("//input[@name='card_number']");
        public By cVC = By.XPath("//input[@name='cvc']");
        public By expirationMonth = By.XPath("//input[@name='expiry_month']");
        public By expirationYear = By.XPath("//input[@name='expiry_year']");


        public PaymentPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(paymentInfo));
        }
    }
}
