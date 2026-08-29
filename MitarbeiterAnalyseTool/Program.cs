namespace MitarbeiterAnalyseTool
{
    public class MitarbeiterAnalyseTool
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Willkommen beim Mitarbeiter-Analyse-Tool!");
            Console.WriteLine();

            DateTime geburtsdatum = new DateTime(1986, 12, 2);
            Mitarbeiter m1 = new Mitarbeiter("Max",
                                            "Mustermann",
                                             geburtsdatum,
                                             3500.50m);
            m1.DatenAusgeben();

            Console.WriteLine();
            Console.WriteLine("Drücke eine beliebige Taste zum Beenden...");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
