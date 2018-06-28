namespace CheckoutKata.Items
{
    public class Banana : ICheckoutItem
    {
        public string GetName()
        {
            return "Banana";
        }

        public decimal GetCost()
        {
            return 0.7M;
        }
    }
}
