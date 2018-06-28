using System.Collections.Generic;
using System.Linq;
using CheckoutKata.Exceptions;
using CheckoutKata.Items;
using CheckoutKata.MultipleItemDiscounts;

namespace CheckoutKata
{
    public class Checkout
    {
        private readonly List<ICheckoutItem> _scannedItems = new List<ICheckoutItem>();
        public void Scan(ICheckoutItem item)
        {
            if(item == null)
                throw new ItemNotFoundException();

            AddItem(item);
        }

        public decimal Total()
        {
            decimal discountTotal = CalculateDiscount();
            return _scannedItems.Sum(item => item.GetCost()) - discountTotal;
        }

        private decimal CalculateDiscount()
        {
            var bananaDiscount = new BananaTwoForAPoundDiscount();
            var appleDiscount = new AppleTwoForOneDiscount();
            var orangeDiscount = new OrangeThreeForNinetyPenceDiscount();
            var discountTotal = 0.00M;
            bananaDiscount.SetSuccessor(appleDiscount);
            appleDiscount.SetSuccessor(orangeDiscount);
            bananaDiscount.HandleRequest(_scannedItems, ref discountTotal);
            return discountTotal;
        }

        private void AddItem(ICheckoutItem item)
        {
            _scannedItems.Add(item);
        }
    }
}
