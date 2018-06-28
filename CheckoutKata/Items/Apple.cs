namespace CheckoutKata.Items
{
    public class Apple : ICheckoutItem
    {
        public string GetName()
        {
            return "Apple";
        }

        public decimal GetCost()
        {
            return 0.5M;
        }
    }
}
