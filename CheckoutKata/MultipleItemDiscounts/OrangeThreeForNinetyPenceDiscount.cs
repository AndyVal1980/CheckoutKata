using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using CheckoutKata.DiscountWorkflow;
using CheckoutKata.Items;

namespace CheckoutKata.MultipleItemDiscounts
{
    public class OrangeThreeForNinetyPenceDiscount : Handler
    {
        public override void HandleRequest(List<ICheckoutItem> checkoutItems, ref decimal discountTotal)
        {
            var count = checkoutItems.Count(x => x.GetName() == "Orange");
            for (var i = 1; i<= count; i++)
            {
                if(i % 3 == 0)
                    discountTotal = discountTotal + (checkoutItems.First(x => x.GetName() == "Orange").GetCost() * 3)-0.90M;
            }
            successor?.HandleRequest(checkoutItems, ref discountTotal);
        }
    }
}
