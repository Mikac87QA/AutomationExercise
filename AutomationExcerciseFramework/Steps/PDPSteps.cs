using AutomationExcerciseFramework.Helpers;
using AutomationExcerciseFramework.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationExcerciseFramework.Steps
{
    [Binding]
    public class PDPSteps : Base
    {
        Utilities ut = new Utilities(Driver);
        HeaderPage hp = new HeaderPage(Driver);

        private readonly ProductData productData;

        public PDPSteps(ProductData productData)
        {
            this.productData = productData;
        }

        [Given(@"user opens products page")]
        public void GivenUserOpensProductsPage()
        {
            ut.ClickOnElement(hp.productsLink);
        }
        
        [Given(@"searches for '(.*)'")]
        public void GivenSearchesFor(string winterTop)
        {
            ProductsPage pp = new ProductsPage(Driver);
            ut.EnterTextInElement(pp.searchProduct, TestConstants.WinterTop);
            ut.ClickOnElement(pp.searchButton);
        }
        
        [Given(@"opens first search result")]
        public void GivenOpensFirstSearchResult()
        {
            ProductsPage pp = new ProductsPage(Driver);
            ut.ClickOnElement(pp.viewProduct);
        }
        
        [When(@"user click on Add to Cart button")]
        public void WhenUserClickOnAddToCartButton()
        {
            ProductDetailPage pdp = new ProductDetailPage(Driver);
            productData.ProductName = ut.ReturnTextFromElement(pdp.productName);
            ut.ClickOnElement(pdp.addToCartBtn);
        }
        
        [When(@"proceeds to cart")]
        public void WhenProceedsToCart()
        {
            ProductDetailPage pdp = new ProductDetailPage(Driver);
            ut.ClickOnElement(pdp.ctnBtn);
        }
        
        [Then(@"shopping cart will be displayed with'(.*)' product inside")]
        public void ThenShoppingCartWillBeDisplayed(string wTopIcon)
        {
            ViewCartPage vcp = new ViewCartPage(Driver);
            Assert.True(ut.ElementIsDisplayed(vcp.wTopIcon), "There is no products inside cart");
        }
    }
}
