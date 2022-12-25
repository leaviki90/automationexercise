﻿using AutomationExerciseFramework.Helpers;
using AutomationExerciseFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AutomationExerciseFramework.Steps
{
    [Binding]
    public class ContactUsSteps : Base
    {
        Utilities ut = new Utilities(Driver);
        HeaderPage hp = new HeaderPage(Driver);

        [Given(@"user opens contact us page")]
        public void GivenUserOpensContactUsPage()
        {
            ut.ClickOnElement(hp.contactLink);
        }
        
        [When(@"user enters all required fields")]
        public void WhenUserEntersAllRequiredFields()
        {
            ContactUsPage cup = new ContactUsPage(Driver);
            ut.EnterTextInElement(cup.name, TestConstants.FirstName + " " + TestConstants.LastName);
            ut.EnterTextInElement(cup.email, TestConstants.Username);
            ut.EnterTextInElement(cup.subject, TestConstants.Subject);
            ut.EnterTextInElement(cup.message, TestConstants.Message);
            
        }
        
        [When(@"user submits contact us form")]
        public void WhenUserSubmitsContactUsForm()
        {
            ContactUsPage cup = new ContactUsPage(Driver);
            Driver.FindElement(cup.form).Submit();
        }
        
        [When(@"confirms the prompt message")]
        public void WhenConfirmsThePromptMessage()
        {
            IAlert alert = Driver.SwitchTo().Alert();  //prebacujemo fokus sa stranice na alert, pomocu driver-a
            alert.Accept();
        }
        
        [Then(@"user will receive ""(.*)"" message")]
        public void ThenUserWillReceiveMessage(string successMessage)
        {
            Assert.True(ut.TextPresentInElement(successMessage), "User's message was not sent successfully via contact form");
        }
    }
}
