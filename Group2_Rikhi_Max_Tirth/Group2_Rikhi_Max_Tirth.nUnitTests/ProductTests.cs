using ECommerceApp;
using NUnit.Framework;
using System;

namespace Group2_Rikhi_Max_Tirth_Tests
{
    public class ProductTests
    {
        private Product _product;

        [SetUp]
        public void Setup()
        {
            _product = new Product(100, "Laptop", 1000m, 10);
        }

        // ------------------------
        // Testing Product Attributes (6 tests)
        // ------------------------

        [Test]
        public void Product_ValidProdID_ShouldBeSetCorrectly()
        {
            Assert.That(_product.ProdID, Is.EqualTo(100));
        }

        [Test]
        public void Product_ValidProdName_ShouldBeSetCorrectly()
        {
            Assert.That(_product.ProdName, Is.EqualTo("Laptop"));
        }

        [Test]
        public void Product_ValidItemPrice_ShouldBeSetCorrectly()
        {
            Assert.That(_product.ItemPrice, Is.EqualTo(1000m));
        }

        [Test]
        public void Product_ValidStockAmount_ShouldBeSetCorrectly()
        {
            Assert.That(_product.StockAmount, Is.EqualTo(10));
        }

        [Test]
        public void Product_NegativeStockAmount_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Product(101, "Phone", 500m, -5));
        }

        [Test]
        public void Product_NegativePrice_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Product(102, "Tablet", -100m, 10));
        }

        // ------------------------
        // Testing Stock Increase (6 tests)
        // ------------------------

        [Test]
        public void IncreaseStock_ValidAmount_ShouldIncreaseStock()
        {
            int initialStock = _product.StockAmount;
            int increaseAmount = 5;

            _product.IncreaseStock(increaseAmount);

            Assert.That(_product.StockAmount, Is.EqualTo(initialStock + increaseAmount));
        }

        [Test]
        public void IncreaseStock_NegativeAmount_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => _product.IncreaseStock(-5));
        }

        [Test]
        public void IncreaseStock_ZeroAmount_ShouldNotChangeStock()
        {
            int initialStock = _product.StockAmount;

            _product.IncreaseStock(0);

            Assert.That(_product.StockAmount, Is.EqualTo(initialStock));
        }

        [Test]
        public void IncreaseStock_ExceedMaximumStock_ShouldThrowException()
        {
            _product = new Product(100, "Laptop", 1000m, 499995);
            Assert.Throws<ArgumentException>(() => _product.IncreaseStock(10));
        }

        [Test]
        public void IncreaseStock_LargeValidAmount_ShouldIncreaseStock()
        {
            _product = new Product(100, "Laptop", 1000m, 100);
            _product.IncreaseStock(1000);
            Assert.That(_product.StockAmount, Is.EqualTo(1100));
        }

        [Test]
        public void IncreaseStock_AtMaximumStock_ShouldNotThrowException()
        {
            _product = new Product(100, "Laptop", 1000m, 499990);
            _product.IncreaseStock(10);
            Assert.That(_product.StockAmount, Is.EqualTo(500000));
        }

        // ------------------------
        // Testing Stock Decrease (6 tests)
        // ------------------------

        [Test]
        public void DecreaseStock_ValidAmount_ShouldDecreaseStock()
        {
            int initialStock = _product.StockAmount;
            _product.DecreaseStock(5);
            Assert.That(_product.StockAmount, Is.EqualTo(initialStock - 5));
        }

        [Test]
        public void DecreaseStock_ZeroAmount_ShouldNotChangeStock()
        {
            int initialStock = _product.StockAmount;
            _product.DecreaseStock(0);
            Assert.That(_product.StockAmount, Is.EqualTo(initialStock));
        }

        [Test]
        public void DecreaseStock_NegativeAmount_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => _product.DecreaseStock(-5));
        }

        [Test]
        public void DecreaseStock_ExceedStock_ShouldReturnFalse()
        {
            Assert.That(_product.DecreaseStock(20), Is.False);
        }

        [Test]
        public void DecreaseStock_ToZero_ShouldWork()
        {
            _product = new Product(100, "Laptop", 1000m, 5);
            Assert.That(_product.DecreaseStock(5), Is.True);
            Assert.That(_product.StockAmount, Is.EqualTo(0));
        }

        [Test]
        public void DecreaseStock_ValidLargeAmount_ShouldDecreaseStock()
        {
            _product = new Product(100, "Laptop", 1000m, 500);
            _product.DecreaseStock(250);
            Assert.That(_product.StockAmount, Is.EqualTo(250));
        }
    }
}
