using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace aheadrace.Pages
{
    public class AmazonPage
    {

        private DriverHelper _driverHelper;
        CustomControl customcontrol;

        public AmazonPage(DriverHelper driverHelper)
        {
            this._driverHelper = driverHelper;
            customcontrol = new CustomControl(driverHelper);

        }

        IWebElement hoveronSignIn => _driverHelper.Driver.FindElement(By.XPath("//a[@id='nav-link-accountList']"));

        IWebElement SignInbtn => _driverHelper.Driver.FindElement(By.ClassName("nav-action-signin-button"));

       IWebElement txtEmail=> _driverHelper.Driver.FindElement(By.Id("ap_email"));

        IWebElement btnContinue => _driverHelper.Driver.FindElement(By.Id("continue"));

        IWebElement txtpassword => _driverHelper.Driver.FindElement(By.Id("ap_password"));

        IWebElement btnsignIn => _driverHelper.Driver.FindElement(By.Id("signInSubmit"));

        // IWebElement loggedInElement => _driverHelper.Driver.FindElement(By.Id("nav-link-accountList"));

     
         bool  loginsuccess =>  _driverHelper.Driver.FindElement(By.Id("nav-item-signout")).Displayed;
       
      

        public void EnterUserNmPwd(String Email , String Password)
        {
            customcontrol.MovetoElement(hoveronSignIn);
          //  customcontrol.MovetoElement(loggedInElement);
            SignInbtn.Click();
            txtEmail.SendKeys(Email);
            btnContinue.Click();
            txtpassword.SendKeys(Password);
          //  btnsignIn.Click();

        }

     


    }
}
