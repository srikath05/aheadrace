using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace aheadrace.Pages
{
   public class UsersPage
    {
        private IWebDriver Driver;
        private DriverHelper _driverHelper;
        CustomControl cc;
       // private string text;

        public UsersPage(DriverHelper driverHelper)
        {
            this._driverHelper = driverHelper;
            cc = new CustomControl(driverHelper);

        }


       public IWebElement UserPageOption(string options) =>
                    _driverHelper.Driver.FindElement(By.XPath($"//*[text()=\"{options}\"]"));

        public IWebElement status => _driverHelper.Driver.FindElement(By.XPath("//h4[text() ='Status message']"));


        public IWebElement btnBrowse => _driverHelper.Driver.FindElement(By.XPath("//*[text()='Browse...']"));
        public void ClickBrowseandUploadFile()
        {
          // string filepath = "C:/User/ganji/Downloads/Participants.csv";
            IWebElement UploadFile = _driverHelper.Driver.FindElement(By.XPath("//*[text()='Browse...']"));
            UploadFile.Click();
            Thread.Sleep(3000);
            //SendKeys.SendWait(text);
            SendKeys.SendWait("C:\\Users\\ganji\\Downloads\\Participants.csv");                    
            SendKeys.SendWait("{ENTER}");

        }

             


    }
}
