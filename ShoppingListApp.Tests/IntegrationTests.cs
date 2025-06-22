using System.IO;
using Xunit;

namespace ShoppingListApp.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void AddExportImport_ShouldMaintainProducts()
        {
            var list = new ShoppingList();
            list.AddProduct(new Product { Name = "Jajka", Quantity = 12 });
            list.AddProduct(new Product { Name = "Mąka", Quantity = 1 });

            var filePath = "test.csv";
            CsvManager.ExportToCsv(filePath, list.GetAllProducts());

            var importedProducts = CsvManager.ImportFromCsv(filePath);

            // Usuwnie pliku po teście, żeby nie zajmowac miejsca
            if (File.Exists(filePath)) File.Delete(filePath);

            Assert.Equal(list.GetAllProducts().Count, importedProducts.Count);
            Assert.Contains(importedProducts, p => p.Name == "Jajka" && p.Quantity == 12);
            Assert.Contains(importedProducts, p => p.Name == "Mąka" && p.Quantity == 1);
        }
    }
}
