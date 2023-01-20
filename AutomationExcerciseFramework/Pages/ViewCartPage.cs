using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExcerciseFramework.Pages
{
    class ViewCartPage
    {
        readonly IWebDriver _driver;
        public By wTopIcon = By.CssSelector(".cart_product [class='product_image']");
        public By proceedToCheckBtn = By.XPath("//*[@id='cart_items']//*[@class='btn btn-default check_out']");


        public ViewCartPage (IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(wTopIcon));
        }
    }
}
