
namespace ErpKernmodul
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== ERP-Kernmodul - Datenbank Testlauf ===\n");
            // 
            // 1. Kundenverwaltung initialisieren und einige Bestellungen anlegen
            KundenVerwaltung kundenVerwaltung = new();
            kundenVerwaltung.BestellungFuerKundeAnlegen(7, 1450.50m, "Musterstraße 1, 12345 Musterstadt");
            kundenVerwaltung.BestellungFuerKundeAnlegen(7, 299.99m, "Berliner Platz 2, 58089 Hagen");
            kundenVerwaltung.BestellungFuerKundeAnlegen(7, 1200.00m, "Berliner Platz 2, 58089 Hagen");
            kundenVerwaltung.BestellungFuerKundeAnlegen(8, 500.00m, "Hagener Straße 50, 58135 Hagen");
            kundenVerwaltung.BestellungFuerKundeAnlegen(8, 750.00m, "Hagener Straße 50, 58135 Hagen");
            kundenVerwaltung.BestellungFuerKundeAnlegen(9, 250.00m, "Hauptstraße 10, 58095 Hagen");
            // 2. Kunden samt ihrer Bestellungen ausgeben
            AlleKudenMitBestellungenAusgeben(kundenVerwaltung);
            //AlleKundenEntfernen(new KundenVerwaltung());
            //NeuenKundeErstellen(kundenVerwaltung);
            // kundenVerwaltung.KundeAktualisieren(7, "Erika Milner");
            //AlleKundenAusgeben(kundenVerwaltung);
        }

        private static void AlleKudenMitBestellungenAusgeben(KundenVerwaltung kundenVerwaltung)
        {
            Console.WriteLine("\n--- Kundenbericht inkl. Bestellhistorie ---");
            List<Kunde> kundenMitBestellungen = kundenVerwaltung.AlleKundenMitBestellungenLaden();
            foreach (var kunde in kundenMitBestellungen)
            {
                Console.WriteLine($"Firma: {kunde.Firmenname} (Kundennummer: {kunde.KundenNummer})");
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

            }
        }

        private static void NeuenKundeErstellen(KundenVerwaltung kundenVerwaltung)
        {
            Kunde otto = new()
            {
                KundenNummer = "K12345",
                Firmenname = "Otto GmbH",
                Ansprechpartner = "Max Mustermann",
                Erfassunsdatum = DateTime.Now
            };
            Kunde billstein = new()
            {
                KundenNummer = "K12346",
                Firmenname = "Billstein GmbH",
                Ansprechpartner = "Max Mustermann",
                Erfassunsdatum = DateTime.Now
            };
            Kunde bosch = new()
            {
                KundenNummer = "K12347",
                Firmenname = "Bosch GmbH",
                Ansprechpartner = "Gert Müller",
                Erfassunsdatum = DateTime.Now
            };

            Kunde kamp = new()
            {
                KundenNummer = "K12348",
                Firmenname = "Kamp GmbH",
                Ansprechpartner = "Hans Meier",
                Erfassunsdatum = DateTime.Now
            };
            
            Kunde rewe = new()
            {
                KundenNummer = "K12349",
                Firmenname = "Rewe GmbH",
                Ansprechpartner = "Peter Schmidt",
                Erfassunsdatum = DateTime.Now
            };

            kundenVerwaltung.KundeAnlegen(otto);
            kundenVerwaltung.KundeAnlegen(billstein);
            kundenVerwaltung.KundeAnlegen(bosch);
            kundenVerwaltung.KundeAnlegen(kamp);
            kundenVerwaltung.KundeAnlegen(rewe);

        }

        private static void AlleKundenAusgeben(KundenVerwaltung kundenVerwaltung)
        {
            Console.WriteLine("\nAlle Kunden in der Datenbank:");
            List<Kunde> alleKunden = kundenVerwaltung.AlleKundenLaden();
            foreach (var kunde in alleKunden)
            {
                Console.WriteLine($"ID:              {kunde.KundenId}\n" +
                                  $"Nummer:          {kunde.KundenNummer}\n" +
                                  $"Firma:           {kunde.Firmenname}\n" +
                                  $"Ansprechpartner: {kunde.Ansprechpartner}\n" +
                                  $"Erfasst am:      {kunde.Erfassunsdatum}\n");

            }
        }

        private static void AlleKundenEntfernen(KundenVerwaltung kundenVerwaltung)
        {
            // alle Kunden löschen
            int anzahl = kundenVerwaltung.AlleKundenLaden().Count;

            for (int i = 1; i <= anzahl; i++)
            {
                kundenVerwaltung.KundeLoeschen(i);
            }
            Console.WriteLine("\nAlle Kunden wurden gelöscht.");
        }
    }
}
