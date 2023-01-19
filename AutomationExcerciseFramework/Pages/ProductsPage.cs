using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExcerciseFramework.Pages
{
    class ProductsPage
    {
        readonly IWebDriver _driver;
        public By searchProduct = By.Id("search_product");
        public By searchButton = By.ClassName("fa-search");
        public By viewProduct = By.ClassName("choose");

        public ProductsPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(searchProduct));
        }
        
    }
}
