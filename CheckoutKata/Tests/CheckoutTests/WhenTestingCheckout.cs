using System.Collections.Generic;

namespace CheckoutKata.Tests.CheckoutTests
{
    public class WhenTestingCheckout
    {
        protected Checkout CheckoutCounter; 
        public void SetUp()
        {
            CheckoutCounter = new Checkout();
        }
    }
}
