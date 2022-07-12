using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace aheadrace
{
    public class CustomControl
    {
        private IWebDriver Driver;
        private DriverHelper _driverHelper;
        private IWebElement element;


        public CustomControl(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }


        public void WaitForPageLoad(int timeoutMsec)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(timeoutMsec));
                wait.Until((driver) =>
                {
                    return ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");
                });

            }
            catch (Exception)
            {
                //wait some time if an unexpected exception is thrown
                Thread.Sleep(500);
            }
        }

        public void Maximize()
        {
            _driverHelper.Driver.Manage().Window.Maximize();
        }

        public void Minimize()
        {
            _driverHelper.Driver.Manage().Window.Minimize();
        }


        public void SwitchToFrame(By locator, int timeoutMsec)
        {
            var wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromMilliseconds(timeoutMsec));
            wait.Until(EC.FrameToBeAvailableAndSwitchToIt(locator));

        }

        public bool IsDisplayed
        {
            get
            {
                try
                {

                    return element.Displayed;

                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public void SwitchToWindow(string currentWindow)
        {
            _driverHelper.Driver.SwitchTo().Window(currentWindow);
           _driverHelper.Driver.SwitchTo().Window(_driverHelper.Driver.WindowHandles[_driverHelper.Driver.WindowHandles.Count - 1]);
               
        }
        public bool SelectByText(IWebElement element, string Selected_value)
        {

            bool status;
            try
            {
                SelectElement sc = new SelectElement(element);
                sc.SelectByText(Selected_value);

                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;

        }



    }


        }

   