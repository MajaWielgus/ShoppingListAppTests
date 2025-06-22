using System.Diagnostics;
using Xunit;

namespace ShoppingListApp.Tests
{
    public class PerformanceTests
    {
        [Fact]
        public void AddManyProducts_ShouldCompleteQuickly()
        {
            var list = new ShoppingList();
            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 10000; i++)
            {
                list.AddProduct(new Product { Name = $"Produkt{i}", Quantity = i });
            }

            stopwatch.Stop();

            // Test przejdzie, jeśli zajmie mniej niż 1 sekunda (1000 ms)
            Assert.True(stopwatch.ElapsedMilliseconds < 1000, $"Dodawanie zajęło zbyt długo: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
