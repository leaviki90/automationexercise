using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExerciseFramework.Pages
{
    class DeletedAccount
    {
        public IWebDriver _driver;

        public By deletedAcc = By.XPath("//h2[@data-qa='account-deleted']");
        public DeletedAccount(IWebDriver driver)  
        {
            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(deletedAcc)); 

        }
    }
}
