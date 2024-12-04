using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Models;
using Xunit;
namespace Shop.Test
{
    public class ShoppingListTests
    {
        [Fact]
        public void AddProduct_ShouldAddProductToList()
        {
            // Arrange
            var shoppingList = new ShoppingList<Product>();
            var product = new Food("Apple", 1.20, 5, "12/2025");

            // Act
            shoppingList.AddProduct(product);

            // Assert
            Assert.Contains(product, shoppingList.GetAllProducts());
        }

        [Fact]
        public void RemoveProduct_ShouldRemoveProductFromList()
        {
            // Arrange
            var shoppingList = new ShoppingList<Product>();
            var product = new Food("Apple", 1.20, 5, "12/2025");
            shoppingList.AddProduct(product);

            // Act
            shoppingList.RemoveProduct(product);

            // Assert
            Assert.DoesNotContain(product, shoppingList.GetAllProducts());
        }

        [Fact]
        public void TotalPrice_ShouldReturnSumOfAllProductPrices()
        {
            // Arrange
            var shoppingList = new ShoppingList<Product>();
            shoppingList.AddProduct(new Food("Apple", 1.20, 5, "12/2025")); // 6.00
            shoppingList.AddProduct(new Food("Orange", 0.80, 10, "11/2025")); // 8.00

            // Act
            var totalPrice = shoppingList.TotalPrice();

            // Assert
            Assert.Equal(14.00, totalPrice, 2); // Проверява се до втория знак след десетичната точка
        }
        [Fact]
        public void GetProductByName_ShouldReturnCorrectProduct()
        {
            // Arrange
            var shoppingList = new ShoppingList<Product>();
            var product = new Food("Apple", 1.20, 5, "12/2025");
            shoppingList.AddProduct(product);

            // Act
            var result = shoppingList.GetProductByName("Apple");

            // Assert
            Assert.Equal(product, result);
        }

    }
}
