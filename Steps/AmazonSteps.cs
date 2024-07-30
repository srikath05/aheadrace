using aheadrace.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace aheadrace.Steps
{
    [Binding]
    public class AmazonSteps
    {
        private IWebDriver Driver;
        LoginPage loginpage;
        RequestNewPassword reqnewpass;
        UsersPage userspage;
        private DriverHelper _driverHelper;
        CustomControl customcontrol;
        AmazonPage AmpPage;

        public AmazonSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            customcontrol = new CustomControl(driverHelper);
            loginpage = new LoginPage(driverHelper);
            reqnewpass = new RequestNewPassword(driverHelper);
            userspage = new UsersPage(driverHelper);
            AmpPage = new AmazonPage(driverHelper);

        }


        [Given(@"I navigate to the Amazon website")]
        public void GivenINavigateToTheAmazonWebsite()
        {
            //_driverHelper.Driver.Navigate().GoToUrl("https://www.amazon.com/ap/signin?openid.pape.max_auth_age=0&openid.return_to=https%3A%2F%2Fwww.amazon.com%2F%3Fref_%3Dnav_custrec_signin&openid.identity=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.assoc_handle=usflex&openid.mode=checkid_setup&openid.claimed_id=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.ns=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0");

            // _driverHelper.Driver.Navigate().GoToUrl("https://www.amazon.com/");


            _driverHelper.Driver.Navigate().GoToUrl("https://www.amazon.com/");
            customcontrol.Maximize();
            _driverHelper.Driver.Navigate().GoToUrl("https://www.amazon.com/");
            customcontrol.WaitForPageLoad(6000);
        }

        [When(@"I enter username ""(.*)"" and password ""(.*)""")]
        public void WhenIEnterUsernameAndPassword(string username, string password)
        {
            // Find username and password fields and enter credentials
            // var usernameField = _driverHelper.Driver.FindElement(By.Id("ap_email"));
            // usernameField.SendKeys(username);

            //  var passwordField = _driverHelper.Driver.FindElement(By.Id("ap_password"));
            // usernameField.SendKeys(password);
            AmpPage.EnterUserNmPwd(username, password);


        }

               

        [Then(@"I should be logged into my Amazon account")]
        public void ThenIShouldBeLoggedIntoMyAmazonAccount()
        {
            // Validate that the login was successful
            var loggedInElement = customcontrol.MovetoElement(_driverHelper.Driver.FindElement(By.Id("nav-link-accountList")));
            
            bool isLoggedIn = _driverHelper.Driver.FindElement(By.Id("nav-item-signout")).Displayed;
            
            // Optionally, add assertions or verification steps
            Assert.IsTrue(isLoggedIn, "Login was not successful");

            // Clean up
            _driverHelper.Driver.Quit();

        }
        [When(@"I click on the login button")]
        public void WhenIClickOnTheLoginButton()
        {
            // Find and click the login button
            var loginButton = _driverHelper.Driver.FindElement(By.Id("signInSubmit"));
            loginButton.Click();
        }
    }
}
