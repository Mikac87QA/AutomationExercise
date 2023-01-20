using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExcerciseFramework.Pages
{
    class PaymentPage
    {
        readonly IWebDriver _driver;
        public By paymentPage = By.CssSelector(".container [class='active']");
        public By nameOnCard = By.CssSelector(".payment-information [name='name_on_card']");
        public By cardNumber = By.CssSelector(".payment-information [name='card_number']");
        public By cvcNumber = By.CssSelector(".payment-information [name='cvc']");
        public By expMonth = By.CssSelector(".payment-information [name='expiry_month']");
        public By expYear = By.CssSelector(".payment-information [name='expiry_year']");
        public By payConfBtn = By.CssSelector(".payment-information [data-qa='pay-button']");

        public PaymentPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(paymentPage));
        }
    }
}
