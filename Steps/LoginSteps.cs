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
    public  class LoginSteps
    {
        private IWebDriver Driver;
        LoginPage loginpage;
        RequestNewPassword reqnewpass;
        UsersPage userspage;
        private DriverHelper _driverHelper;
        CustomControl customcontrol;

        public LoginSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            customcontrol = new CustomControl(driverHelper);
            loginpage = new LoginPage(driverHelper);
            reqnewpass = new RequestNewPassword(driverHelper);
            userspage = new UsersPage(driverHelper);

        }


        [Given(@"I navigate to application\.")]
        public void GivenINavigateToApplication_()
        {
            // _driverHelper.Driver.Navigate().GoToUrl("https://ondemand.questionmark.com/home/406121");

            _driverHelper.Driver.Navigate().GoToUrl("https://www.amazon.in/?&tag=googhydrabk1-21&ref=pd_sl_7hz2t19t5c_e&adgrpid=155259815513&hvpone=&hvptwo=&hvadid=674842289437&hvpos=&hvnetw=g&hvrand=18127812681853341210&hvqmt=e&hvdev=c&hvdvcmdl=&hvlocint=&hvlocphy=9062140&hvtargid=kwd-10573980&hydadcr=14453_2316415&gad_source=1");
            customcontrol.Maximize();
            customcontrol.WaitForPageLoad(5000);
        }

        [When(@"I enter username and password\.")]
        public void WhenIEnterUsernameAndPassword_(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            loginpage.EnterUsernameAndPassword(data.UserName, data.Password);
        }

        [When(@"I click on Login\.")]
        public void WhenIClickOnLogin_()
        {
            loginpage.ClickLogin();
        }

        [Then(@"verify the failure message 'Sorry, unrecognized username or password.' is displayed.")]
        public void ThenVerifyTheFailureMessageIsDisplayed_()
        {
            Assert.IsTrue(loginpage.txtverifcation.Displayed);
        }

        [When(@"Navigate to Request new password page\.")]
        public void WhenNavigateToRequestNewPasswordPage_()
        {
            loginpage.RequestNewPassword();
        }

        [Then(@"Verify user able to navigated to Request new passord page\.")]
        public void ThenVerifyUserAbleToNavigatedToRequestNewPassordPage_()
        {
            Assert.IsTrue(reqnewpass.txtUserNameorEmail.Displayed);
        }


        [When(@"Enter email address ""(.*)"" and click Email new password\.")]
        public void WhenEnterEmailAddressAndClickEmailNewPassword_(string email)
        {
            reqnewpass.EnterUsername(email);
            reqnewpass.EmailNewPassword();            
        }


        [When(@"I enter with correct credentials\.")]
        public void WhenIEnterWithCorrectCredentials_(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

           loginpage.EnterUsernameAndPassword(data.UserName, data.Password);
            loginpage.ClickLogin();
            Thread.Sleep(5000);

        }

        [When(@"Navigate to ""(.*)"" and select ""(.*)"" option\.")]
        public void WhenNavigateToAndSelectOption_(string MenuField, string subcategory)
        {
           // _driverHelper.Driver.FindElement(By.Id("edcc5a0e-1e2b-2743-cf81-84d784ffa49d")).Click();
            loginpage.Menubar_People(MenuField ,subcategory);
        }

        [Then(@"Verify user able to navigate Users ""(.*)"" page\.")]
        public void ThenVerifyUserAbleToNavigateUsersPage_(string option)
        {
            Assert.IsTrue(userspage.UserPageOption(option).Displayed);
        }
        

        [When(@"I click on ""(.*)""\.")]
        public void WhenIClickOn_(string ImportParticipants)
        {
            userspage.UserPageOption(ImportParticipants).Click();
        }

        [Then(@"verify user is in Import Participants page by a Field on the page ""(.*)""\.")]
        public void ThenVerifyUserIsInImportParticipantsPageByAElementOnThePage_(string Element)
        {
            Assert.IsTrue(userspage.UserPageOption(Element).Displayed);
        }


        [When(@"I click on Browse option and upload the file\.")]
        public void WhenIClickOnBrowseOptionAndUploadTheFile_()
        {
            userspage.ClickBrowseandUploadFile();
        }

        [When(@"I click on ""(.*)"" option\.")]
        public void WhenIClickOnOption(string Element)
        {
            userspage.UserPageOption(Element).Click();
        }

        [Then(@"verify with the ""(.*)"" message in the page\.")]
        public void ThenVerifyWithTheMessageInThePage_(string status)
        {
            Assert.IsTrue(userspage.status.Displayed, status);
        }
    }
}
