using AutomationExerciseFramework.Helpers;
using AutomationExerciseFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Linq;
using TechTalk.SpecFlow;

namespace AutomationExerciseFramework.Steps
{
    [Binding]
    public class PDPSteps : Base
    {
        Utilities ut = new Utilities(Driver);
        HeaderPage hp = new HeaderPage(Driver);
   

        [Given(@"user opens products page")]
        public void GivenUserOpensProductsPage()
        {
            ut.ClickOnElement(hp.productLink);
        }
        
        [Given(@"searches for ""(.*)"" term")]
        public void GivenSearchesForTerm(string searchedTerm)
        {
            ProductsPage pp = new ProductsPage(Driver);
            ut.EnterTextInElement(pp.searchInput, searchedTerm);
            ut.ClickOnElement(pp.searchBtn);
        }
        
        [Given(@"opens first search result")]
        public void GivenOpensFirstSearchResult()
        {
            ProductsPage pp = new ProductsPage(Driver);

            Driver.FindElement(pp.viewProduct).Click();

        }
        
        [When(@"user clicks on Add to Cart button")]
        public void WhenUserClicksOnAddToCartButton()
        {
            ProductDetailsPage pdp = new ProductDetailsPage(Driver);
            string valueFromInput = Driver.FindElement(pdp.productId).GetAttribute("value");
            Console.WriteLine(valueFromInput);

            ut.ClickOnElement(pdp.addToCartBtn);
        }
        
        [When(@"proceeds to cart")]
        public void WhenProceedsToCart()
        {
            ProductDetailsPage pdp = new ProductDetailsPage(Driver);
            ut.ClickOnElement(pdp.viewCartBtn);
            
        }
        
        [Then(@"shopping cart will be displayed with ""(.*)"" product inside")]
        public void ThenShoppingCartWillBeDisplayedWithProductInside(string p0)
        {
            //Assert.True(ut.ElementIsDisplayed(), "Ooops, no results found!");
            

        }
    }
}
