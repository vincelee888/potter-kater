using NUnit.Framework;

namespace potter.tests
{
    [TestFixture]
    class Tests
    {
        private PriceCalculator _sut;
        const decimal PricePerBook = 8;

        [SetUp]
        public void Setup()
        {
            _sut = new PriceCalculator(PricePerBook);
        }

        [Test]
        public void EmptyBasketEqualsZero()
        {
            Assert.That(_sut.GetPrice(new string[0]), Is.EqualTo(0));
        }

        [Test]
        public void ShouldReturnPriceOfSingleBook()
        {
            var total = _sut.GetPrice(new[] { "A" });
            Assert.That(total, Is.EqualTo(PricePerBook));
        }

        [Test]
        public void MultiplesOfTheSameBookReceiveNoDiscount()
        {
            var sut = new PriceCalculator(PricePerBook);
            var basket = new[] { "A", "A" };
            var total = sut.GetPrice(basket);
            Assert.That(total, Is.EqualTo(PricePerBook * basket.Length));
        }

        [Test]
        public void DiscountIsAppliedWhenMultipleDifferentBooks()
        {
            
        }
    }

    internal class PriceCalculator
    {
        private readonly decimal _pricePerBook;

        public PriceCalculator(decimal pricePerBook)
        {
            _pricePerBook = pricePerBook;
        }

        public decimal GetPrice(string[] basket)
        {
            return basket.Length * _pricePerBook;
        }
    }
}
