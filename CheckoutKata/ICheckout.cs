using CheckoutKata.Items;

namespace CheckoutKata
{
    public interface ICheckout
    {
        void Scan(ICheckoutItem item);
        decimal Total();
    }
}
