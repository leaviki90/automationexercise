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

        private readonly ProductData productData; //promenljiva tipa ProductData

        public PDPSteps(ProductData productData)   //da bi promenljiva bila dostupna na celoj ovoj strani (globalna)
        {
            this.productData = productData;
        }

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
            productData.ProductName = ut.ReturnTextFromElement(pdp.productName);
            Console.WriteLine(productData.ProductName);

            ut.ClickOnElement(pdp.addToCartBtn);
        }
        
        [When(@"proceeds to cart")]
        public void WhenProceedsToCart()
        {
            ProductDetailsPage pdp = new ProductDetailsPage(Driver);
            ut.ClickOnElement(pdp.viewCartBtn);
            
        }
        
        [Then(@"shopping cart will be displayed with expected product inside")]
        public void ThenShoppingCartWillBeDisplayedWithProductInside()
        {
            Assert.True(ut.TextPresentInElement(productData.ProductName), "Ooops, expected result is not in the cart!");
           
            

        }

        

    }
}
