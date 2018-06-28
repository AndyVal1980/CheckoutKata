using CheckoutKata.Decorators;
using CheckoutKata.Items;

namespace CheckoutKata.Decorators
{
    public class BananaTwentyPenceDiscount : CheckoutItemDecorator
    {
        public BananaTwentyPenceDiscount(ICheckoutItem checkoutItem) : base(checkoutItem)
        {
            _cost = -0.2M;
        }
    }
}
