using static System.Console;

namespace MitarbeiterAnalyseTool
{
    public class MitarbeiterVerwaltung
    {
        private readonly List<Mitarbeiter> mitarbeiterListe=[];
        private DateiVerwaltung dateiVerwaltung;

        public MitarbeiterVerwaltung()
        {
            dateiVerwaltung = new DateiVerwaltung();
           mitarbeiterListe = dateiVerwaltung.DatenLaden();
        }
        public void DatenSichern()
        {
            dateiVerwaltung.DatenSpeichern(mitarbeiterListe);

        }

        public void MitarbeiterHinzufuegen(Mitarbeiter neuerMitarbeiter)
        {
            mitarbeiterListe.Add(neuerMitarbeiter);
            WriteLine($"Mitarbeiter {neuerMitarbeiter.Vorname} " +
                              $"{neuerMitarbeiter.Nachname} " +
                              $"wurde erfolgreich hinzugefügt.");   
        }

        public void AlleMitarbeiterAusgeben()
        {
            WriteLine("\n--- Komplette Mitarbeiterliste ---");
            if (mitarbeiterListe.Count == 0)
            {
                WriteLine("Kein Mitarbeiter in der Datenbank vorhanden.");
                return;
            }

            foreach (Mitarbeiter aktuellerMitarbeiter in mitarbeiterListe)
            {
                aktuellerMitarbeiter.DatenAusgeben();
            }
        }

        public decimal DurchschnittsgehaltsBerechnen()
        {
            if (mitarbeiterListe.Count == 0)
            {
                return 0m;
            }

            decimal gesamtGehalt = 0m;

            foreach(Mitarbeiter aktuellerMitarbeier in mitarbeiterListe)
            {
                gesamtGehalt += aktuellerMitarbeier.Gehalt;
            }

            return gesamtGehalt / mitarbeiterListe.Count;
        }

        /// <summary>
        ///         Filtert die Mitarbeiter nach ihrer Abteilung.
        /// </summary>
        /// <remarks>
        ///         Entspricht ohne LINQ folgendem Code:
        /// 
        /// <code>
        ///
        /// foreach (Mitarbeiter mitarbeiter in mitarbeiterListe)
        /// {
        ///     if (mitarbeiter.MitarbeiterAbteilung == suchAbteilung)
        ///     {
        ///         gefilterteListe.Add(mitarbeiter);
        ///     }
        /// }
        /// </code>
        /// </remarks>

        public void MitarbeiterNachAbteilungAusgeben(Abteilung gesuchteAbteilung)
        {
            Console.WriteLine($"\n----- Mitarbeiter in der Abteilung {gesuchteAbteilung} ----");
            // filtert alle Mitarbeiter, die der gesuchten Abteilung entspricht.

            var gesuchteMitarbeiter = mitarbeiterListe.Where(m => m.MitarbeiterAbteilung == gesuchteAbteilung).ToList();
            if(gesuchteMitarbeiter.Count == 0)
            {
                Console.WriteLine("Keine Mitarbeiter in der Abteiung gefunden.");
                return;
            }
            foreach(var mitarbeiter in gesuchteMitarbeiter)
            {
                mitarbeiter.DatenAusgeben();
            }

        }

        public void TopVerdienerAusgeben()
        {
            Console.WriteLine("\n--- Mitarbeiter nach Gehalt(absteigen) ---");
            var sortierteListe = mitarbeiterListe.OrderByDescending(m =>m.Gehalt).ToList();
            foreach(var mitarbeiter in sortierteListe)
            {
                mitarbeiter.DatenAusgeben();
            }
        }

    }
}
