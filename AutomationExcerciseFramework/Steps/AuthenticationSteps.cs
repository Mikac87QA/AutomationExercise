using AutomationExcerciseFramework.Helpers;
using AutomationExcerciseFramework.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationExcerciseFramework.Steps
{
    [Binding]
    public class AuthenticationSteps : Base
    {
        Utilities ut = new Utilities(Driver);
        HeaderPage hp = new HeaderPage(Driver);

        [Given(@"user opens sign in page")]
        public void GivenUserOpensSignInPage()
        {
            ut.ClickOnElement(hp.loginLink);
        }
        
        [Given(@"enters correct credentials")]
        public void GivenEntersCorrectCredentials()
        {
            AuthenticaionPage ap = new AuthenticaionPage(Driver);
            ut.EnterTextInElement(ap.loginEmail, TestConstants.Username);
            ut.EnterTextInElement(ap.loginPassword, TestConstants.Password);
        }
        
        [When(@"user subbmits login form")]
        public void WhenUserSubbmitsLoginForm()
        {
            AuthenticaionPage ap = new AuthenticaionPage(Driver);
            ut.ClickOnElement(ap.loginBtn);
        }
        
        [Then(@"user will be logged in")]
        public void ThenUserWillBeLoggedIn()
        {
            Assert.True(ut.ElementIsDisplayed(hp.deleteAcc), "User is NOT logged in");
        }

        [Given(@"enters '(.*)' name and valid email address")]
        public void GivenEntersNameAndValidEmailAddress(string name)
        {
            AuthenticaionPage ap = new AuthenticaionPage(Driver);
            ut.EnterTextInElement(ap.name, name);
            ut.EnterTextInElement(ap.signupEmail, ut.GenerateRandomEmail());
        }

        [Given(@"user clicks on SignUp button")]
        public void GivenUserClicksOnSignUpButton()
        {
            AuthenticaionPage ap = new AuthenticaionPage(Driver);
            ut.ClickOnElement(ap.signupBtn);
        }

        [StepDefinition(@"user fills in required fields")]
        public void WhenUserFillsInRequiredFields()
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
            ut.EnterTextInElement(sp.mobileNumber, TestConstants.Phone);
        }

        [StepDefinition(@"submits the signup form")]
        public void WhenSubmitsTheSignupForm()
        {
            SignupPage sp = new SignupPage(Driver);
            Driver.FindElement(sp.form).Submit();
            //ut.ClickOnElement(sp.createAcc);
        }

        [StepDefinition(@"user will get '(.*)' success mesage")]
        public void ThenUserWillGetSuccessMesage(string message)
        {
            AccountCreatedPage acp = new AccountCreatedPage(Driver);
            Assert.True(ut.TextPresentInElement(message), "User did NOT get expected success message");
            ut.ClickOnElement(acp.continueBtn);
        }

        [When(@"user clicks on Delete Account button")]
        public void WhenUserClicksOnDeleteAccountButton()
        {
            HeaderPage hp = new HeaderPage(Driver);
            ut.ClickOnElement(hp.deleteAcc);
        }

        [Then(@"user will get '(.*)' success message")]
        public void ThenUserWillGetSuccessMessage(string message)
        {
            AccountDeletedPage adp = new AccountDeletedPage(Driver);
            Assert.True(ut.TextPresentInElement(message), "User did NOT get succes message");
        }

    }
}
