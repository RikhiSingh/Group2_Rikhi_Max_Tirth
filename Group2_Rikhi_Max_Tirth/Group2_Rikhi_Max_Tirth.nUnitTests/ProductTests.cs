using ECommerceApp;

namespace Group2_Rikhi_Max_Tirth_Tests;

public class Tests
{
    
    private Product _product { get; set; } = null;
    
    [SetUp]
    public void Setup()
    {
        _product = new Product(100, "Laptop", 1000, 10);
    }

    // Testing Attributes
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
    
    // Testing Stock Increase
    
    
    // Testing Stock Decrease
}