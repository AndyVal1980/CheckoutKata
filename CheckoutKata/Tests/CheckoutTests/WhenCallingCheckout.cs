using System.Collections.Generic;
using CheckoutKata.Builders;
using CheckoutKata.Decorators;
using CheckoutKata.Exceptions;
using CheckoutKata.Items;
using NUnit.Framework;

namespace CheckoutKata.Tests.CheckoutTests
{
    public class WhenCallingCheckout : WhenTestingCheckout
    {
        [SetUp]
        public void When()
        {
            SetUp();
        }

        [Test]
        public void ItShouldReturnCorrectTotalForItemScannedItem()
        {
            var banana = new Banana();
            CheckoutCounter.Scan(banana);
            Assert.That(CheckoutCounter.Total(), Is.EqualTo(banana.GetCost()));
        }

        [Test]
        public void ItShouldThrowItemNotFoundExceptionIfScanningEmpty()
        {
            Assert.Throws<ItemNotFoundException>(() => CheckoutCounter.Scan(null));
        }

        [Test]
        public void ItShouldReturnCorrectPriceIf2OfTheSameItemIsScanned()
        {
            var orange = new Orange();
            CheckoutCounter.Scan(orange);
            CheckoutCounter.Scan(orange);
            Assert.That(CheckoutCounter.Total(), Is.EqualTo(orange.GetCost() * 2));
        }

        [Test]
        public void ItShouldReturnCorrectPriceFor2DifferentItemsAreScanned()
        {
            var apple = new Apple();
            var orange = new Orange();
            CheckoutCounter.Scan(apple);
            CheckoutCounter.Scan(orange);
            Assert.That(CheckoutCounter.Total(), Is.EqualTo(apple.GetCost() + orange.GetCost()));
        }

        [Test]
        public void ItShouldReturnCorrectTotalForTwentyPercentDiscount()
        {
            var banana = BananaTwentyPenceDiscountBuilder.Build.AnInstance();
            CheckoutCounter.Scan(banana);
            Assert.That(CheckoutCounter.Total(), Is.EqualTo(0.5M));
        }

        [Test]
        public void ItShouldReturnTheCorrectTotalForAppleTwoForOneDiscount()
        {
            var apple = new Apple();
            CheckoutCounter.Scan(apple);
            CheckoutCounter.Scan(apple);
            Assert.That(CheckoutCounter.Total(), Is.EqualTo(apple.GetCost()));
        }

        [Test]
        public void ItShouldReturnTheCorrectTotalForBananaTwoForAPoundDiscountWhenInDifferentOrder()
        {
            var banana = new Banana();
            var orange = new Orange();
            var apple = new Apple();
            CheckoutCounter.Scan(banana);
            CheckoutCounter.Scan(orange);
            CheckoutCounter.Scan(banana);
            CheckoutCounter.Scan(apple);
            Assert.That(CheckoutCounter.Total(), Is.EqualTo(1.00M + orange.GetCost() + apple.GetCost()));
        }

        [Test]
        public void ItShouldReturnTheCorrectTotalForTwoForAPoundDiscount()
        {
            var banana = new Banana();
            CheckoutCounter.Scan(banana);
            CheckoutCounter.Scan(banana);
            Assert.That(CheckoutCounter.Total(), Is.EqualTo(1.0M));
        }

        [Test]
        public void ItShouldReturnTheCorrectCostOfTwoOranges()
        {
            var orange = new Orange();
            CheckoutCounter.Scan(orange);
            CheckoutCounter.Scan(orange);
            Assert.That(CheckoutCounter.Total(), Is.EqualTo(orange.GetCost()*2));
        }

        [Test]
        public void ItShouldReturnTheCorrectDiscountOfThreeOrangesForNinetyPence()
        {
            var orange = new Orange();
            CheckoutCounter.Scan(orange);
            CheckoutCounter.Scan(orange);
            CheckoutCounter.Scan(orange);
            Assert.That(CheckoutCounter.Total(), Is.EqualTo(0.9M));
        }

        [Test]
        public void ItShouldReturnTheCorrectDiscountOfThreeOrangesForNinetyPenceWhenNotInOrder()
        {
            var orange = new Orange();
            var apple = new Apple();
            CheckoutCounter.Scan(orange);
            CheckoutCounter.Scan(apple);
            CheckoutCounter.Scan(orange);
            CheckoutCounter.Scan(apple);
            CheckoutCounter.Scan(apple);
            CheckoutCounter.Scan(orange);
            Assert.That(CheckoutCounter.Total(), Is.EqualTo(0.9M + apple.GetCost()*3));
        }
    }
}
