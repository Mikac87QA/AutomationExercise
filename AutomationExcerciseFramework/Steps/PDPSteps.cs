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
        
        [StepDefinition(@"shopping cart will be displayed with'(.*)' product inside")]
        public void ThenShoppingCartWillBeDisplayed(string wTopIcon)
        {
            ViewCartPage vcp = new ViewCartPage(Driver);
            Assert.True(ut.ElementIsDisplayed(vcp.wTopIcon), "There is no products inside cart");
        }

        [When(@"user clicks on Procced to checkout button")]
        public void WhenUserClicksOnProccedToCheckoutButton()
        {
            ViewCartPage vcp = new ViewCartPage(Driver);
            ut.ClickOnElement(vcp.proceedToCheckBtn);
        }

        [When(@"enters his comment in window")]
        public void WhenEntersHisCommentInWindow()
        {
            CheckoutPage chp = new CheckoutPage(Driver);
            ut.EnterTextInElement(chp.messBox, TestConstants.checkComment);
            productData.ChkMessage = ut.ReturnTextFromElement(chp.messBox);
        }

        [When(@"clicks on Place Order button")]
        public void WhenClicksOnPlaceOrderButton()
        {
            CheckoutPage chp = new CheckoutPage(Driver);
            ut.ClickOnElement(chp.placeOrderBtn);
        }

        [When(@"enters all required fields")]
        public void WhenEntersAllRequiredFields()
        {
            PaymentPage pp = new PaymentPage(Driver);
            ut.EnterTextInElement(pp.nameOnCard, TestConstants.FullName);
            ut.EnterTextInElement(pp.cardNumber, TestConstants.CardNumber);
            ut.EnterTextInElement(pp.cvcNumber, TestConstants.CVC);
            ut.EnterTextInElement(pp.expMonth, TestConstants.ExpM);
            ut.EnterTextInElement(pp.expYear, TestConstants.ExpY);
        }

        [When(@"clicks on Pay and Confirm button")]
        public void WhenClicksOnPayAndConfirmButton()
        {
            PaymentPage pp = new PaymentPage(Driver);
            ut.ClickOnElement(pp.payConfBtn);
        }

        [Then(@"user will get '(.*)' message")]
        public void ThenUserWillGetMessage()
        {
            Assert.True(ut.TextPresentInElement(productData.ChkMessage), "Order with comment:" + productData.ChkMessage + "was NOT placed successfully");
        }

        [When(@"enters name and email adress")]
        public void WhenEntersNameAndEmailAdress()
        {
            ProductDetailPage pdp = new ProductDetailPage(Driver);
            ut.EnterTextInElement(pdp.reviewName, TestConstants.FirstName);
            ut.EnterTextInElement(pdp.reviewMail, TestConstants.Username);
        }

        [When(@"writes review")]
        public void WhenWritesReview()
        {
            ProductDetailPage pdp = new ProductDetailPage(Driver);
            ut.EnterTextInElement(pdp.reviewComm, TestConstants.checkComment);
        }

        [When(@"clicks on Submit button")]
        public void WhenClicksOnSubmitButton()
        {
            ProductDetailPage pdp = new ProductDetailPage(Driver);
            ut.ClickOnElement(pdp.submitBtn);
        }

        [Then(@"he gets Thank you for your review message")]
        public void ThenHeGetsMessage()
        {
            ProductDetailPage pdp = new ProductDetailPage(Driver);
            Assert.True(ut.ElementIsDisplayed(pdp.confirmMessage), "Your review was NOT sent successfully");
        }

    }
}
