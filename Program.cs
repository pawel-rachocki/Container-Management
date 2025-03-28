using System;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("=== Test GasContainer Unload ===");
        GasContainer gasContainer = new GasContainer(3000, 200, 500, 250, 5000, 2.5);
        Console.WriteLine($"Przed rozładunkiem: {gasContainer.LoadWeight} kg");

        gasContainer.Unload();
        Console.WriteLine($"Po rozładunku: {gasContainer.LoadWeight} kg (powinno zostać 5%)");

        Console.WriteLine("\n=== Test RefrigeratedContainer ===");
        try
        {
            RefrigeratedContainer fridgeContainer = new RefrigeratedContainer(0, 200, 500, 250, 1000, "Banany", 10);
            Console.WriteLine("Ładuję 500 kg bananów...");
            fridgeContainer.Load(500, "Banany");
            Console.WriteLine($"Aktualny ładunek: {fridgeContainer.LoadWeight} kg");

            Console.WriteLine("Próbuję załadować 200 kg ryb (powinno być zabronione)...");
            fridgeContainer.Load(200, "Ryby");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }

        try
        {
            Console.WriteLine("\n=== Test z za niską temperaturą ===");
            RefrigeratedContainer coldContainer = new RefrigeratedContainer(0, 200, 500, 250, 1000, "Banany", 5);
            Console.WriteLine("Próbuję załadować 300 kg bananów przy temperaturze 5°C...");
            coldContainer.Load(300, "Banany");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
    }
}
