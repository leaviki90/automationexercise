using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExerciseFramework.Helpers
{
    class Utilities   //nije page klasa, konstruktor nema uslov
    {
        readonly IWebDriver _driver;
        private static readonly Random RandomName = new Random();

        public Utilities(IWebDriver driver)
        {
            this._driver = driver;
        }

        //metoda za random email adresu

        public string GenerateRandomEmail()
        {
            return string.Format("email{0}@mailinator.com", RandomName.Next(10000, 100000));           //vraca ceo broj; od do
        }

        //metoda za klik na elemente
        public void ClickOnElement(By locator) //prima arg lokator (tako smo ga nazvali)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator)).Click();
        }
        public void EnterTextInElement(By locator, string text)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)).SendKeys(text);   //ne samo da postoji, vec da ima i size
        }

        public bool ElementIsDisplayed(By selector)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector)).Displayed; //da pretvori u boolean
        }
        public void DropdownSelect(By select, string option)  //by ime, string ime
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));  //ne mora kao var, moze kao obj
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(select)); 
            var dropdown = _driver.FindElement(select);
            var selectElement = new SelectElement(dropdown);
            selectElement.SelectByValue(option);
        }
        public bool TextPresentInElement(string text)
        {
            By headline = By.XPath("//*[contains(text(), '" + text + "')]"); // ovako prosledjujemo bilo koji text
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(headline)).Displayed; 
            //displayed je tipa boolean
        }

        public string ReturnTextFromElement(By locator)
        {
            return _driver.FindElement(locator).GetAttribute("textContent");   // ili Text() ova je caseSensitive
        }
    }

    }
