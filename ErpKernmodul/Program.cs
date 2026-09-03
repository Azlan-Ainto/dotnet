
namespace ErpKernmodul
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== ERP-Kernmodul - Datenbank Testlauf ===\n");
            
            KundenVerwaltung kundenVerwaltung = new();       
            //AlleKundenEntfernen(new KundenVerwaltung());
            //NeuenKundeErstellen(kundenVerwaltung);
            kundenVerwaltung.KundeAktualisieren(7, "Erika Milner");
            AlleKundenAusgeben(kundenVerwaltung);
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
