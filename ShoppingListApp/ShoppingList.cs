using ShoppingListApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShoppingList
{
    private List<Product> products = new();

    public void AddProduct(Product product) => products.Add(product);

    public bool RemoveProduct(string name)
    {
        var product = products.Find(p => p.Name == name);
        if (product != null)
        {
            products.Remove(product);
            return true;
        }
        return false;
    }

    public bool EditProduct(string name, int newQuantity)
    {
        var product = products.Find(p => p.Name == name);
        if (product != null)
        {
            product.Quantity = newQuantity;
            return true;
        }
        return false;
    }

    public List<Product> GetAllProducts() => new(products);
}
