using AutomationExerciseFramework.Helpers;
using AutomationExerciseFramework.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationExerciseFramework.Steps
{
    [Binding]
    public class CheckoutSteps : Base
    {
        Utilities ut = new Utilities(Driver);

        private readonly CheckoutData checkoutData;

        public CheckoutSteps(CheckoutData checkoutData)   //da bi promenljiva bila dostupna na celoj ovoj strani (globalna)
        {
            this.checkoutData = checkoutData;  // na jednoj strani samo jedan constructor moze
        }

        [When(@"user clicks on Proceed to checkout button")]
        public void WhenUserClicksOnProceedToCheckoutButton()
        {
            CartPage cp = new CartPage(Driver);
            ut.ClickOnElement(cp.proceedBtn);
        }
        
        [When(@"enters some comment")]
        public void WhenEntersSomeComment()
        {
            CheckoutPage cp = new CheckoutPage(Driver);
            ut.EnterTextInElement(cp.messageArea, TestConstants.Comment);
            


        }
        
        [When(@"clicks on Place order button")]
        public void WhenClicksOnPlaceOrderButton()
        {
            CheckoutPage cp = new CheckoutPage(Driver);
            checkoutData.CheckoutComment = ut.ReturnTextFromElement(cp.messageArea);
            Console.WriteLine(checkoutData.CheckoutComment);
            ut.ClickOnElement(cp.placeOrderBtn);
            
        }
        
        [When(@"fills all required fields")]
        public void WhenFillsAllRequiredFields()
        {
            PaymentPage pp = new PaymentPage(Driver);
            ut.EnterTextInElement(pp.cardName, TestConstants.FirstName);
            ut.EnterTextInElement(pp.cardNumber, TestConstants.CardNumber);
            ut.EnterTextInElement(pp.cVC, TestConstants.CvcNumber);
            ut.EnterTextInElement(pp.expirationMonth, TestConstants.ExpMonth);
            ut.EnterTextInElement(pp.expirationYear, TestConstants.ExpYear);
            Driver.FindElement(pp.paymentForm).Submit();
        }
        

        [Then(@"user receives message ""(.*)""")]
        public void ThenUserReceivesMessage(string successMessage)
        {
            PaymentCompletePage pcp = new PaymentCompletePage(Driver);
            Assert.True(ut.TextPresentInElement(successMessage), "Order with comment: " + checkoutData.CheckoutComment + " was not placed successfully");
            Console.WriteLine(checkoutData.CheckoutComment);
            Console.WriteLine("Order with comment: " + checkoutData.CheckoutComment + " was not placed successfully");

            
        }

    }
}
