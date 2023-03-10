using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExcerciseFramework.Pages
{
    class ProductDetailPage
    {
        readonly IWebDriver _driver;
        public By addToCartBtn = By.CssSelector(".product-details [type='button']");
        public By ctnBtn = By.CssSelector(".modal-body [href='/view_cart']");
        public By productName = By.XPath("//*[@class='product-information']//h2");
        public By reviewName = By.CssSelector(".tab-content [id='name']");
        public By reviewMail = By.CssSelector(".tab-content [id='email']");
        public By reviewComm = By.CssSelector(".tab-content [id='review']");
        public By submitBtn = By.CssSelector(".tab-content [id='button-review']");
        public By confirmMessage = By.XPath("//*[@class='form-row']//span");

        public ProductDetailPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(addToCartBtn));
        }
    }
}
