using System.Collections.Generic;
using CheckoutKata.Items;

namespace CheckoutKata.DiscountWorkflow
{
    public abstract class Handler

    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(List<ICheckoutItem> checkoutItems, ref decimal discountTotal);
    }
}
