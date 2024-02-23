using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryProject;

namespace ShoppingcartTest
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void CanCreateProductWithoutCategory()
        {
            // Arrange & Act
            var product = new Product
            {
                Id = 1,
                Name = "Tablet",
                Price = 300m,
                Description = "Latest model of our tablet line."
            };

            // Assert
            Assert.IsNull(product.Category, "Category should be null for a new product without a category assigned.");
        }

        [TestMethod]
        public void CanAssignCategoryToProduct()
        {
            // Arrange
            var category = new Category { Id = 1, Description = "Electronics" };
            var product = new Product();

            // Act
            product.Category = category;

            // Assert
            Assert.IsNotNull(product.Category, "Category should not be null after assigning.");
            Assert.AreEqual("Electronics", product.Category.Description, "Category description should match the assigned value.");
        }

        [TestMethod]
        public void CanUpdateProductName()
        {
            // Arrange
            var product = new Product { Name = "OldName" };

            // Act
            product.Name = "NewName";

            // Assert
            Assert.AreEqual("NewName", product.Name, "Product name should be updatable.");
        }

        [TestMethod]
        public void CanUpdateProductPrice()
        {
            // Arrange
            var product = new Product { Price = 100m };

            // Act
            product.Price = 200m;

            // Assert
            Assert.AreEqual(200m, product.Price, "Product price should be updatable.");
        }
    }
}
