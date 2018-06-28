using CheckoutKata.Decorators;
using CheckoutKata.Items;

namespace CheckoutKata.Builders
{
    public class BananaTwentyPenceDiscountBuilder : Builder<BananaTwentyPenceDiscountBuilder, BananaTwentyPenceDiscount>
    {
        public override BananaTwentyPenceDiscount AnInstance()
        {
            return new BananaTwentyPenceDiscount(new Banana());
        }
    }
}
