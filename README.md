# 🛒 ShoppingListApp – projekt testowy

**ShoppingListApp** to prosta aplikacja konsolowa w języku **C#**, której głównym celem jest **praktyczne zastosowanie różnych typów testów automatycznych**. Projekt został zaprojektowany jako przykład aplikacji do testowania jednostkowego, integracyjnego, obsługi błędów oraz testów wydajnościowych z wykorzystaniem frameworka **xUnit**.

---

## 🎯 Cel projektu

Głównym celem projektu nie jest tylko stworzenie funkcjonalnej listy zakupów, ale przede wszystkim:

- zaprojektowanie kodu łatwego do testowania,
- zastosowanie testów jednostkowych, integracyjnych, wydajnościowych i obsługi błędów,
- praktyczne ćwiczenie pisania i uruchamiania testów w C# z użyciem `xUnit`.

---

## 🛠️ Funkcjonalność aplikacji

- Dodawanie, usuwanie i edytowanie produktów na liście
- Wyświetlanie listy produktów
- Eksport danych do pliku CSV
- Import danych z pliku CSV z walidacją
- Obsługa błędnych danych (np. tekst zamiast liczby)

---

## 🧪 Typy testów

Projekt zawiera **cztery główne typy testów**:

### ✅ 1. Testy jednostkowe (`ShoppingListTests.cs`)

Sprawdzają podstawowe operacje:
- Dodanie produktu do listy
- Usunięcie istniejącego produktu
- Edytowanie ilości produktu

### 🚫 2. Testy obsługi błędów (`ErrorHandlingTests.cs`)

Weryfikują:
- Czy błędne dane w pliku CSV są ignorowane
- Czy aplikacja poprawnie reaguje na próbę usunięcia nieistniejącego produktu

### 🔄 3. Testy integracyjne (`IntegrationTests.cs`)

Sprawdzają cały proces:
- dodanie produktu  
→ eksport do CSV  
→ import z CSV  
→ porównanie danych

### ⚡ 4. Testy wydajnościowe (`PerformanceTests.cs`)

Mierzą, czy masowe dodanie **10 000 produktów** wykonuje się w czasie poniżej **1 sekundy**.

---

## ⚙️ Technologie

- Visual Studio 2022  
- xUnit (framework testowy)  
- .NET / C#  
- Obsługa plików CSV  

