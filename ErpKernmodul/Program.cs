
using ErpKernmodul.Geschaeftslogik;
using ErpKernmodul.Repositorys;
using ErpKernmodul.Schnittstellen;

namespace ErpKernmodul
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== ERP-Kernmodul - Datenbank Testlauf ===\n");

            using (var kontext = new ErpKontext())
            {
                IKundenRepository kundenRepository = new KundenRepository(kontext);
                KundenVerwaltung kundenVerwaltung = new KundenVerwaltung(kundenRepository);
                Console.WriteLine("Lade Kundenhistorie...");
                List<Kunde> kundenListe = kundenVerwaltung.AlleKundenMitBestellungenLaden();
                foreach (var kunde in kundenListe)
                {
                    Console.WriteLine($"Firma: {kunde.Firmenname}");
                    if (kunde.Bestellungen.Any())
                    {
                        Console.WriteLine("Bestellungen:");
                        foreach (var bestellung in kunde.Bestellungen)
                        {
                            Console.WriteLine($"->ID: {bestellung.BestellId} |" +
                                $" Datum: {bestellung.Bestelldatum.ToShortDateString()} |" +
                                $" Betrag: {bestellung.Gesamtbetrag} Euro | " +
                                $"Lieferung: {bestellung.Lieferadresse}");
                        }
                    }
                    Console.WriteLine("\n");
                }
            }

        }  
    }
}
