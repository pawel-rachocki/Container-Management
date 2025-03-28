using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Ship> ships = new List<Ship>();
    static List<Container> containers = new List<Container>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            DisplayMainMenu();
            string choice = Console.ReadLine();
            HandleUserChoice(choice);
        }
    }

    static void DisplayMainMenu()
    {
        Console.WriteLine("Lista kontenerowców (statków):");
        if (ships.Count == 0) Console.WriteLine("Brak");
        else foreach (var ship in ships) Console.WriteLine($"- {ship.MaxSpeed} knots, {ship.MaxContainerNumber} containers, {ship.MaxWeight} tons");

        Console.WriteLine("\nLista kontenerów:");
        if (containers.Count == 0) Console.WriteLine("Brak");
        else foreach (var container in containers) Console.WriteLine($"- {container.SerialNum} ({container.GetType().Name})");

        Console.WriteLine("\nMożliwe akcje:");
        Console.WriteLine("1. Dodaj kontenerowiec");
        Console.WriteLine("2. Usuń kontenerowiec");
        Console.WriteLine("3. Dodaj kontener");
        Console.WriteLine("4. Umieść kontener na statku");
        Console.WriteLine("5. Usuń kontener ze statku");
        Console.WriteLine("6. Wyjdź");
        Console.Write("Wybierz opcję: ");
    }

    static void HandleUserChoice(string choice)
    {
        switch (choice)
        {
            case "1": AddShip(); break;
            case "2": RemoveShip(); break;
            case "3": AddContainer(); break;
            case "4": PlaceContainerOnShip(); break;
            case "5": RemoveContainerFromShip(); break;
            case "6": Environment.Exit(0); break;
            default: Console.WriteLine("Nieprawidłowy wybór, naciśnij Enter aby kontynuować..."); Console.ReadLine(); break;
        }
    }

    static void AddShip()
    {
        Console.Write("Podaj maksymalną prędkość statku (knots): ");
        double speed = double.Parse(Console.ReadLine());
        Console.Write("Podaj maksymalną liczbę kontenerów: ");
        int maxContainers = int.Parse(Console.ReadLine());
        Console.Write("Podaj maksymalny ładunek (tony): ");
        double maxWeight = double.Parse(Console.ReadLine());

        ships.Add(new Ship(new List<Container>(), speed, maxContainers, maxWeight));
        Console.WriteLine("Dodano nowy statek! Naciśnij Enter...");
        Console.ReadLine();
    }

    static void RemoveShip()
    {
        if (ships.Count == 0)
        {
            Console.WriteLine("Brak statków do usunięcia. Naciśnij Enter...");
            Console.ReadLine();
            return;
        }
        Console.Write("Podaj numer indeksu statku do usunięcia: ");
        int index = int.Parse(Console.ReadLine());
        if (index < 0 || index >= ships.Count)
        {
            Console.WriteLine("Nieprawidłowy indeks. Naciśnij Enter...");
            Console.ReadLine();
            return;
        }
        ships.RemoveAt(index);
        Console.WriteLine("Statek usunięty! Naciśnij Enter...");
        Console.ReadLine();
    }

    static void AddContainer()
    {
        Console.Write("Podaj typ kontenera (L - Liquid, G - Gas, C - Refrigerated): ");
        string type = Console.ReadLine().ToUpper();

        Console.Write("Podaj wagę ładunku: ");
        double loadWeight = double.Parse(Console.ReadLine());
        Console.Write("Podaj wysokość: ");
        double height = double.Parse(Console.ReadLine());
        Console.Write("Podaj wagę kontenera: ");
        double weight = double.Parse(Console.ReadLine());
        Console.Write("Podaj głębokość: ");
        double depth = double.Parse(Console.ReadLine());
        Console.Write("Podaj maksymalny ładunek: ");
        double maxLoad = double.Parse(Console.ReadLine());

        Container container = null;

        if (type == "L") container = new LiquidContainer(loadWeight, height, weight, depth, maxLoad, false);
        else if (type == "G") container = new GasContainer(loadWeight, height, weight, depth, maxLoad, 1.0);
        else if (type == "C")
        {
            Console.Write("Podaj typ przechowywanego produktu: ");
            string productType = Console.ReadLine();
            Console.Write("Podaj temperaturę przechowywania: ");
            double temperature = double.Parse(Console.ReadLine());
            container = new RefrigeratedContainer(loadWeight, height, weight, depth, maxLoad, productType, temperature);
        }

        if (container != null)
        {
            containers.Add(container);
            Console.WriteLine("Kontener dodany! Naciśnij Enter...");
        }
        else
        {
            Console.WriteLine("Nieprawidłowy typ kontenera. Naciśnij Enter...");
        }
        Console.ReadLine();
    }

    static void PlaceContainerOnShip()
    {
        Console.Write("Podaj numer indeksu statku: ");
        int shipIndex = int.Parse(Console.ReadLine());
        Console.Write("Podaj numer indeksu kontenera: ");
        int containerIndex = int.Parse(Console.ReadLine());

        if (shipIndex < 0 || shipIndex >= ships.Count || containerIndex < 0 || containerIndex >= containers.Count)
        {
            Console.WriteLine("Nieprawidłowe indeksy. Naciśnij Enter...");
            Console.ReadLine();
            return;
        }

        ships[shipIndex].AddContainer(containers[containerIndex]);
        containers.RemoveAt(containerIndex);
        Console.WriteLine("Kontener umieszczony na statku! Naciśnij Enter...");
        Console.ReadLine();
    }

    static void RemoveContainerFromShip()
    {
        Console.Write("Podaj numer indeksu statku: ");
        int shipIndex = int.Parse(Console.ReadLine());
        Console.Write("Podaj numer seryjny kontenera do usunięcia: ");
        string serialNum = Console.ReadLine();

        if (shipIndex < 0 || shipIndex >= ships.Count)
        {
            Console.WriteLine("Nieprawidłowy indeks statku. Naciśnij Enter...");
            Console.ReadLine();
            return;
        }

        ships[shipIndex].RemoveContainer(serialNum);
        Console.WriteLine("Kontener usunięty! Naciśnij Enter...");
        Console.ReadLine();
    }
}
