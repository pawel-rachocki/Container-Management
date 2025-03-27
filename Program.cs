internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Tworzymy przykładowy kontener
            Container container = new Container(0, 200, 1000, 500, 5000); // maxLoad = 5000kg

            Console.WriteLine("Dodaję ładunek 3000 kg...");
            container.Load(3000);
            Console.WriteLine($"Aktualny ładunek: {container.LoadWeight} kg");

            Console.WriteLine("Dodaję ładunek 2500 kg...");
            container.Load(2500); // powinno rzucić wyjątek
            Console.WriteLine($"Aktualny ładunek: {container.LoadWeight} kg");
        }
        catch (OverfillException ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
    }
}
