using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace aheadrace.Pages
{
    public class RequestNewPassword
    {
       
        private DriverHelper _driverHelper;

        public RequestNewPassword(DriverHelper driverHelper)
        {
            this._driverHelper = driverHelper;

        }


        public IWebElement txtUserNameorEmail => _driverHelper.Driver.FindElement(By.Id("edit-name"));

        IWebElement btnEmailNewPass => _driverHelper.Driver.FindElement(By.Id("edit-submit"));

        public void EmailNewPassword()
        {
            btnEmailNewPass.Click();
        }

        public void EnterUsername(string userName)
        {

            txtUserNameorEmail.SendKeys(userName);

        }
    }
}
