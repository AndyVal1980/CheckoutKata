using System.Collections.Generic;
using System.Linq;
using CheckoutKata.DiscountWorkflow;
using CheckoutKata.Items;

namespace CheckoutKata.MultipleItemDiscounts
{
    public class AppleTwoForOneDiscount : Handler
    {
        public override void HandleRequest(List<ICheckoutItem> checkoutItems, ref decimal discountTotal)
        {
            if (checkoutItems.Count(x => x.GetName() == "Apple") == 2)
            {
                discountTotal =  discountTotal + checkoutItems.First(x => x.GetName() == "Apple").GetCost();
                successor?.HandleRequest(checkoutItems, ref discountTotal);
            }
            else
            {
                successor?.HandleRequest(checkoutItems, ref discountTotal);
            }
        }
    }
}
