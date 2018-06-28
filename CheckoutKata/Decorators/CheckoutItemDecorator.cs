using CheckoutKata.Items;

namespace CheckoutKata.Decorators
{
    public abstract class CheckoutItemDecorator : ICheckoutItem
    {
        private readonly ICheckoutItem _checkoutItem;

        protected decimal _cost = 0.00M;

        public CheckoutItemDecorator(ICheckoutItem checkoutItem)
        {
            _checkoutItem = checkoutItem;
        }

        public string GetName()
        {
            return _checkoutItem.GetName();
        }

        public decimal GetCost()
        {
            return _checkoutItem.GetCost() + _cost;
        }
    }
}
