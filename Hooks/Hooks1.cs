using Gherkin.Ast;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace aheadrace.Hooks
{
    [Binding]
    public class Hooks1
    {
      //  private IWebDriver Driver;
        private DriverHelper _driverHelper;
      

        public Hooks1(DriverHelper driverHelper)
        {
            this._driverHelper = driverHelper;

        }

        [BeforeScenario]
        public void BeforeScenario()
        {

            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-maximized");
            option.AddArguments("--disable-gpu");
                      
            _driverHelper.Driver = new ChromeDriver(option);
     
           _driverHelper.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(30000);
      
        }



        [AfterScenario]
        public void AfterScenario()
        {
            _driverHelper.Driver.Quit();
        }
     


    }
}
