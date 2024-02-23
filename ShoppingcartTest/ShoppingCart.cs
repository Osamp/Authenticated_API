using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryProject;
using System.Linq;

namespace ShoppingcartTest
{
    [TestClass]
    public class ShoppingCartTests
    {
        [TestMethod]
        public void ShoppingCartInitialization_EmptyProductsList()
        {
            // Arrange & Act
            var shoppingCart = new ShoppingCart();

            // Assert
            Assert.IsNotNull(shoppingCart.Products, "Products list should be initialized.");
            Assert.AreEqual(0, shoppingCart.Products.Count, "Products list should be empty upon initialization.");
        }

        [TestMethod]
        public void AddProductToShoppingCart_IncreasesProductsCount()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var product = new Product { Id = 1, Name = "Smartphone", Price = 500m };

            // Act
            shoppingCart.Products.Add(product);

            // Assert
            Assert.AreEqual(1, shoppingCart.Products.Count, "Adding a product should increase the products count.");
        }

        [TestMethod]
        public void RemoveProductFromShoppingCart_DecreasesProductsCount()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var product = new Product { Id = 1, Name = "Smartphone", Price = 500m };
            shoppingCart.Products.Add(product);

            // Act
            shoppingCart.Products.Remove(product);

            // Assert
            Assert.AreEqual(0, shoppingCart.Products.Count, "Removing a product should decrease the products count.");
        }

        [TestMethod]
        public void ShoppingCart_UserIdentifierCanBeSetAndRetrieved()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var userId = "User123";

            // Act
            shoppingCart.User = userId;

            // Assert
            Assert.AreEqual(userId, shoppingCart.User, "The user identifier should be correctly set and retrieved.");
        }
    }
}
