using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExerciseFramework.Pages
{
    class HeaderPage
    {
        readonly IWebDriver _driver;
        public By header = By.Id("header");
        public By loginLink = By.ClassName("fa-lock");
        public By deleteAcc = By.ClassName("fa-trash-o");
        public By contactLink = By.ClassName("fa-envelope");
        public By productLink = By.ClassName("card_travel");

        public HeaderPage(IWebDriver driver) //konstruktor
        {
            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15)); //eksplicitni wait, koliko Selenium max 
            //čeka da se element pojavi na stranici
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(header));
        }
    }
}
