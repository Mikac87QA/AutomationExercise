using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExcerciseFramework.Pages
{
    class AccountDeletedPage
    {
        readonly IWebDriver _driver;
        public By delPage = By.CssSelector(".container [data-qa='account-deleted']");

        public AccountDeletedPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(delPage));
        }
    }
}
