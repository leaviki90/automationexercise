using AutomationExerciseFramework.Helpers;
using AutomationExerciseFramework.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationExerciseFramework.Steps
{
    [Binding]
    public class AuthenticationSteps : Base
    {
        Utilities ut = new Utilities(Driver); //da bi smo mogli da pozovemo metode koje smo napravili u utilities, 
            //pravimo objekat ut
        HeaderPage hp = new HeaderPage(Driver);


        [Given(@"user opens sign in page")]
        public void GivenUserOpensSignInPage()
        {
            ut.ClickOnElement(hp.loginLink);
        }
        
        [Given(@"enters correct credentials")]
        public void GivenEntersCorrectCredentials()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.loginEmail, TestConstants.Username);
            ut.EnterTextInElement(ap.loginPassword, TestConstants.Password);
        }
        
        [When(@"user submits the form")]
        public void WhenUserSubmitsTheForm()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.ClickOnElement(ap.loginBtn);
        }
        
        [Then(@"user will be logged in")]
        public void ThenUserWillBeLoggedIn()
        {
            Assert.True(ut.ElementIsDisplayed(hp.deleteAcc), "User is NOT logged in");
        }

        [Given(@"enters ""(.*)"" name and valid email address")]
        public void GivenEntersNameAndValidEmailAddress(string name)
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.name, name);
            ut.EnterTextInElement(ap.signupEmail, ut.GenerateRandomEmail());
        }

        [Given(@"user clicks on SignUp button")]
        public void GivenUserClicksOnSignUpButton()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.ClickOnElement(ap.signupBtn);
        }

        [StepDefinition(@"user fills in all required fields")]
        public void WhenUserFillsInAllRequiredFields()
        {
            SignupPage sp = new SignupPage(Driver);
            ut.EnterTextInElement(sp.password, TestConstants.Password);
            ut.EnterTextInElement(sp.firstName, TestConstants.FirstName);
            ut.EnterTextInElement(sp.lastName, TestConstants.LastName);
            ut.EnterTextInElement(sp.address, TestConstants.Address);
            ut.DropdownSelect(sp.country, TestConstants.Country);
            ut.EnterTextInElement(sp.state, TestConstants.State);
            ut.EnterTextInElement(sp.city, TestConstants.City);
            ut.EnterTextInElement(sp.zipcode, TestConstants.ZipCode);
            ut.EnterTextInElement(sp.mobile, TestConstants.Phone);
        }

        [StepDefinition(@"submits the signUp form")]
        public void WhenSubmitsTheSignUpForm()
        {
            SignupPage sp = new SignupPage(Driver);
            Driver.FindElement(sp.form).Submit();
            //ut.ClickOnElement(sp.createAcc);
           
        }

        [Then(@"user will get ""(.*)"" success message")]
        public void ThenUserWillGetSuccessMessage(string message)

        {
            AccountCreatedPage acp = new AccountCreatedPage(Driver);
            Assert.True(ut.TextPresentInElement(message), "User did NOT get expected success message"); //provera
            ut.ClickOnElement(acp.countinueBtn);
        }

        [Given(@"user can register account with ""(.*)"" name")]
        public void GivenUserCanRegisterAccountWithName(string name)
        {
    
            GivenUserOpensSignInPage();
            GivenEntersNameAndValidEmailAddress(name);
            GivenUserClicksOnSignUpButton();
            WhenUserFillsInAllRequiredFields();
            WhenUserSubmitsTheForm();
            AccountCreatedPage acp = new AccountCreatedPage(Driver);
            ut.ClickOnElement(acp.countinueBtn);
        }

        [When(@"user selects option for deleting the account")]
        public void WhenUserSelectsOptionForDeletingTheAccount()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
