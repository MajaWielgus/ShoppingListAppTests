using Microsoft.VisualBasic.FileIO;
using ShoppingListApp;
using System;


class Program
{
    static void Main()
    {
        var list = new ShoppingList();
        var shoppingList = new ShoppingList();


        while (true)
        {
            Console.WriteLine("1. Dodaj produkt\n2. Usuń produkt\n3. Edytuj\n4. Pokaż\n5. Eksport CSV\n6. Import CSV\n0. Wyjście");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // DODAJ
                    Console.Write("Nazwa produktu: ");
                    var name = Console.ReadLine();
                    Console.Write("Ilość: ");
                    if (int.TryParse(Console.ReadLine(), out int qty))
                    {
                        shoppingList.AddProduct(new Product { Name = name, Quantity = qty });
                        Console.WriteLine("Dodano.");
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawna ilość.");
                    }
                    break;

                case "2": // USUŃ
                    Console.Write("Podaj nazwę produktu do usunięcia: ");
                    var nameToRemove = Console.ReadLine();
                    if (shoppingList.RemoveProduct(nameToRemove))
                    {
                        Console.WriteLine("Usunięto.");
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono produktu.");
                    }
                    break;

                case "3": // EDYTUJ
                    Console.Write("Podaj nazwę produktu do edycji: ");
                    var toEdit = Console.ReadLine();
                    Console.Write("Nowa ilość: ");
                    if (int.TryParse(Console.ReadLine(), out int newQty))
                    {
                        if (shoppingList.EditProduct(toEdit, newQty))
                            Console.WriteLine("Zaktualizowano.");
                        else
                            Console.WriteLine("Nie znaleziono produktu.");
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawna ilość.");
                    }
                    break;

                case "4": // POKAŻ LISTĘ
                    var all = shoppingList.GetAllProducts();
                    if (all.Count == 0)
                    {
                        Console.WriteLine("Lista jest pusta.");
                    }
                    else
                    {
                        Console.WriteLine("\n--- Lista zakupów ---");
                        foreach (var p in all)
                            Console.WriteLine($"{p.Name} - {p.Quantity}");
                    }
                    break;

                case "5": // EKSPORT
                    Console.Write("Podaj ścieżkę pliku do eksportu (np. C:\\produkty.csv): ");
                    var exportPath = Console.ReadLine();
                    CsvManager.ExportToCsv(exportPath, shoppingList.GetAllProducts());
                    Console.WriteLine("Eksport zakończony.");
                    break;

                case "6": // IMPORT
                    Console.Write("Podaj pełną ścieżkę pliku CSV do importu: ");
                    var importPath = Console.ReadLine();
                    if (File.Exists(importPath))
                    {
                        var imported = CsvManager.ImportFromCsv(importPath);
                        foreach (var p in imported)
                            shoppingList.AddProduct(p);
                        Console.WriteLine("Import zakończony.");
                    }
                    else
                    {
                        Console.WriteLine("Plik nie istnieje!");
                    }
                    break;

                case "0": // WYJŚCIE
                    return;

                default:
                    Console.WriteLine("Nieznana opcja.");
                    break;
            }

        }
    }
}
