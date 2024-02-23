using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryProject;

namespace ShoppingcartTest
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void CanCreateCategoryWithIdAndDescription()
        {
            // Arrange & Act
            var category = new Category { Id = 1, Description = "Electronics" };

            // Assert
            Assert.IsNotNull(category, "Category should not be null.");
            Assert.AreEqual(1, category.Id, "Category Id should match the assigned value.");
            Assert.AreEqual("Electronics", category.Description, "Category description should match the assigned value.");
        }

        [TestMethod]
        public void CategoryIdCanBeUpdated()
        {
            // Arrange
            var category = new Category { Id = 1, Description = "Books" };

            // Act
            category.Id = 2;

            // Assert
            Assert.AreEqual(2, category.Id, "Category Id should be updatable.");
        }

        [TestMethod]
        public void CategoryDescriptionCanBeUpdated()
        {
            // Arrange
            var category = new Category { Id = 1, Description = "Books" };

            // Act
            category.Description = "Electronics";

            // Assert
            Assert.AreEqual("Electronics", category.Description, "Category description should be updatable.");
        }

        [TestMethod]
        public void CanCreateCategoryWithoutDescription()
        {
            // Arrange & Act
            var category = new Category { Id = 1 };

            // Assert
            Assert.IsNotNull(category, "Category should not be null.");
            Assert.AreEqual(1, category.Id, "Category Id should match the assigned value.");
            Assert.IsNull(category.Description, "Category description should be null.");
        }
    }
}
