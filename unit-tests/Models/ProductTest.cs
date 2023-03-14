using e_commerceProj.Models;

namespace unit_tests.Models;

[TestClass]
public class ProductTest
{
    [TestMethod]
    public void TestingPropertiesOfModel()
    {
        // Arrange
        var product = new Product();
        product.ProductID = 1;
        product.ProductName = "Test";
        product.Description = "Test";
        product.Price = 1.99m;
        product.Quantity = 1;

        // Act
        var productId = product.ProductID;
        var productName = product.ProductName;
        var description = product.Description;
        var price = product.Price;
        var quantity = product.Quantity;

        // Assert
        Assert.AreEqual(1, productId);
        Assert.AreEqual("Test", productName);
        Assert.AreEqual("Test", description);
        Assert.AreEqual(1.99m, price);
        Assert.AreEqual(1, quantity);
    }
}