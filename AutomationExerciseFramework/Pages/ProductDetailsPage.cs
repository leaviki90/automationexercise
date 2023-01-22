using AutomationExerciseFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExerciseFramework.Pages
{
    class ProductDetailsPage : Base
    {
        readonly IWebDriver _driver;
        public By productDetails = By.ClassName("product-details");
        public By addToCartBtn = By.ClassName("cart");
        public By viewCartBtn = By.CssSelector(".modal-confirm a");
        public By productId = By.Id("product_id");
        public By productName = By.CssSelector(".product-information h2");
        public By yourName = By.Id("name");
        public By emailAddress = By.Id("email");
        public By reviewMessage = By.Id("review");
        public By form = By.Id("review-form");
        public By alert = By.Id("review-section");
        public ProductDetailsPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15)); 
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(productDetails));
        }

    }
}
