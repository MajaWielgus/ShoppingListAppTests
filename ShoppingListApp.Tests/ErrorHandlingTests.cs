using System.IO;
using Xunit;

namespace ShoppingListApp.Tests
{
    public class ErrorHandlingTests
    {
        [Fact]
        public void ImportFromCsv_ShouldIgnoreInvalidLines()
        {
            var filePath = "bad.csv";
            File.WriteAllLines(filePath, new string[] {
                "Nazwa,Ilosc",
                "Prawidlowy,3",
                "Nieprawidlowy,dwa",
                "JeszczePrawidlowy,5"
            });

            var products = CsvManager.ImportFromCsv(filePath);

            if (File.Exists(filePath)) File.Delete(filePath);

            Assert.Equal(2, products.Count); // tylko dwie linie poprawne
            Assert.Contains(products, p => p.Name == "Prawidlowy" && p.Quantity == 3);
            Assert.Contains(products, p => p.Name == "JeszczePrawidlowy" && p.Quantity == 5);
        }

        [Fact]
        public void RemoveProduct_ShouldReturnFalse_WhenProductDoesNotExist()
        {
            var list = new ShoppingList();

            var result = list.RemoveProduct("Nieistniejący");

            Assert.False(result);
        }
    }
}
