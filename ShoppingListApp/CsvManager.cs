using ShoppingListApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class CsvManager
{
    public static void ExportToCsv(string filePath, List<Product> products)
    {
        using StreamWriter writer = new(filePath);
        foreach (var p in products)
        {
            writer.WriteLine($"{p.Name},{p.Quantity}");
        }
    }

    public static List<Product> ImportFromCsv(string filePath)
    {
        var products = new List<Product>();
        var lines = File.ReadAllLines(filePath);

        int startIndex = 0;
        if (lines.Length > 0 && lines[0].StartsWith("Nazwa", StringComparison.OrdinalIgnoreCase))
        {
            startIndex = 1; // pomijamy nagłówek TYLKO jeśli istnieje
        }

        for (int i = startIndex; i < lines.Length; i++)
        {
            var parts = lines[i].Split(',');
            if (parts.Length == 2 && int.TryParse(parts[1], out int quantity))
            {
                products.Add(new Product { Name = parts[0], Quantity = quantity });
            }
        }

        return products;
    }


}

