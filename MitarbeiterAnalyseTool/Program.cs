using System.Threading.Channels;

namespace MitarbeiterAnalyseTool
{
    public class MitarbeiterAnalyseTool
    {
        static void Main(string[] args)
        {
            
            MitarbeiterVerwaltung verwaltung = new();

            Mitarbeiter m1 = new("Max", 
                                "Mustermann", 
                                new DateTime(1986, 12, 02), 
                                5000.00m);

            Mitarbeiter m2 = new("Anna", 
                                "Schmidt", 
                                new DateTime(1990, 12, 2), 
                                4000.90m);

            Mitarbeiter m3 = new("Thomas", 
                                "Mann", 
                                new DateTime(1950,12,2), 
                                4500.50m);

            verwaltung.MitarbeiterHinzufuegen(m1);
            verwaltung.MitarbeiterHinzufuegen(m2);
            verwaltung.MitarbeiterHinzufuegen(m3);
            verwaltung.AlleMitarbeiterAusgeben();

            decimal durchschnittsgehalt = verwaltung.DurchschnittsgehaltsBerechnen();
            Console.WriteLine($"\nDurchschnittsgehalt beträgt: " +
                                $"{durchschnittsgehalt:N2} EUR ");
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"=======================================================\n");
            Console.ResetColor();

            // List<Mitarbeiter> mitarbeiterListe = new List<Mitarbeiter>();
            List<Mitarbeiter> mitarbeiterListe =
            [
                  new(  "Max", 
                        "Meier", 
                        new DateTime(1986, 12, 02), 
                        5000.00m),

                  new("Anna", 
                      "Anton", 
                      new DateTime(1990, 12, 2), 
                      4000.90m),
                  new("Tim", 
                      "Tuchel", 
                      new DateTime(1950,12,2), 
                      4500.50m),
                  new("Bart", 
                      "Baum", 
                      new DateTime(1986,12,2), 
                      3500.10m),
                  new("Claudia", 
                      "Clark", 
                      new DateTime(1986,12, 2), 
                      4800.20m),
                  new("Claus",
                      "Clown", 
                      new DateTime(1986,12,3),
                      4900.30m)
            ];
            foreach(var  m in mitarbeiterListe)
            {
                verwaltung.MitarbeiterHinzufuegen(m);
            }
            verwaltung.AlleMitarbeiterAusgeben();
            decimal gehaltmittelwert = verwaltung.DurchschnittsgehaltsBerechnen();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"\n\nDer Gehaltsdurchschnitt beträgt:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($" {gehaltmittelwert:N2} EUR\n");
            Console.ResetColor();

            Console.WriteLine("Drücke eine beliebige Taste zum Beenden.");
            Console.ReadKey();         
        }
    }
}
