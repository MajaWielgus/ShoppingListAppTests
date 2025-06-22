using ShoppingListApp;
using Xunit;

public class ShoppingListTests
{
    [Fact]
    public void AddProduct_ShouldAddCorrectly()
    {
        var list = new ShoppingList();
        var product = new Product { Name = "Chleb", Quantity = 1 };
        list.AddProduct(product);

        Assert.Contains(list.GetAllProducts(), p => p.Name == "Chleb" && p.Quantity == 1);
    }

    [Fact]
    public void RemoveProduct_ShouldRemoveCorrectly()
    {
        var list = new ShoppingList();
        list.AddProduct(new Product { Name = "Mas³o", Quantity = 2 });

        var result = list.RemoveProduct("Mas³o");

        Assert.True(result);
        Assert.Empty(list.GetAllProducts());
    }

    [Fact]
    public void EditProduct_ShouldUpdateQuantity()
    {
        var list = new ShoppingList();
        list.AddProduct(new Product { Name = "Mleko", Quantity = 1 });

        list.EditProduct("Mleko", 5);

        Assert.Equal(5, list.GetAllProducts().Find(p => p.Name == "Mleko").Quantity);
    }
}
