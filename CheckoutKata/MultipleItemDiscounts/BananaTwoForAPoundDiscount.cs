using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using CheckoutKata.DiscountWorkflow;
using CheckoutKata.Items;

namespace CheckoutKata.MultipleItemDiscounts
{
    public class BananaTwoForAPoundDiscount : Handler
    {
        public override void HandleRequest(List<ICheckoutItem> checkoutItems, ref decimal discountTotal)
        {
            var count = checkoutItems.Count(x => x.GetName() == "Banana");
            for (var i = 1; i<= count; i++)
            {
                if(i % 2 == 0)
                    discountTotal = discountTotal + (checkoutItems.First(x => x.GetName() == "Banana").GetCost() * 2)-1;
            }
            successor?.HandleRequest(checkoutItems, ref discountTotal);
        }
    }
}
