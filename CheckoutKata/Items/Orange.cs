namespace CheckoutKata.Items
{
    public class Orange : ICheckoutItem
    {
        public string GetName()
        {
            return "Orange";
        }

        public decimal GetCost()
        {
            return 0.45M;
        }
    }
}
