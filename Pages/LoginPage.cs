using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace aheadrace.Pages
{
    class LoginPage
    {

        private DriverHelper _driverHelper;
        CustomControl customcontrol;

        public LoginPage(DriverHelper driverHelper)
        {
            this._driverHelper = driverHelper;
            customcontrol = new CustomControl(driverHelper);
            
        }

        IWebElement txtUserName => _driverHelper.Driver.FindElement(By.Id("edit-name"));
        IWebElement txtPassword => _driverHelper.Driver.FindElement(By.Id("edit-pass"));
        IWebElement btnLogin => _driverHelper.Driver.FindElement(By.Id("edit-submit"));
        public IWebElement txtverifcation => _driverHelper.Driver.FindElement(By.XPath("//div[@class='alert alert-block alert-danger']"));
        public IWebElement ReqNewPass => _driverHelper.Driver.FindElement(By.XPath("//a[text()='Request new password']"));

        public IWebElement MenuBar_People(string fieldname)=>        
            _driverHelper.Driver.FindElement(By.XPath($"//a[text()=\"{fieldname }\"]"));
        
        public IWebElement People_subCategory(string Category) => 
            _driverHelper.Driver.FindElement(By.XPath($"//a[text()=\"{Category}\"]"));

        public void EnterUsernameAndPassword(string userName, string password)
        {
           
            txtUserName.SendKeys(userName);

            txtPassword.SendKeys(password);
        }

        public void ClickLogin()
        {
            btnLogin.Click();
        }

        public void RequestNewPassword()
        {
            ReqNewPass.Click();
        }

        public void Menubar_People(string field,string category)
        {
            
            MenuBar_People(field).Click();
            People_subCategory(category).Click();

        }


    }
}

