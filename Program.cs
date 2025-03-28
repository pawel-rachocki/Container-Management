using System;
using System.Collections.Generic;

internal class Program
{
    static void Main()
    {
        // Tworzenie kontenerów
        Container liquidContainer = new LiquidContainer(1000, 250, 500, 300, 5000, true);
        Container gasContainer = new GasContainer(2000, 250, 700, 300, 5000, 5);
        Container refrigeratedContainer = new RefrigeratedContainer(500, 250, 400, 300, 3000, "bananas", 10);

        // Tworzenie statku
        Ship ship1 = new Ship(new List<Container>(), 30, 5, 20); // max 5 kontenerów, 20 ton

        Console.WriteLine("=== Dodawanie kontenerów na statek ===");
        ship1.AddContainer(liquidContainer);
        ship1.AddContainer(gasContainer);
        ship1.PrintShipInfo();

        Console.WriteLine("\n=== Usuwanie kontenera ===");
        ship1.RemoveContainer(liquidContainer.SerialNum);
        ship1.PrintShipInfo();

        Console.WriteLine("\n=== Zastępowanie kontenera ===");
        ship1.ReplaceContainer(refrigeratedContainer, gasContainer.SerialNum);
        ship1.PrintShipInfo();

        Console.WriteLine("\n=== Transfer kontenera na drugi statek ===");
        Ship ship2 = new Ship(new List<Container>(), 25, 3, 15);
        ship1.TransferContainer(ship2, refrigeratedContainer.SerialNum);

        Console.WriteLine("\nStatek 1 po przeniesieniu:");
        ship1.PrintShipInfo();

        Console.WriteLine("\nStatek 2 po przeniesieniu:");
        ship2.PrintShipInfo();
    }
}
