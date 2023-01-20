using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExcerciseFramework.Pages
{
    class CheckoutPage
    {
        readonly IWebDriver _driver;
        public By checkoutPage = By.ClassName("checkout-information");
        public By messBox = By.CssSelector(".form-group [name='message']");
        public By placeOrderBtn = By.CssSelector(".container [href='/payment']");

        public CheckoutPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(checkoutPage));
        }
        

    }
}
